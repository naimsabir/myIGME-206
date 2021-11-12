using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;

namespace Sabir_PE22_2
{
    class Program
    {
        //Write the C# code to represent this digraph as both an Adjacency Matrix and as an Adjacency List.
        //Note that you will have to represent the neighboring points, their relative direction, and their cost.

        //matrix list
        static int[,] mGraph = new int[,]
        {
                    /* A */ /* B */ /* C */ /* D */ /* E */ /* F */ /* G */ /* H */
            /* A */ {  0,      2,     -1,     -1,     -1,     -1,     -1,     -1, },
            /* B */ { -1,     -1,      2,      3,     -1,     -1,     -1,     -1, },
            /* C */ { -1,      2,     -1,     -1,     -1,     -1,     -1,     20, },
            /* D */ { -1,     -1,      5,     -1,      2,      4,     -1,     -1, },
            /* E */ { -1,     -1,     -1,     -1,     -1,      3,     -1,     -1, },
            /* F */ { -1,     -1,     -1,     -1,     -1,     -1,      1,     -1, },
            /* G */ { -1,     -1,     -1,     -1,      0,     -1,     -1,      2, },
            /* H */ { -1,     -1,     -1,     -1,     -1,     -1,     -1,     -1, },
        };

        //adjacency list
        static int[][] lGraph = new int[][]
        {
            /* A */ new int[] { 0, 1 },    /* A, B */
            /* B */ new int[] { 2, 3 },    /* C, D */
            /* C */ new int[] { 1, 7 }, /* B, H */
            /* D */ new int[] { 2, 4, 5 },    /* C, E, F */
            /* E */ new int[] { 5}, /* F */
            /* F */ new int[] { 6}, /* G */
            /* G */ new int[] { 4, 7}, /* E, H */
            /* H */ new int[] {},
        };

        //edge weights
        static int[][] wGraph = new int[][]
        {
            /* A */ new int[] {0, 2},
            /* B */ new int[] {2, 3},
            /* C */ new int[] {2, 20},
            /* D */ new int[] {5, 2, 4},
            /* E */ new int[] {3},
            /* F */ new int[] {1},
            /* G */ new int[] {0, 2},
            /* H */ new int[] {},
        };

        static void Main(string[] args)
        {
            /*1. Start the player in Room A with an initial Health Point value of 1.
              2. Upon entering a room that is not A or H, something should happen that decreases their HP a random amount,
                 but not such that their HP will reach less than 1.  
                       Examples of injuries are an attack from a bat, the player trips on a rock, etc.
              3. The game will provide a unique and interesting description of each room without including the room letter (not "You are in room B"…),
                 and the description will include the exits to which the player has access based on their (HP - 1).  The player will not see the map, 
                 so they are discovering the game based on your descriptions of each room.  The description should also display the player's current HP.
              4. Prompt the player for what they want to do: leave via an available exit or wager their HP against a trivia question.
              5. If they choose an exit, then deduct the cost of that exit from their HP and move them to the next room.  Goto step 2.
              6. If they choose to grind for HP, then prompt the player how much of their HP they want to wager, and use the trivia JSON API at
                 https://opentdb.com/api_config.php to generate a multiple choice question to ask the player.  (Refer to TriviaApp in Session 11-1).  
                 If they get the question right, then their HP increases by their wager.  If they get it wrong then their HP reduces by their wager, 
                 and they die if their HP reaches 0.  They should have only 15 seconds to answer the question.  
                 (You can set the trivia parameters or just use https://opentdb.com/api.php?amount=1 - you only need 1 question).
              7. Goto step 3 */

            Random rand = new Random();

            int nState, playerHP = 1;
            string direction;


            Console.WriteLine("You wake up in a dark damp cave, with no idea how you arrived there. \n To the south of you " +
                "there is an opening and every other direction is closed off. Which direction will you head? North South East or West.");

        roomA:

            direction = Console.ReadLine().ToLower();



            if (direction.StartsWith("e"))
            {
                nState = 0;
                if (mGraph[0, nState] != -1)
                {
                    playerHP = playerHP - (mGraph[0, nState]);
                    Console.WriteLine($"You wander to the east of the cave, there is a poorly drawn image of a person heading into the opening \n" +
                        $"Your health is {playerHP} and you have taken {mGraph[0, nState]} damage. Which direction will you head? North South East or West.");
                    goto roomA;
                }
            }
            if (direction.StartsWith("w"))
            {
                nState = 0;
                if (mGraph[0, nState] != -1)
                {
                    playerHP = playerHP - (mGraph[0, nState]);
                    Console.WriteLine($"You wander to the west of the cave, the cave wall is completely barren \n" +
                        $"Your health is {playerHP} and you have taken {mGraph[0, nState]} damage. Which direction will you head? North South East or West.");
                    goto roomA;
                }
            }
            if (direction.StartsWith("s"))
            {
                nState = 1;
                if (mGraph[0, nState] != -1)
                {
                    Console.WriteLine($"You go through the opening to the south. Your health is {playerHP} and you have taken {mGraph[0, nState]} damage.");
                }
            }
            if (direction.StartsWith("n"))
            {
                nState = 0;
                if (mGraph[0, nState] != -1)
                {
                    playerHP = playerHP - (mGraph[0, nState]);
                    Console.WriteLine($"You wander to the north of the cave, the cave wall is completely barren \n" +
                        $"Your health is {playerHP} and you have taken {mGraph[0, nState]} damage. Which direction will you head? North South East or West.");
                    goto roomA;
                }
            }
            //**********************************************************************ROOM B*************************************************************************

            Console.WriteLine("You exit the cave opening into what seems to be an abandoned underground laboratory." +
                " After looking around you see that there are doors east and south of you. Which direction will you head? ");

            roomB:

            direction = Console.ReadLine().ToLower();

            if (direction.StartsWith("e"))
            {
                nState = 3;
                if (mGraph[1, nState] != -1)
                {
                    playerHP = playerHP - (mGraph[1, nState]);
                    Console.WriteLine($"You enter the door to the east. \n" +
                        $"Your health is {playerHP} and you have taken {mGraph[0, nState]} damage.");
                    goto roomB;
                }
                else
                {
                    Console.WriteLine("There is a dead end. Choose a new direction");
                    goto roomB;
                }
            }
            if (direction.StartsWith("w"))
            {
                nState = 0;
                if (mGraph[1, nState] != -1)
                {
                    playerHP = playerHP - (mGraph[0, nState]);
                    Console.WriteLine($"You wander to the west of the cave, the cave wall is completely barren \n" +
                        $"Your health is {playerHP} and you have taken {mGraph[0, nState]} damage. Which direction will you head? North South East or West.");
                    goto roomB;
                }
            }
            if (direction.StartsWith("s"))
            {
                nState = 1;
                if (mGraph[1, nState] != -1)
                {
                    Console.WriteLine($"You go through the opening to the south. Your health is {playerHP} and you have taken {mGraph[0, nState]} damage.");
                }
            }
            if (direction.StartsWith("n"))
            {
                nState = 0;
                if (mGraph[1, nState] != -1)
                {
                    playerHP = playerHP - (mGraph[0, nState]);
                    Console.WriteLine($"You wander to the north of the cave, the cave wall is completely barren \n" +
                        $"Your health is {playerHP} and you have taken {mGraph[0, nState]} damage. Which direction will you head? North South East or West.");
                    goto roomB;
                }
            }
        }
    }
}
