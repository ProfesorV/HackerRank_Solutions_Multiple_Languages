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

class Solution
{
    // int[]
    static int cost(int[] B)
    {
        //set to
        var ifOnePicked = 0;
        var ifValuePicked = 0;
        //for condition (int<int[].Length)
        for (var index = 1; index < B.Length; index++)
        {
            //set to int[int]-1
            var fromOneToValue = B[index] - 1;
            //set to int[int-1]-1
            var fromValueToOne = B[index - 1] - 1;
            //set to apply function .Abs(int[int]-int[int-1])
            var fromPreviousValueToValue = Math.Abs(B[index] - B[index - 1]);
            //set to apply function .Abs(int, int + int)
            var nextIfOnePicked = Math.Max(ifOnePicked, ifValuePicked + fromValueToOne);
            //set to apply function .Abs(int + int, int + int)
            var nextIfValuePicked = Math.Max(ifValuePicked + fromPreviousValueToValue, ifOnePicked + fromOneToValue);
            //set to
            ifOnePicked = nextIfOnePicked;
            ifValuePicked = nextIfValuePicked;
        }
        //return apply function .Max(int,int)
        return Math.Max(ifOnePicked, ifValuePicked);
    }
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] B = Array.ConvertAll(Console.ReadLine().Split(' '), BTemp => Convert.ToInt32(BTemp))
            ;
            int result = cost(B);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
