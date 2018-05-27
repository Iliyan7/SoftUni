using System;
using System.Collections.Generic;
using System.Net;
using WebServer.Server.Enums;
using WebServer.Server.Exepctions;
using WebServer.Server.Http.Contracts;

namespace WebServer.Server.Http
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.HeaderCollection = new HttpHeaderCollection();
            this.FormData = new Dictionary<string, string>();

            this.ParseReuqest(requestString);
        }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public string Path { get; private set; }

        public IDictionary<string, string> UrlParameters { get; }

        public IDictionary<string, string> QueryParameters { get; }

        public IHttpHeaderCollection HeaderCollection { get; }

        public IDictionary<string, string> FormData { get; }

        public void AddUrlParameter(string key, string value)
        {
            this.UrlParameters[key] = value;
        }

        private void ParseReuqest(string requestString)
        {
            var requestLines = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var firstLine = requestLines[0].Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if(requestLines.Length != 3 || firstLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException("Invalid request line");
            }

            this.Method = this.ParseRequestMethod(firstLine[0]);
            this.Url = firstLine[1];
            this.Path = this.Url.Substring(0, this.Url.IndexOfAny(new char[] { '?', '#' }));
            this.ParseHeaders(requestLines);
            this.ParseParameters();

            if (this.Method == HttpRequestMethod.Post)
            {
                this.ParseQuery(requestLines[requestLines.Length - 1], this.FormData);
            }
        }

        private HttpRequestMethod ParseRequestMethod(string method)
        {
            try
            {
                return Enum.Parse<HttpRequestMethod>(method, true);
            }
            catch (Exception)
            {
                throw new BadRequestException("Invalid request line");
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            var endIndex = Array.IndexOf(requestLines, string.Empty);

            for (int i = 0; i < endIndex; i++)
            {
                var headerArgs = requestLines[i]
                    .Split(": ");

                var headerKey = headerArgs[0];
                var headerValue = headerArgs[1];

                this.HeaderCollection[headerKey] = new HttpHeader(headerKey, headerValue);
            }

            if(!this.HeaderCollection.ContainsKey("Host"))
            {
                throw new BadRequestException("Invalid request line");
            }
        }

        private void ParseParameters()
        {
            if(this.Url.Contains("?"))
            {
                return;
            }

            string query = this.Url.Split('?')[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, IDictionary<string, string> dict)
        {
            if(!query.Contains("="))
            {
                return;
            }

            var queryParis = query.Split('&');
            foreach (var queryPair in queryParis)
            {
                var queryArgs = queryPair
                    .Split('=');

                if(queryArgs.Length != 2)
                {
                    continue;
                }

                dict.Add(WebUtility.UrlDecode(queryArgs[0]), WebUtility.UrlDecode(queryArgs[1]));
            }
        }
    }
}
