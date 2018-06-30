using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebServer.Enums;
using WebServer.Exepctions;
using WebServer.Http.Contracts;

namespace WebServer.Http
{
    public class HttpRequest : IHttpRequest
    {
        private readonly string requestString;

        public HttpRequest(string requestString)
        {
            this.requestString = requestString;

            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.FormData = new Dictionary<string, string>();

            this.ParseReuqest(requestString);
        }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public string Path { get; private set; }

        public IDictionary<string, string> UrlParameters { get; }

        public IDictionary<string, string> QueryParameters { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public IHttpSession Session { get; set; }

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

            var firstLine = requestLines[0]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if(firstLine.Length != 3 || firstLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException("Invalid request line");
            }

            this.Method = this.ParseRequestMethod(firstLine[0]);
            this.Url = firstLine[1];
            this.Path = this.Url.Split(new char[] { '?', '#' }, StringSplitOptions.None)[0];

            this.ParseHeaders(requestLines);
            this.ParseCookies();
            this.ParseParameters();

            if (this.Method == HttpRequestMethod.Post)
            {
                this.ParseQuery(requestLines[requestLines.Length - 1], this.FormData);
            }

            this.SetSession();
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

                this.Headers.Add(new HttpHeader(headerKey, headerValue));
            }

            if(!this.Headers.ContainsKey("Host"))
            {
                throw new BadRequestException("Host header is not present");
            }
        }

        private void ParseCookies()
        {
            if(this.Headers.ContainsKey("Cookie"))
            {
                var allCookieHeaders = this.Headers.GetHeaders("Cookie");

                foreach (var cookieHeader in allCookieHeaders)
                {
                    var cookies = cookieHeader
                        .Value
                        .Split("; ")
                        .ToList();

                    foreach (var cookie in cookies)
                    {
                        if (!cookie.Contains('='))
                        {
                            continue;
                        }

                        var args = cookie
                            .Split('=');

                        this.Cookies.Add(new HttpCookie(args[0], args[1], false));
                    }
                }
            }
        }

        private void ParseParameters()
        {
            if(!this.Url.Contains("?"))
            {
                return;
            }

            var query = this.Url.Split('?')[1];
            this.ParseQuery(query, this.UrlParameters);
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

        private void SetSession()
        {
            if(this.Cookies.ContainsKey(SessionStorage.SessionCookieKey))
            {
                var sessionCookie = this.Cookies.GetCookie(SessionStorage.SessionCookieKey);
                var sessionId = sessionCookie.Value;

                this.Session = SessionStorage.GetSession(sessionId);
            }
        }

        public override string ToString()
        {
            return this.requestString;
        }
    }
}
