namespace BorderControl
{
    public class Pet : IIdentifiable
    {
        private string name;
        private int age;
        private string id;

        public Pet(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
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
    }
}
