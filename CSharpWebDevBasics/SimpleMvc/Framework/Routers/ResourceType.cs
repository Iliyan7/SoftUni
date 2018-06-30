namespace Framework.Routers
{
    public class ResourceType
    {
        public ResourceType(string ext, string contentType, string folder)
        {
            this.Extension = ext;
            this.ContentType = contentType;
            this.Folder = folder;
        }

        public string Extension { get; private set; }

        public string ContentType { get; private set; }

        public string Folder { get; private set; }
    }
}
