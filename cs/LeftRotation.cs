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

    // int[], int
    static int[] rotateLeft(int[] pIntArra, int d) {
     //set to
    var effective = pIntArra.Length - (d % a.Length);
        //set to create new int[int[].Length]
        var intArrResult = new int[pIntArra.Length];
        //for condition (int < int[].Length)
        for (int index = 0; index < pIntArra.Length; index++)
            //set to
            intArrResult[(index + effective) % pIntArra.Length] = pIntArra[index];
        //return
        return intArrResult;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
        int[] intArrResult = rotateLeft(a, d);

        textWriter.WriteLine(string.Join(" ", intArrResult));

        textWriter.Flush();
        textWriter.Close();
    }
}
