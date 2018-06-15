using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Contracts;
using WebServer.Http;

namespace WebServer
{
    public class ConnectionHandler
    {
        private const int BUFFER_SIZE = 1024;

        private readonly Socket client;

        private readonly IHandleable mvcRequestHandler;

        public ConnectionHandler(Socket client, IHandleable mvcRequestHandler)
        {
            this.client = client;
            this.mvcRequestHandler = mvcRequestHandler;
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadReuqest();

            if (!string.IsNullOrEmpty(httpRequest))
            {
                var httpResponse = this.mvcRequestHandler.Handle(new HttpRequest(httpRequest));

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
