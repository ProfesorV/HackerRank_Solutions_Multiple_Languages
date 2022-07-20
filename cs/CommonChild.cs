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
    static int commonChild(string pStringOne, string pStringTwo)
    {
        //new [.Length+1, Length+1]
        var intArr = new int[pStringOne.Length + 1, pStringTwo.Length + 1];
        //for < .GetLength()
        for (int i = 0; i < intArr.GetLength(0); i++)
            //[,]=
            intArr[i, 0] = 0;
        //for < .GetLength()
        for (int i = 0; i < intArr.GetLength(1); i++)
            //[,] =
            intArr[0, i] = 0;
         //for < .GetLength()
        for (int i = 1; i < intArr.GetLength(0); i++)
         //for < .GetLength()
            for (int j = 1; j < intArr.GetLength(1); j++)
            //if [-1] == [-1]
                if (pStringOne[i - 1] == pStringTwo[j - 1])
                // [,] = [-1,-1] + 1
                    intArr[i, j] = intArr[i - 1, j - 1] + 1;
                else
                //[,] = .Max([,-1],[-1,])
                    intArr[i, j] = Math.Max(intArr[i, j - 1], intArr[i - 1, j]);
        //return [.GetLength()-1, GetLength()-1]
        return intArr[intArr.GetLength(0) - 1, intArr.GetLength(1) - 1];
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string pStringOne = Console.ReadLine();

        string pStringTwo = Console.ReadLine();

        int result = commonChild(pStringOne, pStringTwo);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
