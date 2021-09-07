using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4_Question2
{

    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Assignment PE4-2
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Ask user for two numbers
        //          Ask again if one or both numbers are greater than 10
        //Restrictions: None
        static void Main(string[] args)
        {

            //User enters in num1
            Console.WriteLine("Enter a number less than or equal to 10: ");
            string string1 = Console.ReadLine();

            //User enters num2
            Console.WriteLine("Enter another number less than or equal to 10: ");
            string string2 = Console.ReadLine();

            //Converts strings to integers
            int num1 = Convert.ToInt32(string1);
            int num2 = Convert.ToInt32(string2);

            //Uses and operator to see if num1 and num2 are both greater than 10
            while (((num1 > 10) && (num2 > 10)))
            { 
                Console.WriteLine("Both numbers were greater than 10! Enter a different number 1: ");
                string1 = Console.ReadLine();
                num1 = Convert.ToInt32(string1);
                Console.WriteLine("Enter a different number 2: ");
                string2 = Console.ReadLine();
                num2 = Convert.ToInt32(string2);
                continue;
            }

            //Writes num1 and num2 to the console
            Console.WriteLine(num1 + " " + num2);






        }
    }
}
