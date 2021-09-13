using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___number_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string reverse = "";
            int i;
            int length;


            Console.Write("Enter a string: ");
            userInput = Console.ReadLine();
            length = userInput.Length;

            for (i = 0; i < length; i++)
            {
                reverse += userInput.ElementAt((length - 1) - i);
            }

            Console.WriteLine("Your string, reversed: {0}", reverse);

        }
    }
}
