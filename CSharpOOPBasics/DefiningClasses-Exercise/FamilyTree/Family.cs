using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Family
    {
        private string name;
        private string birthday;
        private List<Parent> parents;
        private List<Children> childrens;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
