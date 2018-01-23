using System;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Town { get; private set; }

        public int CompareTo(Person other)
        {
            var nameResult = this.Name.CompareTo(other.Name);
            if(nameResult == 0)
            {
                var ageResult = this.Age.CompareTo(other.Age);

                if(ageResult == 0)
                {
                    return this.Town.CompareTo(other.Town);
                }

                return ageResult;
            }

            return nameResult;
        }
    }
}
