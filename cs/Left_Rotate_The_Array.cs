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

    //int[], int
    static int[] rotLeft(int[] a, int d) {
        //int = int[].Length - (int % int[].Length) set to calculate
var effective = a.Length - (d % a.Length);
//int[] = int[int[].Length] set to
        var result = new int[a.Length];
        //for(int < int[].Length) loop condition
        for (int index = 0; index < a.Length; index++)
        //int[(int + int)%int[].Length]=int[int] set to calculate
            result[(index + effective) % a.Length] = a[index];
            //return int[] 
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
        int[] result = rotLeft(a, d);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
