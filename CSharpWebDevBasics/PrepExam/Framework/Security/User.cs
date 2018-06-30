namespace Framework.Security
{
    public class User
    {
        public const string UserIdKey = "userid";
        public const string UsernameKey = "username";

        internal User()
        {
            this.IsAuthenticated = false;
        }

        internal User(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.IsAuthenticated = true;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public bool IsAuthenticated { get; private set; } 
    }
}
