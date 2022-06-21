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

class Solution
{

    // int, int int
    static long countArray(int n, int k, int x)
    {
        //long set to condition
        var picked = x == 1 ? 1L : 0L;
        //long set to condition
        var notPicked = x == 1 ? 0L : 1L;
        //for (int < int) loop conditional
        for (var index = 1; index < n; index++)
        {
            //long set to
            var newPicked = notPicked;
            //long = (long * (int -1)% 1_000_000_007 + long * (int-2) % 1_000_000_007) % 1_000_000_007 set to condition
            notPicked = (picked * (k - 1) % 1_000_000_007 + notPicked * (k - 2) % 1_000_000_007) % 1_000_000_007;
            //long = long set to
            picked = newPicked;
        }
        //return long
        return picked;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nkx = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nkx[0]);

        int k = Convert.ToInt32(nkx[1]);

        int x = Convert.ToInt32(nkx[2]);

        long answer = countArray(n, k, x);

        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}
