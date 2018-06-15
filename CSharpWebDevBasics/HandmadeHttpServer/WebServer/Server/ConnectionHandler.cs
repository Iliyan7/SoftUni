using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Server.Handlers;
using WebServer.Server.Http;
using WebServer.Server.Routing.Contracts;

namespace WebServer.Server
{
    public class ConnectionHandler
    {
        private const int BUFFER_SIZE = 1024;

        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadReuqest();

            if (!string.IsNullOrEmpty(httpRequest))
            {
                var httpContext = new HttpContext(httpRequest);

                var httpResponse = new HttpHandler(this.serverRouteConfig).Handle(httpContext);

                var responseBytes = new ArraySegment<byte>(Encoding.UTF8.GetBytes(httpResponse.ToString()));

                await this.client.SendAsync(responseBytes, SocketFlags.None);

                Console.WriteLine($"-----REQUEST-----");
                Console.WriteLine(httpRequest);
                Console.WriteLine($"-----RESPONSE-----");
                Console.WriteLine(httpResponse);
                //Console.WriteLine("------END-----");
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<string> ReadReuqest()
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

            return requestString.ToString();
        }
    }
}
