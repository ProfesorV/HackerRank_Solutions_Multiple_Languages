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

    //int, int[][]
    static long arrayManipulation(int n, int[][] queries) {
        //set to create new
        var array = new long[n+1];
        //for
        for (var index = 0; index < array.Length; index++)
        {
            //set to
            array[index] = 0;
        }
        //set to
        long x = 0;
        //set to
        long max = 0;
        //foreach
        foreach (var query in queries)
        {
            //add to
            array[query[0]] += query[2];
            //if <=, -=
            if ((query[1] + 1) <= n) array[query[1] + 1] -= query[2];
        }
        //for
        for (var index = 0; index < array.Length; index++)
        {
            //+=
            x += array[index];
            //if < set to
            if (max < x) max = x;
        }
        //return
        return max;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        for (int i = 0; i < m; i++) {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = arrayManipulation(n, queries);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
