namespace FamilyTree
{
    public class Parent
    {
        private string name;
        private string birthday;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }
    }
}