namespace WebServer.Http.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        void Add(string key, object value);

        void Remove(string key);

        object Get(string key);

        void Clear();

        bool Contains(string key);
    }
}
