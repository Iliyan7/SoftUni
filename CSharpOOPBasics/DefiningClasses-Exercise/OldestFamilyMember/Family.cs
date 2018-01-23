using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            this.members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            this.members = this.members
                .OrderByDescending(x => x.Age)
                .ToList();

            return this.members
                .First();
        }
    }
}
