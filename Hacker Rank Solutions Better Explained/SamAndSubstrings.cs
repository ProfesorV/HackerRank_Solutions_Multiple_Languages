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
    // string 
    static int substrings(string n)
    {
        //set to
        var mod = 1_000_000_007;
        //set to string.Length
        var len = n.Length;
        var sum = 0L;
        //set to create new long[int]
        var map = new long[len];
        //long[int-1]=1
        map[len - 1] = 1;
        //fo condition (int >=0)
        for (var index = len - 2; index >= 0; index--)
            //long[int] = (long[int+1*10+1])% int
            map[index] = (map[index + 1] * 10 + 1) % mod;
        //for condition (int < int)
        for (var index = 0; index < len; index++)
        {
            //set to apply function .Parse(string[int].ToString)
            var val = int.Parse(n[index].ToString());
            //set to calculate
            var temp = val * map[index] * (index + 1) % mod;
            //augment by
            sum += temp;
            //mod by
            sum %= mod;
        }
        //return
        return (int)sum;
    }
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string n = Console.ReadLine();

        int result = substrings(n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
