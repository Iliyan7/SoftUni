namespace BirthdayCelebrations
{
    public class Pet : IBirthday
    {
        private string name;
        private string birthday;

        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                this.name = value;
            }
        }

        public string Birthday
        {
            get { return this.birthday; }
            private set
            {
                this.birthday = value;
            }
        }
    }
}
