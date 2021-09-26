using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_1___Question_3
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Use a delegate method to impersonate Console.ReadLine()
    //Restrictions: None
    class Program
    {

        delegate string Read();

        //Method: Main
        //Purpose: use delegate method to ask for user input
        //Restrictions: None
        static void Main(string[] args)
        {

            Read read = new Read(ReadLine);

            Console.Write("write anything! ");

            string anything = read();

            Console.WriteLine(anything);


        }

        //Method: ReadLine()
        //Purpose: Used to impersonate Console.ReadLine()
        //Restrictions: None
        static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
