using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE14___Number_3
{
    //Class: Program
    //Purpose: Main method and MyMethod to create objects and call from interface
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Author: Daniel McErlean
        //Purpose: Create objects and pass them to MyMethod
        //Restrictions: None
        static void Main(string[] args)
        {
            NumberOne obj1 = new NumberOne();
            NumberTwo obj2 = new NumberTwo();

            MyMethod(obj1);
            MyMethod(obj2);

        }

        //Method: MyMethod
        //Author: Daniel McErlean
        //Purpose: Cast myObject to the interface and call its method, DoSomething()
        //Restrictions: None
        public static void MyMethod(object myObject)
        {
            MyInterface inter = null;

            inter = (MyInterface)myObject;
            inter.DoSomething();
        }
    }

    //Class: NumberOne
    //Purpose: Use MyInterface's method to write a string to the console
    //Restrictions: None
   public class NumberOne : MyInterface
    {
        public void DoSomething()
        {
            Console.WriteLine("Did something in class NumberOne.");
        }
    }

    //Class: NumberTwo
    //Purpose: Use MyInterface's method to write a string to the console
    //Restrictions: None
    public class NumberTwo : MyInterface
    {
        public void DoSomething()
        {
            Console.WriteLine("Did something in class NumberTwo.");
        }
    }

    //interface: MyInterface
    //Purpose: Create method DoSomething to use in two classes
    //Restrictions: None
    public interface MyInterface
    {
        void DoSomething();
    }
}
