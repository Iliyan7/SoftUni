using System;
using System.Reflection;
using WebServer;

namespace Framework
{
    public static class MvcEngine
    {
        public static void Run(HttpServer server)
        {
            RegisterMvcContext(MvcContext.Instance);

            while (true)
            {
                try
                {
                    server.Run();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void RegisterMvcContext(MvcContext context)
        {
            context.AssemblyName = Assembly
                .GetEntryAssembly()
                .GetName()
                .Name;

            context.ControllersFolder = "Controllers";
            context.ControllersSuffix = "Controller";
            context.ViewsFolder = "Views";
            context.ModelsFolder = "Models";
            context.ResourceFolder = "Resources";
        }
    }
}
