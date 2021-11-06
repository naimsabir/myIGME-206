using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE21
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignment 21
    //Restrictions: None
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
        }
    }
}
