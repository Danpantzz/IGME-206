using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static int roomState;

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
            health = 1;
            roomState = 0;
            string userState;
            bool playAgain = true;

            while (playAgain)
            {
                bool alive = true;

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
                    }
                    else
                    {
                        if (SState2NState(userState) == -1)
                        {
                            Console.WriteLine("\nInvalid command.\n");
                            Console.WriteLine(RoomDesc());
                            continue;
                        }
                        else
                        {
                            roomState = SState2NState(userState);
                            Console.WriteLine(RoomDesc());
                        }
                    }

                }

                if (!alive)
                {
                    Console.WriteLine("Too bad.");
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

            Console.WriteLine("Try again another time.");

        }

        static int SState2NState(string sState)
        {
            int nState = -1;

            if (sState.ToLower() == "n" || sState.ToLower().Contains("north") || sState.ToLower().Contains("up"))
            {
                for (int i = 0; i < listGraph[roomState].Length; i++)
                {
                    if (listGraph[roomState][i].Item2 != "N") { continue; }
                    if (listGraph[roomState][i].Item3 > health) { continue; }
                    nState = listGraph[roomState][i].Item1;
                }
            }
            if (sState.ToLower() == "s" || sState.ToLower().Contains("south") || sState.ToLower().Contains("down"))
            {
                for (int i = 0; i < listGraph[roomState].Length; i++)
                {
                    if (listGraph[roomState][i].Item2 != "S") { continue; }
                    if (listGraph[roomState][i].Item3 > health) { continue; }
                    nState = listGraph[roomState][i].Item1;
                }
            }
            if (sState.ToLower() == "e" || sState.ToLower().Contains("east") || sState.ToLower().Contains("right"))
            {
                for (int i = 0; i < listGraph[roomState].Length; i++)
                {
                    if (listGraph[roomState][i].Item2 != "E") { continue; }
                    if (listGraph[roomState][i].Item3 > health) { continue; }
                    nState = listGraph[roomState][i].Item1;
                }
            }
            if (sState.ToLower() == "w" || sState.ToLower().Contains("west") || sState.ToLower().Contains("left"))
            {
                for (int i = 0; i < listGraph[roomState].Length; i++)
                {
                    if (listGraph[roomState][i].Item2 != "W") { continue; }
                    if (listGraph[roomState][i].Item3 > health) { continue; }
                    nState = listGraph[roomState][i].Item1;
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
                return ("1");
            }
            if (roomState == 2)
            {
                return ("2");
            }
            if (roomState == 3)
            {
                return ("3");
            }
            if (roomState == 4)
            {
                return ("4");
            }
            if (roomState == 5)
            {
                return ("5");
            }
            if (roomState == 6)
            {
                return ("6");
            }
            if (roomState == 7)
            {
                return ("7");
            }
            else
            {
                return ("Error: Something terrible happened :(");
            }
        }

        static void Status()
        {
            Console.WriteLine("Health: {0}\nAvailable Commands: Wager, or choose an Exit\n", health);
        }

        static void AskTrivia()
        {
            string url = null;
            string s = null;
            bool success = false;
            int wager = 500;
            string answer;
            string[] answers = new string[4];
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

            Console.WriteLine("Here comes the question:");
            Console.WriteLine(trivia.results[0].question);

            answers[r] = trivia.results[0].correct_answer;

            for (int i = 0; i < 4; ++i)
            {
                if (i == r) { continue; }
                answers[i] = trivia.results[0].incorrect_answers[i];
            }

            for (int i = 0; i < answers.Length; ++i) { Console.WriteLine(answers[i]); }

            Console.Write("Your answer: ");
            answer = Console.ReadLine();

            if (answer == trivia.results[0].correct_answer)
            {
                Console.WriteLine("You did it!");
                Console.WriteLine("{0} health points added.", wager);
                health += wager;
            }
            else
            {
                Console.WriteLine("Sorry, but that was incorrect.");
                Console.WriteLine("{0} health points lost.", wager);
                health -= wager;
            }

        }
    }
}