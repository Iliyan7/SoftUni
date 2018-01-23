namespace CompanyRoster
{
    public class Employee
    {
        private string name;
        private double salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public Employee(string name, double salary, string position, string department, string email, int age)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = email;
            this.age = age;
        }

        public double Salary
        {
            get
            {
                return salary;
            }
        }

        public string Department
        {
            get
            {
                return this.department;
            }
        }

        public string GetInfo()
        {
            return string.Format("{0} {1:F2} {2} {3}", this.name, this.Salary, this.email, this.age);
        }
    }
}
