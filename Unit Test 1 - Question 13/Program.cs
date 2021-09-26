using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_1___Question_13
{

    //Struct: Employee
    //Purpose: Declare employee variables
    //Restrictions: None
    struct employee
    {
        public string sName;
        public double dSalary;
    }

    //Class: Program
    //Author: Daniel McErlean
    //Purpose: declare and raise salary of type employee
    //Restrictions: None
    class Program
    {
        
        static employee me = new employee();

        //Method: Main
        //Purpose: Raise salary of employee me with my name
        //Restrictions: None
        static void Main(string[] args)
        {

            Console.Write("Enter your name: ");
            me.sName = Console.ReadLine();
            me.dSalary = 30000;

            if (GiveRaise(me) == true)
            {
                Console.WriteLine("Congratulations on your raise! Your salary is now {0}.", me.dSalary);
            }
            
        }

        //Method: GiveRaise
        //Purpose: Check to see if name == "Daniel", then give raise
        //Restrictions: None
        static bool GiveRaise(employee person)
        {
            if (person.sName == "Daniel")
            {
                me.dSalary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}