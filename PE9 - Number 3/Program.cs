using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE9___Number_3
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Impersonate Console.ReadLine() function with delegate function
    //Restrictions: None
    class Program
    {
        delegate void ReadLine(string s);

        //Method: Main
        //Purpose: declare variables to help delegate function impersonate ReadLine() function
        //Restrictions: None
        static void Main(string[] args)
        {
            ReadLine reader;

            Console.Write("Write anything: ");
            reader = new ReadLine(Read);
            reader(Console.ReadLine());
        }

        //Method: Read
        //Purpose: Read in user input as the Console.ReadLine() function would
        //Restrictions: None
        static void Read(string s)
        {
            Console.WriteLine(s);
        }
    }
}
