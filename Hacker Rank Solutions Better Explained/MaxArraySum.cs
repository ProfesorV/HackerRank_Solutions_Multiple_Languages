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

    // int[]
    static int maxSubsetSum(int[] arr)
    {
        //set to create new List<int>
        var list = new List<int>();
        //apply function .Add()
        list.Add(arr[0]);
        //apply function .Add()
        list.Add(Math.Max(arr[0], arr[1]));
        //foreach (int in int.Skip(2))
        foreach(var a in arr.Skip(2))
            //apply function .Add(apply function .Max( apply function .Max()))
            list.Add(Math.Max(Math.Max(list[list.Count - 2] + a, a), list[list.Count - 1]));
        //return List<int>[List<int>.Count-1]
        return list[list.Count - 1];
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = maxSubsetSum(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
