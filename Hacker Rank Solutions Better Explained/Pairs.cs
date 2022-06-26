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
    static int pairs(int k, int[] arr) {
        //apply function .Sort(int[])
        Array.Sort(arr);
        //set to
        var sum = 0;
        //for condition (int < int[].Length)
        for (var index = 0; index < arr.Length; index++)
        {
            //set to int[int]
            var current = arr[index];
            //if (apply function .BinarySearch(int[], int + int) > -1)
            if (Array.BinarySearch(arr, current + k) > -1)
                //increment++
                sum++;
        }
        //return
        return sum;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int result = pairs(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
