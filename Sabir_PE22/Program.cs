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

namespace Sabir_PE22
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

    class Program
    {
        static Timer timer;
        static bool isTimeUp;
        // neighboring points can be determined by if (maxtrixGraph[x, y].Item1 == x)
        // relative direction is Item1 in the tuple
        // cost is Item2 in the tuple
        static (string, int)[,] matrixGraph = new (string, int)[,]
        {
                 //    A           B           C           D           E           F           G           H
          /*A*/  {("NE", 0),  ("S", 2),   (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1)},
          /*B*/  {(null, -1), (null, -1), ("S", 2),   ("E", 3),   (null, -1), (null, -1), (null, -1), (null, -1)},
          /*C*/  {(null, -1), ("N", 2),   (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("S", 20)},
          /*D*/  {(null, -1), ("W", 3),   ("S", 5),   (null, -1), ("N", 2),   ("E", 4),   (null, -1), (null, -1)},
          /*E*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("S", 3),   (null, -1), (null, -1)},
          /*F*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("E", 1),   (null, -1)},
          /*G*/  {(null, -1), (null, -1), (null, -1), (null, -1), ("N", 0),   (null, -1), (null, -1), ("S", 2)},
          /*H*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1)}
        };

        //Item1 is the index of the neighbor, Item2 is the direction and Item3 is the cost
        static (int, string, int)[][] listGraph = new (int, string, int)[][]
        {
            /*A*/ new (int, string, int)[] {(0, "N", 0), (0, "E", 0), (1, "S", 2)},
            /*B*/ new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            new (int, string, int)[] {(5, "S", 3)},
            new (int, string, int)[] {(6, "E", 1)},
            new (int, string, int)[] {(4, "N", 0)},
            null
        };

        // parallel arrays to store the weight, direction and room indexes
        // weight graph
        static int[][] wGraph = new int[][]
        {
            /*A*/ new int[] {0, 0, 2}
            /*B new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            new (int, string, int)[] {(5, "S", 3)},
            new (int, string, int)[] {(6, "E", 1)},
            new (int, string, int)[] {(4, "N", 0)},
            null  */
        };

        // room graphs: contains the indexes of the connected rooms
        static int[][] iGraph = new int[][]
        {
            /*A*/ new int[] {0, 0, 1}
            /*B new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            new (int, string, int)[] {(5, "S", 3)},
            new (int, string, int)[] {(6, "E", 1)},
            new (int, string, int)[] {(4, "N", 0)},
            null  */
        };

        //can create a static string[,] = new string[,] to store descriptions
        static string[] desc = new string[]
        {
            /* A */ "You wake up in a dark damp cave, with no idea how you arrived there. \n To the south of you " +
                "there is an opening and every other direction is closed off. Which direction will you head? North, South, or East.",

            /* B */ "You exit the cave opening into what seems to be an abandoned underground laboratory. \n" +
                " After looking around you see that there are doors east and south of you. Which direction will you head? ",

            /* C */ "You enter a room that looks like it's used to dispose of failed experiments. There is what looks like a defunct long incinerator tunnel" +
                " to the south that seems to lead somewhere.\n To the north is the door you came through. Which direction will you head?",

            /* D */ "You enter a room filled with medical equipment that has a bloody table in the middle of it.\n There is a door to the east, the door you" +
                " came through to the west, a door to the north, and what looks like a strange human sized chute at the foot of the table.\n Which direction will you head?",

            /* E */ "You enter a large room filled with dozens of open prison cells along the walls, some with skeletons and blood stains. \n " +
                "The door you came through was locked behind you and so is the door ahead of you. However, the door to the south has automatically opened." +
                "\n Beyond it is a hallway filled with lasers to pass through. Which direction will you head?",

            /* F */ "You enter a room narrowly abvoiding the large vat of acid in the middle of the room. \n the doors around you all lock except for one" +
                " to the east that opens. Whic direction will you head?",

            /* G */ " You enter a room fiiled with bodies. Some look like prisoners and some look like guards all of which seemed to be crawling towards a door to the South" +
                "\n the hall it leads to seems to be filled with gas but has a little light at the end. To the north there is another less ominous door. \n " +
                "Which direction will you head?",

            /* H */ "You powered through the gas and escaped",
        };

        static string RandomPhrase(int picker)
        {
            string randPhrase;
            switch(picker)
            {
                case 1:
                    randPhrase = "As you walk to the door you are sprayed with acid!";
                    return randPhrase;
                case 2:
                    randPhrase = "A shambling mutated experiment claws at you before dying!";
                    return randPhrase;
                case 3:
                    randPhrase = "You stepped on a nail!";
                    return randPhrase;
                case 4:
                    randPhrase = "You triggered a booby trap!";
                    return randPhrase;
                case 5:
                    randPhrase = "You inhaled toxic gas!";
                    return randPhrase;
                default:
                    randPhrase = "Naim somehow fucked up the most simple part of this!";
                    return randPhrase;
            }
        }



        static void Main(string[] args)
        {

            timer = new Timer(15000);

            
            
            Random rand = new Random();

            ElapsedEventHandler elapsedEventHandler = new ElapsedEventHandler(TimesUp);

            int randDamage;

            string randPhrase;

            int nRoom = 0;

            int playerHp = 1;

            //possibly add and playerHp != 0 to this
            while (nRoom != 7 && playerHp > 0)
            {
                // if not room A and not room H then randomly reduce their HP such that they don't die
                if(nRoom != 0)
                {
                    randDamage = rand.Next(0, 5);
                    randPhrase = RandomPhrase(rand.Next(1, 5));

                    playerHp = playerHp - randDamage;

                    Console.WriteLine($"{randPhrase} You took {randDamage} damage!");
                }

                // display a desc of the room
                 Console.WriteLine(desc[nRoom]);

                // display any exits from the room
                (int, string, int)[] thisRoomsNeighbors = listGraph[nRoom];

                int nExits = 0;

                foreach ((int, string, int) neighbor in thisRoomsNeighbors)
                {
                    if (playerHp > neighbor.Item3)
                    {
                        Console.WriteLine("There is an exit to the " + neighbor.Item2 + " which costs " + neighbor.Item3 + "HP");
                        ++nExits;
                    }
                }

                // display the hp
                Console.WriteLine($"You have {playerHp} HP");

                // ask the player if they want wager (w) for more hp or leave (l) the room only if there are nExits > 0
                Console.WriteLine("Do you want to wager your health with trivia? Or do you want to exit the room?\n Enter w to wager and l to leave the room");
                string sResponse;

                sResponse = Console.ReadLine();

                if (sResponse.ToLower() == "l" /* leaving room */ && nExits > 0 /* if there are exits */ )
                {
                    bool bValid = false;
                    string sDirection;

                    Console.WriteLine("Enter your chosen direction");

                    while (!bValid)
                    {
                        sDirection = Console.ReadLine();

                        for (int nCntr = 0; nCntr < 8; ++nCntr)
                        {
                            if (matrixGraph[nRoom, nCntr].Item1.Contains(sDirection) && playerHp > matrixGraph[nRoom, nCntr].Item2)
                            {
                                nRoom = nCntr;
                                playerHp -= matrixGraph[nRoom, nCntr].Item2;
                                bValid = true;
                                break;
                            }
                        }

                        if (!bValid)
                        {
                            Console.WriteLine("That isn't a valid direction");
                        }
                    }
                }
                else
                {
                    // trivia question
                    // fetch api
                    // 15 second limit to answer
                    // multiple choice 1-4

                    // ask player how much HP to wager (limited to playerHp)
                    // prevent player from wagering a negative number
                    int healthWager;

                    wager:

                    Console.WriteLine("How much health do you want to wager?");
                    healthWager = Convert.ToInt32(Console.ReadLine());

                    if(healthWager <= 0)
                    {
                        Console.WriteLine("Cannot enter a negative number. Try again!");
                        goto wager;
                    }

                    int playerAnswer, rightNum = 0;
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

                    // put the answers in random order
                    // prefix each answer with number 1-4 so the player only need to type the number
                    Console.WriteLine($"The question is {trivia.results[0].question}");
                    for (int i = 0; i <= 3; i++)
                    {
                        int rightOrWrong;
                        bool rightOnBoard = false;
                        rightOrWrong = rand.Next(1,2);
                        if (rightOrWrong == 1 || rightOnBoard == true)
                        {
                            Console.WriteLine($"Number{i}: {trivia.results[0].incorrect_answers[rand.Next(0, trivia.results[0].incorrect_answers.Count)]}");
                        }
                        if(rightOrWrong == 2 && rightOnBoard == false)
                        {
                            Console.WriteLine($"Number{i}: {trivia.results[0].correct_answer}");
                            //so only one correct answer can show up
                            rightOnBoard = true;
                            rightNum = i;
                        }
                    }
                    timer.Elapsed += elapsedEventHandler;
                    timer.Start();

                    Console.WriteLine("Enter the number of the correct answer");
                    playerAnswer = Convert.ToInt32(Console.ReadLine());

                    if(playerAnswer == rightNum && isTimeUp == false)
                    {
                        Console.WriteLine("Correct!");
                        playerHp += healthWager;
                    }
                    else if(playerAnswer != rightNum || isTimeUp == true)
                    {
                        Console.WriteLine($"That answer was incorrect the correct answer was number: {rightNum}");
                        playerHp -= healthWager;
                    }
                    
                    // 15 second timer


                }
            }
            if(nRoom == 7)
            {
                Console.WriteLine("You have escaped!");
            }
            if(playerHp <= 0)
            {
                Console.WriteLine("You have died");
            }
        }
         static void TimesUp(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Times Up!");
            isTimeUp = true;
            timer.Stop();
        }

    }
}
