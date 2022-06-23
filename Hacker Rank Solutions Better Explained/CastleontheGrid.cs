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

        public Point(int x, int y)
        {
            //set to
            X = x;
            //set to
            Y = y;
        }
    }
    // string[], 4 ints
    static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
    {
        //set to create new
        var xMoves = new[] { 1, 0, -1, 0 };
        //set to create new
        var yMoves = new[] { 0, 1, 0, -1 };
        //set to create new bool[string[].Length,]
        var visited = new bool[grid.Length, grid.Length];
        //set to create new int
        var stepsToReach = new int[grid.Length, grid.Length];
        //set to create new Queue<Point>
        var queue = new Queue<Point>();
        //apply function .Enqueue(create new)
        queue.Enqueue(new Point(startX, startY));
        //set to
        stepsToReach[startX, startY] = 0;
        //set to
        visited[startX, startY] = true;
        //while condition
        while (queue.Count > 0)
        {
            //set to apply function
            var current = queue.Dequeue();
            //for condition (int < int[].Length)
            for (var directionIndex = 0; directionIndex < xMoves.Length; directionIndex++)
            {
                //set to
                var counter = 1;
                //while condition apply function
                while (IsValid(grid,
                    current.X + xMoves[directionIndex] * counter,
                    current.Y + yMoves[directionIndex] * counter))
                {
                    //set to calculate
                    var x = current.X + xMoves[directionIndex] * counter;
                    //set to calculate
                    var y = current.Y + yMoves[directionIndex] * counter;
                    counter++;
                    //if condition (&&)
                    if (x == goalX && y == goalY)
                    //return
                        return stepsToReach[current.X, current.Y] + 1;
                    //if condition ()
                    if (visited[x, y]) continue;
                    //set to calculate
                    stepsToReach[x, y] = stepsToReach[current.X, current.Y] + 1;
                    //set to
                    visited[x, y] = true;
                    //apply function enqueue(create new)
                    queue.Enqueue(new Point(x, y));
                }
            }
        }
        //create new
        throw new Exception("No path found.");
    }
    //string[], int, int
    static bool IsValid(string[] grid, int x, int y)
    {
        //return 4 && and != 
        return x >= 0 &&
            y >= 0 &&
            x < grid.Length &&
            y < grid.Length &&
            grid[x][y] != 'X';
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string[] grid = new string [n];

        for (int i = 0; i < n; i++) {
            string gridItem = Console.ReadLine();
            grid[i] = gridItem;
        }

        string[] startXStartY = Console.ReadLine().Split(' ');

        int startX = Convert.ToInt32(startXStartY[0]);

        int startY = Convert.ToInt32(startXStartY[1]);

        int goalX = Convert.ToInt32(startXStartY[2]);

        int goalY = Convert.ToInt32(startXStartY[3]);

        int result = minimumMoves(grid, startX, startY, goalX, goalY);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
