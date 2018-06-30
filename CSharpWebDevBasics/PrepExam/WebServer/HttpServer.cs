using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using WebServer.Contracts;

namespace WebServer
{
    public class HttpServer : IRunnable
    {
        private readonly int port;

        private readonly IHandleable requestHandler;

        private readonly IHandleable resourceHandler;

        private readonly TcpListener listener;

        private bool isRunning;

        public HttpServer(int port, IHandleable requestHandler, IHandleable resourceHandler)
        {
            this.port = port;
            this.requestHandler = requestHandler;
            this.resourceHandler = resourceHandler;

            this.listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started. Listening to TCP clients at 127.0.0.1:{this.port}");

            var task = Task.Run(this.ListenLoop);
            task.Wait();
        }

        private async Task ListenLoop()
        {
            while(this.isRunning)
            {
                var client = await this.listener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, this.requestHandler, this.resourceHandler);
                await connectionHandler.ProcessRequestAsync();
            }
        }
    }
}
