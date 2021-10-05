using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    //Class: Program
    //Purpose: Run the program
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Author: Daniel McErlean
        //Purpose: Create objects and random number generator to add pets to list, and complete random actions.
        //Restrictions: None
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();

            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        string name;
                        int age;
                        string license;

                        Console.WriteLine("You bought a dog!");


                        Console.Write("Dog's name: ");
                        name = Console.ReadLine();

                        error1:

                        Console.Write("Age: ");

                        try
                        {
                            age = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Error. Enter a number.");
                            goto error1;
                        }

                        Console.Write("License: ");
                        license = Console.ReadLine();

                        dog = new Dog(license, name, age);
                        dog.Name = name;
                        pets.Add(dog);
                    }
                    else
                    {
                        string name;
                        int age;
                        

                        Console.WriteLine("You bought a cat!");

                        Console.Write("Cat's name: ");
                        name = Console.ReadLine();

                        error2:

                        Console.Write("Age: ");

                        try
                        {
                            age = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Error. Enter a number.");
                            goto error2;
                        }

                        cat = new Cat();
                        cat.Name = name;
                        cat.age = age;
                        pets.Add(cat);

                    }
                }
                else
                {
                    thisPet = pets[rand.Next(0, pets.Count)];
                    if (thisPet == null)
                    {
                        continue;
                    }
                    if (thisPet.GetType().ToString() == ("PetApp.Dog"))
                    {
                        iDog = (IDog)thisPet;
                        int r = rand.Next(0, 5);

                        Console.Write("{0}: ", dog.Name);

                        if (r == 0)
                        {
                            iDog.Eat();
                        }
                        if (r == 1)
                        {
                            iDog.Play();
                        }
                        if (r == 2)
                        {
                            iDog.Bark();
                        }
                        if (r == 3)
                        {
                            iDog.NeedWalk();
                        }
                        if (r == 4)
                        {
                            iDog.GotoVet();
                        }
                    }
                    else
                    {
                        iCat = (ICat)thisPet;
                        int r = rand.Next(0, 4);

                        Console.Write("{0}: ", cat.Name);

                        if (r == 0)
                        {
                            iCat.Eat();
                        }
                        if (r == 1)
                        {
                            iCat.Play();
                        }
                        if (r == 2)
                        {
                            iCat.Purr();
                        }
                        if (r == 3)
                        {
                            iCat.Scratch();
                        }
                    }
                }

            }

        }
    }

    //Class: Pet
    //Purpose: Declare the abstract class for use in other classes
    //Restrictions: None
    public abstract class Pet
    {
        private string name;

        public string Name;
        public int age;

        public Pet() { }

        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public abstract void Eat();

        public abstract void Play();

        public abstract void GotoVet();

    }

    //Class: Pets
    //Purpose: Store pet information in a list
    //Restrictions: None
    public class Pets
    {
        public List<Pet> petList = new List<Pet>();

        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        public int Count
        {
            get
            {
                return petList.Count;
            }
        }

        public void Add(Pet pet)
        {
            petList.Add(pet);
        }

        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }

        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }

    }

    //Interface: ICat
    public interface ICat
    {
        void Eat(); 
        void Play(); 
        void Scratch(); 
        void Purr(); 

    }

    //Interface: IDog
    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();

    }

    //Class: Cat
    //Purpose: Available to a cat object to use methods
    //Restrictions: None
    public class Cat : Pet, ICat
    {
        public override void Eat()
        {
            Console.WriteLine("Mmm. Lasagna.");
        }
        public override void Play()
        {
            Console.WriteLine("Activating laser pointer mode...");
        }
        public override void GotoVet()
        {
            Console.WriteLine("Yeah, no vet for me, thanks.");
        }
        public void Purr()
        {
            Console.WriteLine("Finally comfy, prrr...");
        }
        public void Scratch()
        {
            Console.WriteLine("Hiss! You can pet, but don't touch me!");
        }

        public Cat() { }
    }

    //Class: Dog
    //Purpose: Available to dog objects to use methods
    //Restrictions: None
    public class Dog : Pet, IDog
    {
        public string license;

        public override void Eat()
        {
            Console.WriteLine("Now this is some good cuisine!");
        }
        public override void Play()
        {
            Console.WriteLine("Where? Ball?");
        }
        public override void GotoVet()
        {
            Console.WriteLine("I thought we were going to the park...");
        }
        public void Bark()
        {
            Console.WriteLine("Bark bark! I can do this all day.");
        }
        public void NeedWalk()
        {
            Console.WriteLine("I gotta get out NOW");
        }

        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
        {
            this.license = szLicense;
        }
    }

}