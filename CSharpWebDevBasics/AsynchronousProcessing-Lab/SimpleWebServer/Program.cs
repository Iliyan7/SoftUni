using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = IPAddress.Parse("127.0.0.1");
            var port = 3456;

            var listener = new TcpListener(address, port);
            listener.Start();

            Console.WriteLine("Server Started.");

            var task = ConnectWithTcpClientAsync(listener);
            task.Wait();
        }

        private static async Task ConnectWithTcpClientAsync(TcpListener listener)
        {
            while(true)
            {
                Console.WriteLine("Waiting for client...");
                var client =  await listener.AcceptTcpClientAsync();

                Console.WriteLine("Client Connected.");

                var buffer = new byte[1024];
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);

                Console.WriteLine(Encoding.ASCII.GetString(buffer));

                var data = Encoding.ASCII.GetBytes(GetResponseString());
                await client.GetStream().WriteAsync(data, 0, data.Length);

                Console.WriteLine("Closing connection.");
                client.GetStream().Dispose();
            }
        }

        private static string GetResponseString()
        {
            var responseBody = new StringBuilder();
            responseBody.AppendLine("<html>");
            responseBody.AppendLine("<head>");
            responseBody.AppendLine("</head>");
            responseBody.AppendLine("<body>");
            responseBody.AppendLine("Hello from Server!");
            responseBody.AppendLine("</body>");
            responseBody.AppendLine("</html>");

            var responseHeaders = new StringBuilder();

            responseHeaders.AppendLine("HTTP/1.1 200 OK");
            responseHeaders.AppendLine("Content-Type: text/html; charset=utf-8");
            responseHeaders.AppendLine($"Content-Length: {responseBody.Length}");
            responseHeaders.AppendLine("");
            responseHeaders.AppendLine(responseBody.ToString());

            return responseHeaders.ToString();
        }
    }
}
