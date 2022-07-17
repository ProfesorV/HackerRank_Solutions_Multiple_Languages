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

    // int[]
    static int equal(int[] pIntArr)
    {
        //Array.Sort(int[]) apply function
        Array.Sort(pIntArr);
        //int = int[0] set to
        var min = pIntArr[0];
        //for(int < int[].Length) loop condition
        for (int index = 0; index < pIntArr.Length; index++)
        //int[int] -= int reduce
            pIntArr[index] -= min;
            //int = int.MaxValue set to
        var result = int.MaxValue;
        //for(int < 5) loop condition
        for (int index = 0; index < 5; index++)
        //int = Math.Min(int, CalcFor(int[],int)) set to
            result = Math.Min(result, CalcFor(pIntArr, index));
            //int
        return result;
    }
    //int[], int
    private static int CalcFor(int[] pIntArr, int delta)
    {
        //int set to
        var total = 0;
        //for(int < int[].Length) loop condition
        for (int index = 0; index < pIntArr.Length; index++)
        {
            //int = int[int]+int set to calculate 
            var holderVar = pIntArr[index] + delta;
            //int = int / 5 set to calculate
            var fives = holderVar / 5;
            //int %= 5 set to modulus 5
            holderVar %= 5;
            //int = int / 2 set to calculate
            var twos = holderVar / 2;
            //int %= 2 set to modulus 2
            holderVar %= 2; 
            //int += int + int + int % 2 augment by
            total += fives + twos + holderVar % 2;
        }
        //int
        return total;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] pIntArr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            int result = equal(pIntArr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
