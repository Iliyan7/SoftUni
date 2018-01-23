using System;
using System.Collections.Generic;

namespace Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            string[] entry = Console.ReadLine().Split(' ');

            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (entry[0] != "END")
            {
                string name = entry[1];

                if (entry[0] == "A")
                {
                    string phone = entry[2];

                    if (phonebook.ContainsKey(name))
                        phonebook[name] = phone;
                    else
                        phonebook.Add(name, phone);
                }
                else
                {
                    if (phonebook.ContainsKey(name))
                        Console.WriteLine("{0} -> {1}", GetName(phonebook, name), phonebook[name]);
                    else
                        Console.WriteLine("Contact {0} does not exist.", name);
                }

                entry = Console.ReadLine().Split(' ');
            }
        }

        public static string GetName(Dictionary<string, string> dic, string name)
        {
            string tempName = String.Empty;

            foreach (var pair in dic)
            {
                if (pair.Key == name)
                {
                    tempName = name;
                }
            }

            return tempName;
        }
    }
}
