using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___number_5
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Calculate z
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Use formula z = 3y^2 + 2x - 1 to calculate z
        //          for the range: -1 <= x <= 1 in .1 increments
        //                          1 <= y <= 4 in .1 increments
        //Resitrictions: None
        static void Main(string[] args)
        {
            double[,,] zCalculated = new double[20,30,3];
            int i = 0;
            int j = 0;
            int k = 0;
            double x = -1;
            double y = 1;
            double z = 0;


            for (i = 0; i < 20; i++)
            {
                y = 1;
                for (j = 0; j < 30; j++)
                {

                    z = (3 * (y * y)) + (2 * x) - 1;

                    zCalculated[i, j, 0] = x;
                    zCalculated[i, j, 1] = y;
                    zCalculated[i, j, 2] = z;

                    y += .1;
                }
                x += .1;
            }

            for (i = 0; i < 20; i++)
            {
                for (j = 0; j < 30; j++)
                {

                    Console.WriteLine("z = " + zCalculated[i, j, 2]);
                }
            }

        }
    }
}
