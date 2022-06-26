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
    static int minimumAbsoluteDifference(int[] arr) {
        //apply function .Sort(int[])
        Array.Sort(arr);
        //set to 
        var result = int.MaxValue;
        //for condition (int < int[].Length)
        for (int index = 1; index < arr.Length; index++)
        {
            //set to int[int]-int[int-1]
            var diff = arr[index] - arr[index - 1];
            //if condition (==)
            if(diff == 0) return 0;
            //if condition (int > int) set to
            if(result > diff) result = diff;
        }
        //return
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int result = minimumAbsoluteDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
