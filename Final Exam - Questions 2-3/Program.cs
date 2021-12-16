using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.IO;
using System.Timers;
using System.Diagnostics;

namespace Final_Exam___Questions_2_3
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
    //Purpose: Create methods to play the game
    //Restrictions: None
    class Program
    {
        enum NodeState
        {
            ice,
            liquid_gas,
            gas,
            liquid_ice
        }

        //Adjacency Matrix
        static int[,] matrixGraph = new int[,]
        {           /* A */ /* B */ /* C */ /* D */ /* E */ /* F */ /* G */ /* H */
            /* A */ { -1,      1,      5,     -1,     -1,     -1,     -1,     -1},
            /* B */ { -1,     -1,     -1,      1,     -1,      7,     -1,     -1},
            /* C */ { -1,     -1,     -1,      0,      2,     -1,     -1,     -1},
            /* D */ { -1,      1,      0,     -1,     -1,     -1,     -1,     -1},
            /* E */ { -1,     -1,      2,     -1,     -1,     -1,      2,     -1},
            /* F */ { -1,     -1,     -1,     -1,     -1,     -1,     -1,      4},
            /* G */ { -1,     -1,     -1,     -1,      2,      1,     -1,     -1},
            /* H */ { -1,     -1,     -1,     -1,     -1,     -1,     -1,     -1}
        };

        // Adjacency List (neighbor index, cost)
        static (int, int)[][] listGraph = new (int, int)[][]
        {
            /* A */ new (int, int)[] {(1, 1), (2, 5)},
            /* B */ new (int, int)[] {(3, 1), (5, 7)},
            /* C */ new (int, int)[] {(3, 0), (4, 2)},
            /* D */ new (int, int)[] {(1, 1), (2, 0)},
            /* E */ new (int, int)[] {(2, 2), (6, 2)},
            /* F */ new (int, int)[] {(7, 4)},
            /* G */ new (int, int)[] {(4, 2), (5,1)},
            /* H */ null
        };

        static int[] stateList = new int[]
        {
            (int)NodeState.ice,
            (int)NodeState.liquid_gas,
            (int)NodeState.gas,
            (int)NodeState.ice,
            (int)NodeState.liquid_gas,
            (int)NodeState.gas,
            (int)NodeState.ice,
            (int)NodeState.liquid_gas
        };

        static Timer sTimer;
        static Timer qTimer;
        static bool bTimedOut;
        static Object lockObject = new object();

        //Method: Q3
        //Purpose: Holds the room descriptions and player inputs that make up the game, allow the player to move between rooms
        //Restrictions: None
        static void Q3()
        {
            Random rand = new Random();


            int nRoom = 0;

            int playerHp = 5;
            int playerState = (int)NodeState.ice;
            int playerMoves = 0;

            bool playGame = false;

            string play;

            string[] desc = new string[]
            {
                /*A*/ "Room A, the starting point. The walls are covered in century old mold. It's best not to breath in too much. Bones litter the floor.",
                /*B*/ "room B. This one feels a bit less dead, with no mold or bones on the floor. You see a well in the middle of the room. It seems to have no bottom.",
                /*C*/ "room C. A light shines in from a crack in the roof, which seems impossible considering you're 200ft underground.",
                /*D*/ "room D. Total darkness fills this room. The floor feels rubbery, almost as if you're standing on a trampoline. You decide not to jump for the fear that anything could be above you.",
                /*E*/ "room E. All sound is gone from this room. Not that it was loud before, but at least you could hear your own footsteps. Not even the sound of your breathe can fill the silence.",
                /*F*/ "room F. It feels close in here. You're not sure what 'it' is, but something about this room fills you with adrenaline, like your journey is almost over.",
                /*G*/ "room G. Despite there being nothing in here, your body moves as if the entire room in filled with jello, pushing back at you with every step. You need to get out soon.",
                /*H*/ "room H, the final room. As you step out of the dungeon, you're greeted with a gentle breeze and the russling of the trees nearby. Your body feels normal again," +
                      " as your atoms are no longer bound by the rules of those room. You are free. You won.\n"
            };


        // describe that there are rooms A-H, and the initial state of each room and how they change state every second

        desc:
            Console.WriteLine("Welcome to The Game. In this game you will travel between 8 different rooms, A through D.\n" +
                "However, these rooms are not like normal rooms.\n" +
                "These room will change their State of Matter with every second that passes, from ice, liquid, gas,\n" +
                "then back to liquid and ice forever without your knowledge of what state they are in.\n" +
                "Their initial States of Matter will appear like this:\n" +
                "Room A: Ice\n" +
                "Room B: Liquid\n" +
                "Room C: Gas\n" +
                "Room D: Ice\n" +
                "Room E: Liquid\n" +
                "Room F: Gas\n" +
                "Room G: Ice\n" +
                "Room H: Liquid\n" +
                "You will also have the ability to change your State of Matter,\n" +
                "however, it will cost you 1 health, and you may only pass through a room that matches your own state.");

            // ask player to start the game

            while (playGame != true)
            {
                Console.WriteLine("Will you choose to play?");
                play = Console.ReadLine();

                if (play.ToLower().StartsWith("y"))
                {
                    playGame = true;
                }
                else if (play.ToLower().StartsWith("n"))
                {
                    Console.WriteLine("Very well. Until next time.");
                    break;
                }
            }

            while (playGame == true)
            {

                sTimer = new Timer(1000);
                sTimer.Elapsed += ChangeNodeStates;

                qTimer = new Timer(15000);


                sTimer.Start();

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();



                // nRoom keeps track of which room the player is in A=0, H=7
                // while not in room H (the exit)
                while (nRoom != 7)
                {
                    if (playerHp == 0)
                    {
                        break;
                    }

                    // display a desc of the room
                    Console.WriteLine(desc[nRoom]);

                    // display the current state of the player

                    // display any exits from the room
                    // the neighbors of the current room are stored as an array of tuples
                    // storing the neighbor index (0-7), the available direction (eg. "N"), and the cost of the exit
                    // fetch the array of neighbors for the current room
                    (int, int)[] thisRoomsNeighbors = listGraph[nRoom];

                    int nExits = 0;

                    // check each neighbor of the current room to see if it's available
                    foreach ((int, int) neighbor in thisRoomsNeighbors)
                    {
                        // if the player's HP is greater than the cost of the exit
                        if (playerHp > neighbor.Item2)
                        {
                            // display the exit
                            Console.WriteLine("There is an exit to room " + (char)('A' + neighbor.Item1) + " which costs " + neighbor.Item2 + " HP");

                            // count how many exits are available
                            ++nExits;
                        }
                    }

                    // display the hp
                    Console.WriteLine($"You have {playerHp} HP");

                    // ask the player if they want wager (w) for more hp or leave (l) or change state (c) the room only if there are nExits > 0
                    string sResponse = null;

                    // if there are exits available
                    if (nExits > 0)
                    {
                        while (sResponse != "l" && sResponse != "w" && sResponse != "c")
                        {
                            // prompt for w or l
                            Console.Write("Would you like to wager for more health, change state or leave the room? ");

                            // grab the first character and lowercase it

                            sResponse = Console.ReadLine();

                            if (sResponse != "")
                            {
                                sResponse = sResponse.ToLower()[0].ToString();
                            }
                        }
                    }
                    else
                    {
                        // they need to wager, there are no exits
                        sResponse = "w";
                    }

                    // only if more than 1 HP
                    if (sResponse.ToLower() == "c")
                    {

                        {
                            if (playerState == (int)NodeState.ice)
                            {
                                playerState = (int)NodeState.liquid_gas;
                            }
                            else if (playerState == (int)NodeState.liquid_gas)
                            {
                                playerState = (int)NodeState.gas;
                            }
                            else if (playerState == (int)NodeState.gas)
                            {
                                playerState = (int)NodeState.liquid_ice;
                            }
                            else if (playerState == (int)NodeState.liquid_ice)
                            {
                                playerState = (int)NodeState.ice;
                            }
                        }

                        playerHp--;

                    }

                    // if leaving room
                    if (sResponse.ToLower() == "l" /* leaving room */ )
                    {
                        // initialize that the direction is invalid
                        bool bValid = false;
                        string sDirection;

                        while (!bValid)
                        {
                            Console.Write("Which room letter: ");

                            // read the first char of the direction
                            sDirection = Console.ReadLine().ToUpper()[0].ToString();

                            int nCost = 0;

                            foreach ((int, int) neighbor in thisRoomsNeighbors)
                            {
                                // if the player's HP is greater than the cost of the exit
                                if ((sDirection[0] - 'A') == neighbor.Item1 && playerHp > neighbor.Item2)
                                {
                                    nCost = neighbor.Item2;
                                    bValid = true;
                                    break;
                                }
                            }

                            if (bValid)
                            {
                                lock (lockObject)
                                {
                                    if (stateList[(sDirection[0] - 'A')] == playerState)
                                    {
                                        // deduct the HP
                                        playerHp -= nCost;

                                        // move to the room
                                        nRoom = sDirection[0] - 'A';

                                        //Increment player moves
                                        playerMoves++;

                                        break;
                                    }
                                }
                            }

                            // indicate invalid direction chosen
                            if (!bValid)
                            {
                                Console.WriteLine("That isn't a valid direction");
                            }
                        }
                    }
                    else
                    {
                        // otherwise grinding for HP

                        // trivia question
                        // fetch api
                        // 15 second limit to answer
                        // multiple choice 1-4

                        // ask player how much HP to wager (limited to playerHp)

                        string url = null;
                        string s = null;

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

                        // prompt for wager amount
                        string sWager = null;
                        int nWager = 0;

                        do
                        {
                            Console.Write("Enter how much of your HP to wager: ");
                            sWager = Console.ReadLine();
                        } while (!int.TryParse(sWager, out nWager) || (nWager < 0) || (nWager > playerHp));

                        // ask question
                        Console.WriteLine(trivia.results[0].question);

                        // choose random answer spot
                        int nAnswer = rand.Next(trivia.results[0].incorrect_answers.Count + 1);
                        int nWrongCntr = 0;

                        // output the correct answer in random position
                        // prefix each with 1-N to allow player to answer with N
                        for (int i = 0; i < trivia.results[0].incorrect_answers.Count + 1; ++i)
                        {
                            if (i == nAnswer)
                            {
                                // if this is the correct answer to show
                                Console.WriteLine($"{i + 1}: {trivia.results[0].correct_answer}");
                            }
                            else
                            {
                                // show the incorrect answers
                                Console.WriteLine($"{i + 1}: {trivia.results[0].incorrect_answers[nWrongCntr]}");
                                ++nWrongCntr;
                            }
                        }

                        // increment the answer to be 1-based instead of 0-based
                        ++nAnswer;

                        // 15 second timer
                        qTimer = new Timer(15000);

                        // use an anonymous method via a lambda expression to catch the lapsed timer event
                        qTimer.Elapsed += (o, e) => { bTimedOut = true; qTimer.Stop(); Console.WriteLine("Time's up. Press enter."); };

                        qTimer.Start();

                        Console.Write("==> ");
                        string sAnswer = Console.ReadLine();

                        qTimer.Stop();

                        //Comment out for true game
                        //sAnswer = nAnswer.ToString();

                        // if an incorrect answer
                        if (sAnswer != nAnswer.ToString() || bTimedOut)
                        {
                            Console.WriteLine($"Wrong!  The answer was {nAnswer}.");
                            playerHp -= nWager;
                        }
                        else
                        {
                            Console.WriteLine("Correct! You are stronger!");
                            playerHp += nWager;
                        }
                    }
                }

                if (playerHp > 0)
                {
                    Console.WriteLine($"You escaped the maze with {playerHp} HP!");
                    Console.WriteLine($"And it only took you {playerMoves} moves!");
                }
                else
                {
                    Console.WriteLine("Game Over. You ran out of health and lost.");
                }

                stopwatch.Stop();
                Console.WriteLine("Time for 10,000 generations: {0}ms\n {1} generations per second",
                            stopwatch.ElapsedMilliseconds, 10000000 / stopwatch.ElapsedMilliseconds);

                Console.WriteLine("You took {0}.", stopwatch.Elapsed.ToString(@"m\:ss"));

                Console.WriteLine("Would you like to play again?");
                play = Console.ReadLine();

                if (play.ToLower().StartsWith("y"))
                {
                    playGame = true;
                    nRoom = 0;
                    playerHp = 5;
                    playerState = (int)NodeState.ice;
                    goto desc;
                }
                else if (play.ToLower().StartsWith("n"))
                {
                    Console.WriteLine("Very well. Until next time.");
                    playGame = false;
                }

            }

        }

        //Method: ChangeNodeStates
        //Purpose: Change the state of each room every second
        //Restrictions: None
        static void ChangeNodeStates(object sender, ElapsedEventArgs e)
        {
            lock (lockObject)
            {
                for (int i = 0; i < stateList.Length; ++i)
                {
                    if (stateList[i] == (int)NodeState.ice)
                    {
                        stateList[i] = (int)NodeState.liquid_gas;
                    }
                    else if (stateList[i] == (int)NodeState.liquid_gas)
                    {
                        stateList[i] = (int)NodeState.gas;
                    }
                    else if (stateList[i] == (int)NodeState.gas)
                    {
                        stateList[i] = (int)NodeState.liquid_ice;
                    }
                    else if (stateList[i] == (int)NodeState.liquid_ice)
                    {
                        stateList[i] = (int)NodeState.ice;
                    }
                }
            }


        }

        //Method: Main
        //Purpose: Call the Q3 method to play the game
        //Restrictions: None
        static void Main(string[] args)
        {
            Q3();
        }
    }
}
