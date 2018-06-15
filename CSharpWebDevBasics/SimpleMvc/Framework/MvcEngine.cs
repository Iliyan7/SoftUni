using System;
using System.Reflection;
using WebServer;

namespace Framework
{
    public static class MvcEngine
    {
        public static void Run(HttpServer server)
        {
            RegisterAssemblyName();
            RegisterControllerData();
            RegisterViewsData();
            RegisterModelsData();

            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RegisterAssemblyName()
        {
            MvcContext.Instance.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
        }

        private static void RegisterControllerData()
        {
            MvcContext.Instance.ControllersFolder = "Controllers";
            MvcContext.Instance.ControllersSuffix = "Controller";
        }

        private static void RegisterViewsData()
        {
            MvcContext.Instance.ViewsFolder = "Views";
        }

        private static void RegisterModelsData()
        {
            MvcContext.Instance.ModelsFolder = "Models";
        }
    }
}
