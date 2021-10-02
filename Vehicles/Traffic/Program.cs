using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void AddPassenger(IPassengerCarrier item)
        {
            Console.WriteLine(item.ToString());

            item.LoadPassenger();

        }
    }
}