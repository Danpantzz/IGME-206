using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_3___Questions_2_5
{

    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Create Adjacency matrix and List based on diagraph
    //Restrictions: None
    class Program
    {
        //Adjacency Matrix
        static int[,] colorMatrix = new int[,]
        {
                          /* RED */      /* INDIGO */    /* YELLOW */     /* BLUE */     /* VIOLET */     /* GREY */     /* ORANGE */     /* GREEN */
            /* RED */    {    (-1),          (1),            (-1),           (-1),           (-1),          (5),           (-1),           (-1)},
            /* INDIGO */ {    (-1),         (-1),             (8),            (1),          ( -1),         (-1),           (-1),           (-1)},
            /* YELLOW */ {    (-1),         (-1),            (-1),           (-1),           (-1),         (-1),           (-1),            (6)},
            /* BLUE */   {    (-1),          (1),            (-1),           (-1),           (-1),          (0),           (-1),           (-1)},
            /* VIOLET */ {    (-1),         (-1),             (1),           (-1),           (-1),         (-1),           (-1),           (-1)},
            /* GREY */   {    (-1),         (-1),            (-1),            (0),           (-1),         (-1),            (1),           (-1)},
            /* ORANGE */ {    (-1),         (-1),            (-1),           (-1),            (1),         (-1),           (-1),           (-1)},
            /* GREEN */  {    (-1),         (-1),            (-1),           (-1),           (-1),         (-1),           (-1),           (-1)}
        };

        //Adjacency List
        static (int, int)[][] colorList = new (int, int)[][]
        {
        /* RED */       new (int, int)[] {(1, 1)},
        /* INDIGO */    new (int, int)[] {(2, 8), (3, 1)},
        /* YELLOW */    new (int, int)[] {(7, 6)},
        /* BLUE */      new (int, int)[] {(1, 1), (5, 0)},
        /* VIOLET */    new (int, int)[] {(6, 1)},
        /* GREY */      new (int, int)[] {(3, 0), (6, 1)},
        /* ORANGE */    new (int, int)[] {(4, 1)},
        /* GREEN */     null
        };

        //Method: DFS
        //Purpose: Attempt at a depth first search
        //Restrictions: None
        static void DFS(int nState)
        {
            bool[] visited = new bool[colorList.Length];

            DFSUtil(nState, ref visited);
        }

        static void DFSUtil(int v, ref bool[] visited)
        {
            visited[v] = true;

            int[] thisStateList = colorList[v];
        }

        static void Main(string[] args)
        {






        }
    }
}
