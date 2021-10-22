using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_2___Question_8_10
{
    //Class: Program
    //Purpose: Main method and MyMethod method
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Author: Daniel McErlean
        //Purpose: Create two objects and pass them to MyMethod
        //Restrictions: None
        static void Main(string[] args)
        {
            Xbox xbox = new Xbox();
            NintendoSwitch nintendoSwitch = new NintendoSwitch();

            MyMethod(xbox);
            MyMethod(nintendoSwitch);
        }

        //Method: MyMethod
        //Purpose: call object methods based on type of object
        //Restrictions: None
        static void MyMethod(object obj)
        {
            if (obj.GetType() == typeof(Xbox))
            {
                Xbox xbox = (Xbox)obj;

                xbox.ConsoleName();
                xbox.InsertGame();
                xbox.PlayGame();

                Console.WriteLine("");
            }
            else if (obj.GetType() == typeof(NintendoSwitch))
            {
                NintendoSwitch nintendoSwitch = (NintendoSwitch)obj;

                nintendoSwitch.ConsoleName();
                nintendoSwitch.InsertGame();
                nintendoSwitch.LeaveHouse();
                nintendoSwitch.PlayGame();

                Console.WriteLine("");
            }
        }
    }

    //Abstract class: VideoGame
    //Purpose: Base for derived classes
    //Restrictions: None
    public abstract class VideoGame
    {
        private string gameName;

        public string GameName
        {
            get
            {
                return this.gameName;
            }
            set
            {
                this.gameName = value;
            }
        }

        public abstract void ConsoleName();

        public virtual void InsertGame() 
        {
            Console.WriteLine("You insert the game.");
        }
    }

    //Interface: IConsole
    //Purpose: Use for classes that are consoles
    //Restrictions: None
    public interface IConsole
    {
        void PlayGame();
    }

    //Interface: IHandheld
    //Purpose: Use for classes that are handhelds
    //Restrictions: None
    public interface IHandheld
    {
        void PlayGame();
        void LeaveHouse();
    }

    //Class: Xbox
    //Purpose: Inherets VideoGame and IConsole, uses methods to simulate playing a game
    //Restrictions: None
    public class Xbox : VideoGame, IConsole
    {
        public void PlayGame() 
        {
            GameName = "Sea of Thieves";
            Console.WriteLine("You play the game: " + GameName);
        }

        public override void ConsoleName() 
        {
            Console.WriteLine("You are playing the Xbox.");
        }
        public override void InsertGame()
        {
            Console.WriteLine("You insert the game in the form of a disk.");
        }
    }

    //Class: NintendoSwitch
    //Purpose: Inherets VideoGame and IHandheld, uses methods to simulate playing a game
    public class NintendoSwitch : VideoGame, IHandheld
    {
        public void PlayGame() 
        {
            GameName = "Pokemon Sword";
            Console.WriteLine("You play the game: " + GameName);
        }
        public void LeaveHouse() 
        {
            Console.WriteLine("Leaving the house...");
        }
        public override void ConsoleName() 
        {
            Console.WriteLine("You are playing the Nintendo Switch.");
        }
        public override void InsertGame()
        {
            Console.WriteLine("You insert the game in the form of a cartdridge.");
        }
    }
}