using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var emails = new Dictionary<string, string>();

            var i = 1;
            var name = input;

            while(input != "stop")
            {
                if (i % 2 != 0)
                {
                    name = input;
                    emails.Add(name, String.Empty);
                }
                else
                {
                    emails[name] = input;
                }

                input = Console.ReadLine();
                i++;
            }

            foreach (var email in emails)
            {
                var len = email.Value.Length;
                var domain = email.Value.Substring(len - 2);

                if (domain.Equals("us") || domain.Equals("uk"))
                    continue;

                Console.WriteLine("{0} -> {1}", email.Key, email.Value);
            }
        }
    }
}
