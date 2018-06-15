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

        private readonly IHandleable mvcRequestHandler;

        private readonly TcpListener tcpListener;

        private bool isRunning;

        public HttpServer(int port, IHandleable mvcRequestHandler)
        {
            this.port = port;
            this.mvcRequestHandler = mvcRequestHandler;

            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
        }

        public void Run()
        {
            this.tcpListener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started. Listening to TCP clients at 127.0.0.1:{this.port}");

            var task = Task.Run(this.ListenLoop);
            task.Wait();
        }

        private async Task ListenLoop()
        {
            while(this.isRunning)
            {
                var client = await this.tcpListener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, this.mvcRequestHandler);
                await connectionHandler.ProcessRequestAsync();
            }
        }
    }
}
