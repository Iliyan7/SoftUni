using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Contracts;
using WebServer.Http;
using WebServer.Http.Contracts;
using WebServer.Http.Response;

namespace WebServer
{
    public class ConnectionHandler
    {
        private const int BUFFER_SIZE = 1024;

        private readonly Socket client;

        private readonly IHandleable requestHandler;

        private readonly IHandleable resourceHandler;

        public ConnectionHandler(Socket client, IHandleable requestHandler, IHandleable resourceHandler)
        {
            this.client = client;
            this.requestHandler = requestHandler;
            this.resourceHandler = resourceHandler;
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadReuqest();

            if (httpRequest != null)
            {
                var httpResponse = this.HandleRequest(httpRequest);

                var responseBytes = this.GetResponseBytes(httpResponse);

                var byteSegments = new ArraySegment<byte>(responseBytes);

                await this.client.SendAsync(byteSegments, SocketFlags.None);

                Console.WriteLine($"-----REQUEST-----");
                Console.WriteLine(httpRequest);
                Console.WriteLine($"-----RESPONSE-----");
                Console.WriteLine(httpResponse);
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<IHttpRequest> ReadReuqest()
        {
            var requestString = new StringBuilder();
            var buffer = new ArraySegment<byte>(new byte[BUFFER_SIZE]);

            int numBytesRead;

            while((numBytesRead = await this.client.ReceiveAsync(buffer, SocketFlags.None)) > 0)
            {
                requestString.Append(Encoding.UTF8.GetString(buffer.Array, 0, numBytesRead));

                if (numBytesRead < BUFFER_SIZE)
                    break;
            }

            if(requestString.Length == 0)
            {
                return null;
            }

            return new HttpRequest(requestString.ToString());
        }

        private IHttpResponse HandleRequest(IHttpRequest request)
        {
            if(request.Path.Contains("."))
            {
                return this.resourceHandler.Handle(request);
            }
            else
            {
                var sessionIdToSend = this.SetRequestSession(request);

                var response = this.requestHandler.Handle(request);

                if(sessionIdToSend != null)
                {
                    response.Headers.Add(HttpHeader.SetCookie, $"{SessionStorage.SessionCookieKey}={sessionIdToSend}; HttpOnly; path=/");
                }
   
                return response;
            }
        }

        private string SetRequestSession(IHttpRequest request)
        {
            string sessionId = null;
            if (!request.Cookies.ContainsKey(SessionStorage.SessionCookieKey))
            {
                sessionId = Guid.NewGuid().ToString();
                request.Session = SessionStorage.GetSession(sessionId);
            }

            return sessionId;
        }

        private byte[] GetResponseBytes(IHttpResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString()).ToList();

            if(response is FileResponse)
            {
                responseBytes.AddRange(((FileResponse)response).FileData);
            }

            return responseBytes.ToArray();
        }
    }
}
