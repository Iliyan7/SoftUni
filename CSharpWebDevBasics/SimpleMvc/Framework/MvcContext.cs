namespace Framework
{
    public class MvcContext
    {
        private static MvcContext instance;
        private static readonly object instanceLock = new object();

        private MvcContext()
        {

        }

        public static MvcContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (instanceLock)
                    {
                        if(instance == null)
                        {
                            instance = new MvcContext();
                        }
                    }
                }

                return instance;
            }
        }

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
    }
}
