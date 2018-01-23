namespace Google
{
    public class Parent
    {
        private string name;
        private string birthday;

        public Parent(string parentName, string parentBirthday)
        {
            this.name = parentName;
            this.birthday = parentBirthday;
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