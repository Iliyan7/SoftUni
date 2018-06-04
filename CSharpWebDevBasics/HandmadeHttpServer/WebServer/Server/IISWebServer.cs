using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using WebServer.Server.Contracts;
using WebServer.Server.Routing;
using WebServer.Server.Routing.Contracts;

namespace WebServer.Server
{
    public class IISWebServer : IRunnable
    {
        private readonly int port;

        private readonly IServerRouteConfig serverRouteConfig;

        private readonly TcpListener tcpListener;

        private bool isRunning;

        public IISWebServer(int port, IAppRouteConfig routeConfig)
        {
            this.port = port;
            this.serverRouteConfig = new ServerRouteConfig(routeConfig);

            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
        }

        public void Run()
        {
            this.tcpListener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started. Listening to TCP clients at 127.0.0.1:{this.port}");

            Task task = Task.Run(this.ListenLoop);
            task.Wait();
        }

        private async Task ListenLoop()
        {
            while(this.isRunning)
            {
                var client = await this.tcpListener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, this.serverRouteConfig);
                await connectionHandler.ProcessRequestAsync();
            }
        }
    }
}
