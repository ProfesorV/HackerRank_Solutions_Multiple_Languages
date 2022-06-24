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
    static long countInversions(int[] arr) {
        //if condition (int[].Length == 1)
        if (arr.Length == 1) return 0;
        //set to
        var mid = arr.Length / 2;
        //set to create new int[int]
        var left = new int[mid];
        //set to create new int[int[].Length-int]
        var right = new int[arr.Length - mid];
        //for condition(int < int[].Length)
        for (var index = 0; index < left.Length; index++)
            //set to
            left[index] = arr[index];
        //for condition (int < int[].Length)
        for (var index = 0; index < right.Length; index++)
            //set to
            right[index] = arr[mid + index];
        //set to apply function(int[]) + apply function(int[])
        var result = countInversions(left) + countInversions(right);
        //set to
        var l = 0;
        var r = 0;
        //while condition ( || )
        while (l < left.Length || r < right.Length)
        {
            //if condition (== || &&)
            if (l == left.Length || (r < right.Length && right[r] < left[l]))
            {
                //set to
                arr[r + l] = right[r];
                //increment
                r++;
                //augment by +=
                result += left.Length - l;
            }
            else
            {
                //set to
                arr[r + l] = left[l];
                //increment
                l++;
            }
        }
        //return
        return result;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            long result = countInversions(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
