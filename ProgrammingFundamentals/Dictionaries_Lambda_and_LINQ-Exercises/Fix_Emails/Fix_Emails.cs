using System;
using System.Collections.Generic;

namespace Fix_Emails
{
    public class Fix_Emails
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            string name = String.Empty;

            Dictionary<string, string> emails = new Dictionary<string, string>();

            while (line != "stop")
            {
                if (!line.Contains("@"))
                {
                    name = line;
                }
                else
                {
                    string email = line;

                    if (!CheckForUKOrUSEmail(email))
                        emails.Add(name, email);
                }

                line = Console.ReadLine();
            }

            foreach (KeyValuePair<string, string> pair in emails)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }

        public static bool CheckForUKOrUSEmail(string email)
        {
            string countryCode2 = email.Substring(email.Length - 2);

            if (countryCode2 == "uk" || countryCode2 == "us")
                return true;

            return false;
        }
    }
}
