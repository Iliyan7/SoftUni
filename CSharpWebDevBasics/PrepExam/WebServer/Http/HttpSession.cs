using System.Collections.Generic;
using WebServer.Http.Contracts;

namespace WebServer.Http
{
    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> values;

        public HttpSession(string id)
        {
            this.Id = id;
            this.values = new Dictionary<string, object>();
        }

        public string Id { get; private set; }

        public void Add(string key, object value)
        {
            this.values[key] = value;
        }

        public void Remove(string key)
        {
            this.values.Remove(key);
        }

        public object Get(string key) => this.values[key];

        public void Clear() => this.values.Clear();

        public bool Contains(string key) => this.values.ContainsKey(key);
    }
}
