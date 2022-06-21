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

    // int, int[]
    static long candies(int n, int[] arr) {
        //set to create new
        var candies = new int[arr.Length];
        //set to
        var sum = 0L;
        //set to
        var candiesCount = 1;
        //for condition
        for (var index = 0; index < n; index++)
        {
            //set to
            candies[index] = candiesCount;
            //augment by
            sum += candiesCount;
            //if condition &&
            if (index + 1 < n && arr[index] < arr[index + 1])
                //increment
                candiesCount++;
            else
                //set to
                candiesCount = 1;
        }
        //set to
        candiesCount = candies[n - 1];
        //for condition
        for (var index = n - 1; index >= 0; index--)
        {
            //set to apply function
            var diff = Math.Max(candies[index], candiesCount) - candies[index];
            //augment by
            candies[index] += diff;
            //augment by
            sum += diff;
            //if condition &&
            if (index > 0 && arr[index - 1] > arr[index])
                //increment
                candiesCount++;
            else
                //set to
                candiesCount = 1;
        }
        //return 
        return sum;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int [n];

        for (int i = 0; i < n; i++) {
            int arrItem = Convert.ToInt32(Console.ReadLine());
            arr[i] = arrItem;
        }

        long result = candies(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
