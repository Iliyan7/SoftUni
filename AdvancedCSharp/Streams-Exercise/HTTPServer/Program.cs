using System;
using System.IO;
using System.Net;
using System.Text;

namespace HTTPServer
{
    public class Program
    {
        public static void Main()
        {
            var server = new HttpListener();
            server.Prefixes.Add("http://localhost:8081/");

            server.Start();
            Console.WriteLine("HTTP Server is running...");

            while (true)
            {
                var context = server.GetContext();
                var request = context.Request;
                var response = context.Response;

                var htmlContent = String.Empty;

                switch (request.RawUrl)
                {
                    case "/":
                        {
                            htmlContent = File.ReadAllText("views/index.html");
                            break;
                        }
                    case "/info":
                        {
                            htmlContent = ReadFormatedText("views/info.html");
                            break;
                        }
                    default:
                        {
                            htmlContent = File.ReadAllText("views/error.html");
                            break;
                        }
                }

                var buffer = Encoding.UTF8.GetBytes(htmlContent);

                response.ContentLength64 = buffer.Length;
                var outputStream = response.OutputStream;
                outputStream.Write(buffer, 0, buffer.Length);

                context.Response.Close();
            }
        }

        private static string ReadFormatedText(string path)
        {
            var sb = new StringBuilder();

            using (var reader = new StreamReader(path))
            {
                var line = reader.ReadLine();
 
                while (line != null)
                {
                    if (line.Contains("{0}"))
                    {
                        line = line.Replace("{0}", DateTime.Now.ToString());
                    }
                    else if(line.Contains("{1}"))
                    {
                        line = line.Replace("{1}", Environment.ProcessorCount.ToString());
                    }

                    sb.Append(line);

                    line = reader.ReadLine();
                }
            }

            return sb.ToString();
        }
    }
}
