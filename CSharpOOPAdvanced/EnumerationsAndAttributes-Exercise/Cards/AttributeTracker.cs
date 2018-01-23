using System;
using System.Linq;

namespace Cards
{
    public class AttributeTracker
    {
        public void PrintEnumDescriptionByRank(string category)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    var attrs = type.GetCustomAttributes(typeof(TypeAttribute), false);

                    foreach (TypeAttribute attr in attrs.Where(a => (a as TypeAttribute).Category == category))
                    {
                        Console.WriteLine($"Type = {attr.Type}, Description = {attr.Description}");
                    }
                }
            }
        }
    }
}
