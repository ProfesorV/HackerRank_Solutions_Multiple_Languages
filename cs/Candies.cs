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
    static long intArrCandies(int n, int[] pIntArr) {
        //set to create new
        var intArrCandies = new int[pIntArr.Length];
        //set to
        var sum = 0L;
        //set to
        var candiesCount = 1;
        //for <
        for (var index = 0; index < n; index++)
        {
            //set to
            intArrCandies[index] = candiesCount;
            //+=
            sum += candiesCount;
            //if < && <
            if (index + 1 < n && pIntArr[index] < pIntArr[index + 1])
                //++
                candiesCount++;
            else
                //set to
                candiesCount = 1;
        }
        //set to
        candiesCount = intArrCandies[n - 1];
        //for >=
        for (var index = n - 1; index >= 0; index--)
        {
            //set to
            var diff = Math.Max(intArrCandies[index], candiesCount) 
            - intArrCandies[index];
            //+=
            intArrCandies[index] += diff;
            //+=
            sum += diff;
            //if > && >
            if (index > 0 && pIntArr[index - 1] > pIntArr[index])
                //++
                candiesCount++;
            else
                //=
                candiesCount = 1;
        }
        //return 
        return sum;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] pIntArr = new int [n];

        for (int i = 0; i < n; i++) {
            int arrItem = Convert.ToInt32(Console.ReadLine());
            pIntArr[i] = arrItem;
        }

        long result = intArrCandies(n, pIntArr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
