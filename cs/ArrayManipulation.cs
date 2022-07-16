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
    static long longArrayManipulation(int n, int[][] multiDimIntQueries) {
        //set to create new
        var longArray = new long[n+1];
        //for
        for (var index = 0; index < longArray.Length; index++)
        {
            //set to
            longArray[index] = 0;
        }
        //set to
        long x = 0;
        //set to
        long max = 0;
        //foreach
        foreach (var query in multiDimIntQueries)
        {
            //add to
            longArray[query[0]] += query[2];
            //if <=, -=
            if ((query[1] + 1) <= n) longArray[query[1] + 1] -= query[2];
        }
        //for
        for (var index = 0; index < longArray.Length; index++)
        {
            //+=
            x += longArray[index];
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

        int[][] multiDimIntQueries = new int[m][];

        for (int i = 0; i < m; i++) {
            multiDimIntQueries[i] = longArray.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = longArrayManipulation(n, multiDimIntQueries);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
