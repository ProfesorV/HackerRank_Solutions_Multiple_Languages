// Common Child
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

    //string, string
    static int commonChild(string s1, string s2)
    {
        //set to create new int[string.Length + 1, ]
        var arry = new int[s1.Length + 1, s2.Length + 1];
        //for condition (int < int[].GetLength(0))
        for (int i = 0; i < arry.GetLength(0); i++)
        //set to 
            arry[i, 0] = 0;
        //for condition (int < int[].GetLength(1))
        for (int i = 0; i < arry.GetLength(1); i++)
        //set to 
            arry[0, i] = 0;
         //for condition (int < int[].GetLength(0))
        for (int i = 1; i < arry.GetLength(0); i++)
         //for condition (int < int[].GetLength(1))
            for (int j = 1; j < arry.GetLength(1); j++)
            //if condition (string[int-1]==string[int-1])
                if (s1[i - 1] == s2[j - 1])
                //set to calculate
                    arry[i, j] = arry[i - 1, j - 1] + 1;
                else
                //set to apply function .Max() int[int,int-1], int[int-1,int]
                    arry[i, j] = Math.Max(arry[i, j - 1], arry[i - 1, j]);
        //return int[int[].GetLength(0)-1, int[].GetLength(1)-1]
        return arry[arry.GetLength(0) - 1, arry.GetLength(1) - 1];
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = commonChild(s1, s2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
