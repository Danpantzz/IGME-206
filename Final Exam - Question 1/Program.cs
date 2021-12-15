using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Exam___Question_1
{
    class Program
    {

        static void Main(string[] args)
        {
            string sSentence = null;
            int[] charCount = new int[26];

            Random rand = new Random();

            Console.Write("Enter a sentence: ");
            sSentence = Console.ReadLine();

            foreach (char c in sSentence.ToLower())
            {
                if (Char.IsLetter(c))
                {
                    ++charCount[c - 'a'];

                }
            }

            Console.WriteLine("Character counts:");

            for (int i = 0; i < charCount.Length; ++i)
            {
                Console.WriteLine($"{(char)(i + 'a')}: {charCount[i]}");
            }
        }
    }
}