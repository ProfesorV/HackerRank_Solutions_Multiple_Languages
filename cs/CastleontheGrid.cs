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
        //readonly
        public readonly int X;
        //readonly
        public readonly int Y;
        public Point(int x, int y)
        {
            //=
            X = x;
            //=
            Y = y;
        }
    }
    // string[], int, int, int, int
    static int minimumMoves(string[] pStringArrGrid, 
    int startX, int startY, int goalX, int goalY)
    {
        //= new [] {,,,}
        var intArrXMoves = new[] { 1, 0, -1, 0 };
        //= new [] {,,,}
        var intArrYMoves = new[] { 0, 1, 0, -1 };
        //= new [.Length,.Length]
        var boolArrVisited = new bool[pStringArrGrid.Length, pStringArrGrid.Length];
        //= new [.Length, .Length]
        var intArrSteps = new int[pStringArrGrid.Length, pStringArrGrid.Length];
        //= new < >
        var pointQueue = new Queue<Point>();
        //.Enqueue(new Point(,))
        pointQueue.Enqueue(new Point(startX, startY));
        //[,]
        intArrSteps[startX, startY] = 0;
        //[,]
        boolArrVisited[startX, startY] = true;
        //while .Count >
        while (pointQueue.Count > 0)
        {
            //= .Dequeue()
            var current = pointQueue.Dequeue();
            //for < .Length
            for (var directionIndex = 0; 
            directionIndex < intArrXMoves.Length; directionIndex++)
            {
                //=
                var counter = 1;
                //while IsValid(, . + [] * ,. + [] *)
                while (IsValid(pStringArrGrid,
                    current.X + intArrXMoves[directionIndex] * counter,
                    current.Y + intArrYMoves[directionIndex] * counter))
                {
                    //= . + [] *
                    var x = current.X + intArrXMoves[directionIndex] * counter;
                    //= . + [] *
                    var y = current.Y + intArrYMoves[directionIndex] * counter;
                    //++
                    counter++;
                    //if == && ==
                    if (x == goalX && y == goalY)
                    //return [,]+1
                        return intArrSteps[current.X, current.Y] + 1;
                    //if [,]
                    if (boolArrVisited[x, y]) continue;
                    //[,] = [.,.]+1
                    intArrSteps[x, y] = intArrSteps[current.X, current.Y] + 1;
                    //[,] =
                    boolArrVisited[x, y] = true;
                    //.Enqueue(new Point(,))
                    pointQueue.Enqueue(new Point(x, y));
                }
            }
        }
        //throw new Exception()
        throw new Exception("No path found.");
    }
    //string[], int, int
    static bool IsValid(string[] pStringArrGrid, 
    int x, int y)
    {
        //return >= && >= && < .Length && < .Length && [][]!= '' 
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
