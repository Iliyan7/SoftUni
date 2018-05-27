namespace WebServer.Server.Http.Contracts
{
    public interface IHttpHeaderCollection
    {
        HttpHeader this[string key] { get; set; }

        void Add(HttpHeader header);

        bool ContainsKey(string key);

        HttpHeader GetHeader(string key);
    }
}
