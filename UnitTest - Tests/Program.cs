using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest___Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            byte byteVal;
            short shortVal = -556;
            byteVal = (byte)shortVal;
            Console.WriteLine("byteVal = {0}", byteVal);


        }
    }
}
