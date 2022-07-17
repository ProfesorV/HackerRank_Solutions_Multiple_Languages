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

    // int, int[]
    static int getMinimumCost(int k, int[] pIntArrC) {
        //int[].Sort() apply function
        Array.Sort(pIntArrC);
        //int = int[].Length/int+1 set to calculate
        var mainLoopCount = pIntArrC.Length / k + 1;
        //int set to
        var result = 0;
        //for(int < int) loop conditional
        for (var loop = 0; loop < mainLoopCount; loop++)
        {
            //for(int < int) loop conditional
            for (int index = 0; index < k; index++)
            {
                //if(int * int + int > int[].Length) if condition compare
                if (loop * k + index >= pIntArrC.Length)
                    break;
                //int = int[int[].Length-(int*int+int)-1] set to calculate
                var currentOriginal = pIntArrC[pIntArrC.Length - (loop * k + index) - 1];
                //int += int * (int + 1) augment by
                result += currentOriginal * (loop + 1);
            }
        }
        //return int
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int minimumCost = getMinimumCost(k, c);

        textWriter.WriteLine(minimumCost);

        textWriter.Flush();
        textWriter.Close();
    }
}
