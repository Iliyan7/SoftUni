﻿using System.Collections.Generic;
using WebServer.Server.Http.Contracts;

namespace WebServer.Server.Http
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

        public object Get(string key)
        {
            if(!this.values.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }

            return this.values[key];
        }

        public T Get<T>(string key)
        {
            return (T)this.Get(key);
        }

        public void Clear() => this.values.Clear();

        public bool Contains(string key) => this.values.ContainsKey(key);
    }
}
