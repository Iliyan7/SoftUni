namespace _01HarestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    class HarvestingFieldsTest
    {
        static void Main(string[] args)
        {
            var type = typeof(HarvestingFields);
            var fieldsInfo = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "private": PrintFields(fieldsInfo.Where(f => f.IsPrivate).ToArray()); break;
                    case "protected": PrintFields(fieldsInfo.Where(f => f.IsFamily).ToArray()); break;
                    case "public": PrintFields(fieldsInfo.Where(f => f.IsPublic).ToArray()); break;
                    default: PrintFields(fieldsInfo); break;
                }
            }
        }

        private static void PrintFields(FieldInfo[] fieldsInfo)
        {
            foreach (var field in fieldsInfo)
            {
                Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
