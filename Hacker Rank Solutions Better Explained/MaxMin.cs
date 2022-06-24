// Max Min
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

    //int, int[]
    static int maxMin(int k, int[] arr) {
        //apply function .Sort(int[])
        Array.Sort(arr);
        //set to
        var min = int.MaxValue;
        //for condition (ind < int[].Length-int+1)
        for(var index = 0; index < arr.Length - k + 1; index++)
            //set to apply function Min()
            min = Math.Min(min, arr[index + k - 1] - arr[index]);
        //return
        return min;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int k = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int [n];

        for (int i = 0; i < n; i++) {
            int arrItem = Convert.ToInt32(Console.ReadLine());
            arr[i] = arrItem;
        }

        int result = maxMin(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
