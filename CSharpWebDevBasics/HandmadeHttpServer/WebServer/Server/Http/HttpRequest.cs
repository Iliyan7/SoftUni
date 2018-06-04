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
            this.Headers = new HttpHeaderCollection();
            this.FormData = new Dictionary<string, string>();

            this.ParseReuqest(requestString);
        }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public string Path { get; private set; }

        public IDictionary<string, string> UrlParameters { get; }

        public IDictionary<string, string> QueryParameters { get; }

        public IHttpHeaderCollection Headers { get; }

        public IDictionary<string, string> FormData { get; }

        public void AddUrlParameter(string key, string value)
        {
            this.UrlParameters[key] = value;
        }

        private void ParseReuqest(string requestString)
        {
            if (string.IsNullOrEmpty(requestString))
            {
                throw new BadRequestException("No request line");
            }

            var requestLines = requestString
                .Split(Environment.NewLine);

            var firstLine = requestLines[0].Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if(firstLine.Length != 3 || firstLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException("Invalid request line");
            }

            this.Method = this.ParseRequestMethod(firstLine[0]);
            this.Url = firstLine[1];
            this.Path = this.Url.Split(new char[] { '?', '#' }, StringSplitOptions.None)[0];
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
                throw new BadRequestException("Invalid request method");
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            var endIndex = Array.IndexOf(requestLines, string.Empty);

            for (int i = 1; i < endIndex; i++)
            {
                var headerArgs = requestLines[i]
                    .Split(": ");

                var headerKey = headerArgs[0];
                var headerValue = headerArgs[1];

                this.Headers[headerKey] = new HttpHeader(headerKey, headerValue);
            }

            if(!this.Headers.ContainsKey("Host"))
            {
                throw new BadRequestException("Host header is not present");
            }
        }

        private void ParseParameters()
        {
            if(!this.Url.Contains("?"))
            {
                return;
            }

            var query = this.Url.Split('?')[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, IDictionary<string, string> dict)
        {
            if(!query.Contains("="))
            {
                return;
            }

            var queryParis = query
                .Split('&');

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
