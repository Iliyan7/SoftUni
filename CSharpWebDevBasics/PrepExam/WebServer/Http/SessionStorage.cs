using System.Collections.Concurrent;

namespace WebServer.Http
{
    public static class SessionStorage
    {
        public const string SessionCookieKey = "cid";

        private static readonly ConcurrentDictionary<string, HttpSession> sessions = new ConcurrentDictionary<string, HttpSession>();

        public static HttpSession GetSession(string id)
        {
            return sessions.GetOrAdd(id, _ => new HttpSession(id));
        }
    }
}
