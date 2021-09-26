using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_1___Question_12
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Ask for name and give raise
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Ask for name, call raise function
        //Restrictions: None
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;

            Console.Write("Enter your name: ");
            sName = Console.ReadLine();

            if (GiveRaise(sName, ref dSalary) == true)
            {
                Console.WriteLine("Congratulations on your raise! Your salary is now {0}.", dSalary);
            }

        }

        //Method: GiveRaise
        //Purpose: Give a raise if name == myName, otherwise do nothing and return false
        //Restrictions: None
        static bool GiveRaise(string name, ref double salary)
        {
            if (name.Equals("Daniel"))
            {
                salary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
