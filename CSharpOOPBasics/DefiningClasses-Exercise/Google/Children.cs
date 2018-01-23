namespace Google
{
    public class Children
    {
        private string name;
        private string birthday;

        public Children(string childrenName, string childrenBirthday)
        {
            this.name = childrenName;
            this.birthday = childrenBirthday;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Birthday
        {
            get { return this.birthday; }
        }
    }
}