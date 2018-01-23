using System;
using System.Collections.Generic;

namespace Phonebook_Upgrade
{
    public class Phonebook_Upgrade
    {
        public static void Main()
        {
            string[] entry = Console.ReadLine().Split(' ');

            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();

            while (entry[0] != "END")
            {
                if (entry[0] == "A")
                {
                    string name = entry[1];
                    string phone = entry[2];

                    if (phonebook.ContainsKey(name))
                        phonebook[name] = phone;
                    else
                        phonebook.Add(name, phone);
                }
                else if (entry[0] == "S")
                {
                    string name = entry[1];

                    if (phonebook.ContainsKey(name))
                        Console.WriteLine("{0} -> {1}", GetName(phonebook, name), phonebook[name]);
                    else
                        Console.WriteLine("Contact {0} does not exist.", name);
                }
                else
                {
                    foreach (KeyValuePair<string, string> pair in phonebook)
                    {
                        Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
                    }
                }

                entry = Console.ReadLine().Split(' ');
            }
        }

        public static string GetName(SortedDictionary<string, string> dic, string name)
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
