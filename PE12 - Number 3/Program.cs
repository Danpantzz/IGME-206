using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE12___Number_3
{

    //Class: myClass
    //Purpose: Define string myString and GetString method
    //Restrictions: None
    public class myClass
    {
        private string myString = "String";

        public virtual string GetString()
        {
            return myString;
        }

        //Method: Main
        //Author: Daniel McErlean
        //Purpose: Create object of derivedClass to use getString
        //Restrictions: None
        static void Main(string[] args)
        {
            MyDervivedClass n = new MyDervivedClass();

            Console.Write(n.GetString());
        }
    }

    //Class: MyDerivedClass
    //Purpose: Override myClass method to add a string
    //Restrictions: None
    public class MyDervivedClass : myClass
    {

        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)\n";
        }
    }

}