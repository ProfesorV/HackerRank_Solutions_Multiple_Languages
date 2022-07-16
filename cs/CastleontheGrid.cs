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
    class Point
    {
        //declare
        public readonly int X;
        //declare
        public readonly int Y;
        //declare
        public Point(int x, int y)
        {
            //set to
            X = x;
            //set to
            Y = y;
        }
    }
    // string[], int, int, int, int
    static int minimumMoves(string[] pStringArrGrid, 
    int startX, int startY, int goalX, int goalY)
    {
        //set to create new
        var intArrXMoves = new[] { 1, 0, -1, 0 };
        //set to create new
        var intArrYMoves = new[] { 0, 1, 0, -1 };
        //set to create new 
        var boolArrVisited = new bool[pStringArrGrid.Length, pStringArrGrid.Length];
        //set to create new 
        var intArrSteps = new int[pStringArrGrid.Length, pStringArrGrid.Length];
        //set to create new 
        var pointQueue = new Queue<Point>();
        //.(create new)
        pointQueue.Enqueue(new Point(startX, startY));
        //set to
        intArrSteps[startX, startY] = 0;
        //set to
        boolArrVisited[startX, startY] = true;
        //while >
        while (pointQueue.Count > 0)
        {
            //set to, .
            var current = pointQueue.Dequeue();
            //for <
            for (var directionIndex = 0; 
            directionIndex < intArrXMoves.Length; directionIndex++)
            {
                //set to
                var counter = 1;
                //while function
                while (IsValid(pStringArrGrid,
                    current.X + intArrXMoves[directionIndex] * counter,
                    current.Y + intArrYMoves[directionIndex] * counter))
                {
                    //set to
                    var x = current.X + intArrXMoves[directionIndex] * counter;
                    //set to
                    var y = current.Y + intArrYMoves[directionIndex] * counter;
                    counter++;
                    //if == && ==
                    if (x == goalX && y == goalY)
                    //return
                        return intArrSteps[current.X, current.Y] + 1;
                    //if
                    if (boolArrVisited[x, y]) continue;
                    //set to
                    intArrSteps[x, y] = intArrSteps[current.X, current.Y] + 1;
                    //set to
                    boolArrVisited[x, y] = true;
                    //.enqueue(create new)
                    pointQueue.Enqueue(new Point(x, y));
                }
            }
        }
        //create new
        throw new Exception("No path found.");
    }
    //string[], int, int
    static bool IsValid(string[] pStringArrGrid, 
    int x, int y)
    {
        //return 4 && and != 
        return x >= 0 &&
            y >= 0 &&
            x < pStringArrGrid.Length &&
            y < pStringArrGrid.Length &&
            pStringArrGrid[x][y] != 'X';
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string[] pStringArrGrid =
         new string [n];

        for (int i = 0; i < n; i++) {
            string gridItem = Console.ReadLine();
            pStringArrGrid[i
            ] = gridItem;
        }

        string[] startXStartY = Console.ReadLine().Split(' ');

        int startX = Convert.ToInt32(startXStartY[0]);

        int startY = Convert.ToInt32(startXStartY[1]);

        int goalX = Convert.ToInt32(startXStartY[2]);

        int goalY = Convert.ToInt32(startXStartY[3]);

        int result = minimumMoves(pStringArrGrid, 
        startX, startY, goalX, goalY);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
