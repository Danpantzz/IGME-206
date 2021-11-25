using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_3___Question_7
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Create main method to Add wizard objects to the list wizards, then sort list
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Add wizard objects to the list wizards, then sort list
        //Restrictions: None
        static void Main(string[] args)
        {
            List<Wizard> wizards = new List<Wizard>();

            Wizard wizard1 = new Wizard("Dan", 500);
            Wizard wizard2 = new Wizard("Rob", 499);
            Wizard wizard3 = new Wizard("Dave", 340);
            Wizard wizard4 = new Wizard("Joe", 50);
            Wizard wizard5 = new Wizard("Adam", 76);
            Wizard wizard6 = new Wizard("Sarah", 134);
            Wizard wizard7 = new Wizard("Greg", 5000);
            Wizard wizard8 = new Wizard("Meg", 5);
            Wizard wizard9 = new Wizard("Carol", 23);
            Wizard wizard10 = new Wizard("Winston", 289);

            wizards.Add(wizard1);
            wizards.Add(wizard2);
            wizards.Add(wizard3);
            wizards.Add(wizard4);
            wizards.Add(wizard5);
            wizards.Add(wizard6);
            wizards.Add(wizard7);
            wizards.Add(wizard8);
            wizards.Add(wizard9);
            wizards.Add(wizard10);

            wizards.Sort();

            for (int i = 0; i < wizards.Count(); i++)
            {
                Console.WriteLine(wizards[i]);
            }


        }
    }

    //Class: Wizard
    //Author: Daniel McErlean
    //Purpose: Used for creating Wizard objects
    //Restrictions: None
    class Wizard : IComparable<Wizard>
    {
        string name;
        int age;

        //Method: Wizard
        //Purpose: Constructor for Wizard Class
        //Restrictions: None
        public Wizard(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        //Method: CompareTo
        //Purpose: Tells the Sort() method what field in the Wizard objects to compare
        //Restrictions: None
        public int CompareTo(Wizard other)
        {
            return this.age.CompareTo(other.age);
        }

        //Method: ToString
        //Purpose: Override ToString() method to output the objects in a comprehensible manner
        //Restrictions: None
        public override string ToString()
        {
            return ("Name: " + name + " Age: " + age);
        }

    }
}