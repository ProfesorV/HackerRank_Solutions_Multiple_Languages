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

    //int[]
    static int poisonousPlants(int[] p) {
        //set to create new int[int[].Length]
        var deletedOnDay = new int[p.Length];
        //set to
        var min = p[0];
        //set to
        var max = 0;
        //set to create new Stack<int>
        var stack = new Stack<int>();
        //apply function .Push(0)
        stack.Push(0);
        //for condition (int < int[].Length)
        for (var x = 1; x < p.Length; x++)
        {
            //if condition (int[int] > int[int - 1])
            if (p[x] > p[x - 1])
                //set to
                deletedOnDay[x] = 1;
            //set to apply function .Min(min,int[int])
            min = Math.Min(min, p[x]);
            //while(apply function .Count() > 0 && int[apply function .Peek()]>int[int])
            while (stack.Count() > 0 && p[stack.Peek()] >= p[x])
            {
                //if condition(int[int]>int)
                if (p[x] > min)
                    //set to .Max(int[int], int[apply function .Peek()]+1)
                    deletedOnDay[x] = Math.Max(deletedOnDay[x], deletedOnDay[stack.Peek()] + 1);
                //apply function .Pop()
                stack.Pop();
            }
            //set to apply function .Max()
            max = Math.Max(max, deletedOnDay[x]);
            //apply function .Push(int)
            stack.Push(x);
        }
        //return
        return max;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] p = Array.ConvertAll(Console.ReadLine().Split(' '), pTemp => Convert.ToInt32(pTemp))
        ;
        int result = poisonousPlants(p);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
