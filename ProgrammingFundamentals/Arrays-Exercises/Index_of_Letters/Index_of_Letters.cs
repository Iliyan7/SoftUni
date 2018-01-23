using System;

namespace Index_of_Letters
{
    public class Index_of_Letters
    {
        public static void Main()
        {
            string lettersWord = Console.ReadLine();

            for (int i = 0; i < lettersWord.Length; i++)
            {
                Console.WriteLine("{0} -> {1}", lettersWord[i], lettersWord[i] - 'a');
            }
        }
    }
}
