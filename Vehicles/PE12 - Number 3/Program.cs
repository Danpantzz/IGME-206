using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE12___Number_3
{
    public class myClass
    {
        private string myString = "String";

        public virtual string GetString()
        {
            return myString;
        }

        static void Main(string[] args)
        {
            MyDervivedClass n = new MyDervivedClass();

            

            Console.Write(n.GetString());
        }
    }
    
    public class MyDervivedClass : myClass
    {

        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)\n";
        }
    }
    
}
