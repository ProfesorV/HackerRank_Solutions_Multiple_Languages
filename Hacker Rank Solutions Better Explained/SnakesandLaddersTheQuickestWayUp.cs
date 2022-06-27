using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {
    //int[][], int[][]
    static int quickestWayUp(int[][] ladders, int[][] snakes)
    {
        //set to create new SortedList<int,int>
        var jumps = new SortedList<int, int>();
        //foreach condition (int[] in int[][])
        foreach (var item in ladders)
            //apply function .Add(int[0]-1, int[1]-1)
            jumps.Add(item[0] - 1, item[1] - 1);
        //foreach condition (int[] in int[][])
        foreach (var item in snakes)
            //apply function .Add(int[0]-1, int[1]-1)
            jumps.Add(item[0] - 1, item[1] - 1);
        //set to create new int[100]
        var board = new int[100];
        //set to create new bool[100]
        var visited = new bool[100];
        //set to create new Queue<int>
        var queue = new Queue<int>();
        //apply function .Enqueue
        queue.Enqueue(0);
        //while condition (Queue<int> >0)
        while (queue.Count > 0)
        {
            //set to apply function .Dequeue()
            var current = queue.Dequeue();
            //if condition (bool[int])
            if (visited[current]) continue;
            //set to
            visited[current] = true;
            //for condition (int<=6)
            for (int index = 1; index <= 6; index++)
            {
                //set to calculate
                var next  = current + index;
                //if condition (int[int]>0)
                if (board[next] > 0) continue;
                //set to calculate
                var nextCount = board[current] + 1;
                //if condition (apply function .ContainsKey(int))
                if (jumps.ContainsKey(next))
                {
                    //set to
                    visited[next] = true;
                    board[next] = nextCount;
                    next = jumps[next];
                }
                //if condition (int >= 99) return
                if(next >= 99) return nextCount;
                //set to
                board[next] = nextCount;
                //apply function .Enqueue(int)
                queue.Enqueue(next);
            }
        }
        //return
        return -1;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] ladders = new int[n][];

            for (int i = 0; i < n; i++) {
                ladders[i] = Array.ConvertAll(Console.ReadLine().Split(' '), laddersTemp => Convert.ToInt32(laddersTemp));
            }

            int m = Convert.ToInt32(Console.ReadLine());

            int[][] snakes = new int[m][];

            for (int i = 0; i < m; i++) {
                snakes[i] = Array.ConvertAll(Console.ReadLine().Split(' '), snakesTemp => Convert.ToInt32(snakesTemp));
            }

            int result = quickestWayUp(ladders, snakes);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
