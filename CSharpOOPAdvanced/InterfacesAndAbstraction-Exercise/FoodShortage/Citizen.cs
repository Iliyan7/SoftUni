namespace FoodShortage
{
    public class Citizen : IPerson, IIdentifiable, IBirthday, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthday;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
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

        public int Age
        {
            get { return this.age; }
            private set
            {
                this.age = value;
            }
        }

        public string Id
        {
            get { return this.id; }
            private set
            {
                this.id = value;
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

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}