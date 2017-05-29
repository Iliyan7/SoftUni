using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSymbols
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var symbols = new SortedDictionary<char, int>();

            foreach (var symbol in text)
            {
                if (!symbols.ContainsKey(symbol))
                    symbols.Add(symbol, 0);

                symbols[symbol]++;
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine("{0}: {1} time/s", symbol.Key, symbol.Value);
            }
        }
    }
}
