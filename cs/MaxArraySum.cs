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
    static int maxSubsetSum(int[] pIntArr)
    {
        //set to create new List<int>
        var listInt = new List<int>();
        //apply function .Add()
        listInt.Add(pIntArr[0]);
        //apply function .Add()
        listInt.Add(Math.Max(pIntArr[0], pIntArr[1]));
        //foreach (int in int.Skip(2))
        foreach(var a in pIntArr.Skip(2))
            //apply function .Add(apply function .Max( apply function .Max()))
            listInt.Add(Math.Max(Math.Max(listInt[listInt.Count - 2] + a, a), 
            listInt[listInt.Count - 1]));
        //return List<int>[List<int>.Count-1]
        return listInt[listInt.Count - 1];
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] pIntArr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = maxSubsetSum(pIntArr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
