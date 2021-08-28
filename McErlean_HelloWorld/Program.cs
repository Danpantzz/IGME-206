using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McErlean_HelloWorld
{
    // Class: Program
    // Author: Daniel McErlean
    // Purpose: Output text and a variable to the console.
    // Restrictions: None
    static class Program
    {

        // Method: Main
        // Purpose: Write personal name to the console
        //          Multiply 2 numbers and output to console
        // Restrictions: None
        static void Main(string[] args)
        {
            // Writes name to console
            Console.WriteLine("Daniel McErlean");

            // stores numbers 7 and 4 into variables num1 and num2
            int num1 = 7;
            int num2 = 4;

            // Multiplies num1 and num2 and stores them in the variable "product"
            int product = num1 * num2;

            // Outputs the variable "product" to the console
            Console.WriteLine("The product of " + num1 + " and " + num2 + " is: " + product);

        }
    }
}