namespace WebServer.Server.Http.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        void Add(string key, object value);

        object Get(string key);

        T Get<T>(string key);

        void Clear();

        bool Contains(string key);
    }
}
