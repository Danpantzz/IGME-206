using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkProblem5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 4 numbers:");

            int num1 = Convert.ToInt32(Console.Read());
            int num2 = Convert.ToInt32(Console.Read());
            int num3 = Convert.ToInt32(Console.Read());
            int num4 = Convert.ToInt32(Console.Read());

            Console.WriteLine(num1 + " " + num2 + " " + num3 + " " + num4);

        }
    }
}
