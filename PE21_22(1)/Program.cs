using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace PE21_22
{

    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }

    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Creates a matrix and list to represent the maze in "Don't Die"
    static class Program
    {
        static int health;
        static int roomState = 0;
        static bool bTimeOut = false;
        static Timer timeOutTimer;

        //Strings for traps that will go off
        static string[] trap = new string[] 
        { (""), ("\nYou tripped on a rock."), ("\nA bat smacked you in face."), ("\nYou found a pebble in your shoe."),
                ("\nYou turned your neck the wrong way. It hurt."), ("\nYou remembered something weird you did in highschool."),
                ("\nA snake told you that your shirt is ugly."), ("\nSomething in the darkness bit you."), ("\nA huge boulder nearly hit you."),
                ("\nYou simply felt yourself lose health. Somewhere you can hear a voice laughing.")
        };

        //Creates a matrix that represents the maze
        static (string, int)[,] mazeMatrix = new (string, int)[,]
        {
                       /* A */          /* B */        /* C */         /* D */         /* E */         /* F */         /* G */         /* H */
            /* A */ { ("NE", 0),       ("S", 2),     (null, -1),     (null, -1),     (null, -1),     (null, -1),     (null, -1),     (null, -1)},
            /* B */ { (null, -1),     (null,-1),     ("S",   2),     ("E",   3),     (null, -1),     (null, -1),     (null, -1),     (null, -1)},
            /* C */ { (null, -1),     ("N",  2),     (null, -1),     (null, -1),     (null, -1),     (null, -1),     (null, -1),     ("S",  20)},
            /* D */ { (null, -1),     ("W",  3),     ("S",   5),     (null, -1),     ("N",   2),     ("E",   4),     (null, -1),     (null, -1)},
            /* E */ { (null, -1),     (null,-1),     (null, -1),     (null, -1),     (null, -1),     ("S",   3),     (null, -1),     (null, -1)},
            /* F */ { (null, -1),     (null,-1),     (null, -1),     (null, -1),     (null, -1),     (null, -1),     ("E",   1),     (null, -1)},
            /* G */ { (null, -1),     (null,-1),     (null, -1),     (null, -1),     ("N",   0),     (null, -1),     (null, -1),     ("S",   2)},
            /* H */ { (null, -1),     (null,-1),     (null, -1),     (null, -1),     (null, -1),     (null, -1),     (null, -1),     (null, -1)}
        };

        //        //Creates a list that represents the maze
        //        static int[][] lMazeList = new int[][]
        //        {
        //            /* A */ new int[] {0, 1},
        //            /* B */ new int[] {2, 3},
        //            /* C */ new int[] {1, 7},
        //            /* D */ new int[] {1, 2, 4, 5},
        //            /* E */ new int[] {5},
        //            /* F */ new int[] {6},
        //            /* G */ new int[] {4, 7},
        //            /* H */ new int[] {-1}
        //        };
        //        static int[][] wMazeList = new int[][]
        //        {
        //            /* A */ new int[] {0, 2},
        //            /* B */ new int[] {2, 3},
        //            /* C */ new int[] {2, 20},
        //            /* D */ new int[] {3, 5, 2, 4},
        //            /* E */ new int[] {3},
        //            /* F */ new int[] {1},
        //            /* G */ new int[] {0, 2},
        //            /* H */ new int[] {-1}
        //        };

        static (int, string, int)[][] listGraph = new (int, string, int)[][]
        {
        /* A */    new (int, string, int)[] {(0, "N", 0), (0, "E", 0), (1, "S", 2)},
        /* B */    new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
        /* C */    new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
        /* D */    new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
        /* E */    new (int, string, int)[] {(5, "S", 3)},
        /* F */    new (int, string, int)[] {(6, "E", 1)},
        /* G */    new (int, string, int)[] {(4, "N", 0), (7, "S", 2)},
        /* H */    null
        };

        static void Main(string[] args)
        {
            string userState;
            bool playAgain = true;

            while (playAgain)
            {
                roomState = 0;
                bool alive = true;
                health = 1;

                Console.WriteLine("You find yourself in a strange room. {0} A booming voice speaks out to you:\n\n'Welcome to my Dungeon. Here you will wager your " +
                    "life and answer questions.\nWith every question you get right, your life will increase by your wager.\nHowever, with every question you get wrong, " +
                    "your life will be lost by that same amount.\nAs you gain more health, more doors will open to you.\nWill you play my game?'", RoomDesc());

                while (roomState != 7 && alive)
                {
                    Console.WriteLine("\nWhat would you like to do?");
                    Status();
                    userState = Console.ReadLine();

                    if (userState.ToLower() == "wager")
                    {
                        AskTrivia();

                        if (health <= 0)
                        {
                            alive = false;
                            continue;
                        }

                        Console.WriteLine(RoomDesc());
                    }
                    else
                    {
                        int newState = SState2NState(userState);

                        if (newState == -1)
                        {
                            Console.WriteLine("\nInvalid command.\n");
                            Console.WriteLine(RoomDesc());
                            continue;
                        }
                        else
                        {
                            roomState = newState;

                            if (roomState != 0 && roomState != 7)
                            {
                                Trap();
                            }

                            Console.WriteLine(RoomDesc());
                        }
                    }

                }

                if (!alive)
                {
                    Console.WriteLine("You ran out of health. Too bad.");
                }

                Console.WriteLine("Would you like to play again?");
                string again = Console.ReadLine();

                if (again.ToLower().Contains("y"))
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }

            }

            Console.WriteLine("Come again soon.");

        }

        static int SState2NState(string sState)
        {
            int nState = -1;

            if (sState.ToLower() == "n" || sState.ToLower().Contains("north") || sState.ToLower().Contains("up"))
            {
                for (int i = 0; i < listGraph[roomState].Length; ++i)
                {
                    if (listGraph[roomState][i].Item2 == "N" && listGraph[roomState][i].Item3 < health)
                    {
                        nState = listGraph[roomState][i].Item1;
                        health = health - listGraph[roomState][i].Item3;
                    }
                }
            }
            else if (sState.ToLower() == "s" || sState.ToLower().Contains("south") || sState.ToLower().Contains("down"))
            {
                for (int i = 0; i < listGraph[roomState].Length; ++i)
                {
                    if (listGraph[roomState][i].Item2 == "S" && listGraph[roomState][i].Item3 < health)
                    {
                        nState = listGraph[roomState][i].Item1;
                        health = health - listGraph[roomState][i].Item3;
                    }
                }
            }
            else if (sState.ToLower() == "e" || sState.ToLower().Contains("east") || sState.ToLower().Contains("right"))
            {
                for (int i = 0; i < listGraph[roomState].Length; ++i)
                {
                    if (listGraph[roomState][i].Item2 == "E" && listGraph[roomState][i].Item3 < health)
                    {
                        nState = listGraph[roomState][i].Item1;
                        health = health - listGraph[roomState][i].Item3;
                    }
                }
            }
            else if (sState.ToLower() == "w" || sState.ToLower().Contains("west") || sState.ToLower().Contains("left"))
            {
                for (int i = 0; i < listGraph[roomState].Length; ++i)
                {
                    if (listGraph[roomState][i].Item2 == "W" && listGraph[roomState][i].Item3 < health)
                    {
                        nState = listGraph[roomState][i].Item1;
                        health = health - listGraph[roomState][i].Item3;
                    }
                }
            }

            return nState;
        }


        static string RoomDesc()
        {
            string s = "";
            if (roomState == 0)
            {
                s += "The walls are covered in moss, and there is a pugnent smell of dust that makes you feel as if no one had been here in a long, long time." +
                    " There are two doors around you, one to the north, and one to the east.";

                if (health > 2)
                {
                    s += " You notice a third door to the south.";
                }
                return s;
            }
            if (roomState == 1)
            {
                s += ("This room is slightly less decayed, although the smell is still there. In the corner you see bones.");

                if (health > 2)
                {
                    s += " You see a door south of you.";
                }
                if (health > 3)
                {
                    s += " You see a door east of you.";
                }

                return s;
            }
            if (roomState == 2)
            {
                s += ("A golden light seems to flicker in and out of this room, but you can't exactly tell where it comes from.");

                if (health > 2)
                {
                    s += " You see the room to the north.";
                }
                if (health > 20)
                {
                    s += " You see a strange looking door south of you.";
                }

                return s;
            }
            if (roomState == 3)
            {
                s += ("It seems this room only gets worse. The walls are covered in what appears to be blood, though it might just be jam.\nWho really knows at this point.");

                if (health > 2)
                {
                    s += " You notice a door to the north.";
                }
                if (health > 3)
                {
                    s += " You notice the door to the west which you came from.";
                }
                if (health > 4)
                {
                    s += " You notice a door to the east.";
                }
                if (health > 5)
                {
                    s += " You notice a door to the south.";
                }

                return s;
            }
            if (roomState == 4)
            {
                s += ("This room seems to be filled with total darkness. You can't see your own hand in front of your face.");

                if (health > 3)
                {
                    s += " Somehow, a doorframe shimmers to the south, but casts no light on the ground.";
                }

                return s;
            }
            if (roomState == 5)
            {
                s += "A golden lights fills this room, but you think it might actually be your imagination.";

                if (health > 1)
                {
                    s += " You see a hallway to the east.";
                }

                return s;
            }
            if (roomState == 6)
            {
                s += "This hallway seems to stretch on infinitely, however at the same time, you know that there is an end if you continue north.";

                if (health > 2)
                {
                    s += "You look around and actually realize the hallway is not infinite, and there is another end to the south.";
                }

                return s;
            }
            if (roomState == 7)
            {
                s += "'Congratulations!' Yells the booming voice. 'You have made it to the final room, and are just in time for the surprise party!'\n" +
                    "You realize you just managed to walk into your house where all your friends were waiting to surprise you on your birthday.\nYou look behind you " +
                    "to see if there is any remain that creepy dungeon, but there is only the darkness of the night sky.";

                return s;
            }
            else
            {
                return ("Error: Something terrible happened :(\nRoom: " + roomState);
            }
        }

        static void Trap()
        {
            Random rand = new Random();

            int damage = rand.Next(0, health);
            int chooser = rand.Next(0, 10);

            Console.WriteLine(trap[chooser]);
            Console.WriteLine("You lost {0} health.\n", damage);
            health -= damage;
        }


        static void Status()
        {
            Console.WriteLine("Health: {0}\nAvailable Commands: Wager, or choose a Path\n", health);
        }

        static void AskTrivia()
        {
            string url = null;
            string s = null;
            int wager;
            string answer;
            string[] answers = new string[4];
            string[] letters = new string[] { ("a"), ("b"), ("c"), ("d") };
            Random rand = new Random();
            int r = rand.Next(0, 4);

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = "https://opentdb.com/api.php?amount=1&type=multiple";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();

            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

        tryagain:

            Console.Write("\nEnter an amount of health to wager (you cannot wager more than you have): ");
            wager = Convert.ToInt32(Console.ReadLine());
            if (wager > health)
            {
                Console.WriteLine("That was more than your health. Try again.");
                goto tryagain;
            }

            Console.WriteLine("Here comes the question. You will have 15 seconds to answer:");
            Console.WriteLine(trivia.results[0].question);

            answers[r] = trivia.results[0].correct_answer;
            int wrong = 0;

            for (int i = 0; i < 4; ++i)
            {
                if (i == r) { continue; }
                answers[i] = trivia.results[0].incorrect_answers[wrong];
                ++wrong;
            }

            for (int i = 0; i < answers.Length; ++i) { Console.WriteLine(letters[i] + ": " + answers[i]); }

            timeOutTimer = new Timer(15000);

            ElapsedEventHandler elapsedEventHandler;

            elapsedEventHandler = new ElapsedEventHandler(TimesUp);

            timeOutTimer.Elapsed += elapsedEventHandler;

            timeOutTimer.Start();

            Console.Write("Your answer: ");
            answer = Console.ReadLine();

            //test by setting answer equal to answer.
            //answer = trivia.results[0].correct_answer;

            timeOutTimer.Stop();

            if ((answer.ToLower() == trivia.results[0].correct_answer.ToLower() || answer.ToLower() == letters[r]) && !bTimeOut)
            {
                Console.WriteLine("You did it!");
                Console.WriteLine("{0} health points added.", wager);
                health += wager;
            }
            else
            {
                if (bTimeOut)
                {
                    Console.WriteLine("You took too long. The answer was {0}", trivia.results[0].correct_answer);
                }
                else
                {
                    Console.WriteLine("Sorry, but that was incorrect. The answer was {0}", trivia.results[0].correct_answer);
                }
                Console.WriteLine("{0} health points lost.", wager);
                health -= wager;
            }

        }

        //Method: TimesUp
        //Purpose: Display a message if the user timed out
        //Restrictions: None
        static void TimesUp(object source, ElapsedEventArgs e)
        {
            timeOutTimer.Stop();
            Console.WriteLine();
            Console.WriteLine("Times up.");
            bTimeOut = true;
        }
    }
}