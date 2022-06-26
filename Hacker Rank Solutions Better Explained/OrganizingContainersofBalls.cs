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

    //int[][]
    static string organizingContainers(int[][] container) {
        //set to int[][].Length
        var n = container.Length;
        //set to create new int[int]
        var balls = new int[n];
        var boxes = new int[n];
        //for condition (int < int)
        for(var i = 0; i < n; i++)
        {
            //set to
            var sumBalls = 0;
            var sumBoxes = 0;
            //for condition (int < int)
            for(var j = 0; j < n; j++)
            {
                //augment by += int[int][int]
                sumBalls += container[i][j];
                sumBoxes += container[j][i];
            }
            //set to
            balls[i] = sumBalls;
            //set to
            boxes[i] = sumBoxes;
        }
        //apply function .Sort(int[])
        Array.Sort(balls);
        Array.Sort(boxes);
        //for condition(int < int)
        for(var i = 0; i < n; i++)
            //if (int[int]!= int[int])
            if(balls[i] != boxes[i])
                return "Impossible";
        //return
        return "Possible";
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] container = new int[n][];

            for (int i = 0; i < n; i++) {
                container[i] = Array.ConvertAll(Console.ReadLine().Split(' '), containerTemp => Convert.ToInt32(containerTemp));
            }

            string result = organizingContainers(container);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
