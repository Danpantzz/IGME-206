using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE21
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Creates a matrix and list to represent the maze in "Don't Die"
    class Program
    {
        //Creates a matrix that represents the maze
        static int[,] mazeMatrix = new int[,]
        {
                    /* A */ /* B */ /* C */ /* D */ /* E */ /* F */ /* G */ /* H */
            /* A */ {  0,      2,     -1,     -1,     -1,     -1,     -1,     -1},
            /* B */ { -1,     -1,      2,      3,     -1,     -1,     -1,     -1},
            /* C */ { -1,      2,     -1,     -1,     -1,     -1,     -1,     20},
            /* D */ { -1,      3,      5,     -1,      2,      4,     -1,     -1},
            /* E */ { -1,     -1,     -1,     -1,     -1,      3,     -1,     -1},
            /* F */ { -1,     -1,     -1,     -1,     -1,     -1,      1,     -1},
            /* G */ { -1,     -1,     -1,     -1,      0,     -1,     -1,      2},
            /* H */ { -1,     -1,     -1,     -1,     -1,     -1,     -1,     -1}
        };

        //Creates a list that represents the maze
        static int[][] lMazeList = new int[][]
        {
            /* A */ new int[] {0, 1},
            /* B */ new int[] {2, 3},
            /* C */ new int[] {1, 7},
            /* D */ new int[] {1, 2, 4, 5},
            /* E */ new int[] {5},
            /* F */ new int[] {6},
            /* G */ new int[] {4, 7},
            /* H */ new int[] {-1}
        };
        static int[][] wMazeList = new int[][]
        {
            /* A */ new int[] {0, 2},
            /* B */ new int[] {2, 3},
            /* C */ new int[] {2, 20},
            /* D */ new int[] {3, 5, 2, 4},
            /* E */ new int[] {3},
            /* F */ new int[] {1},
            /* G */ new int[] {0, 2},
            /* H */ new int[] {-1}
        };

        static void Main(string[] args)
        {

        }
    }
}
