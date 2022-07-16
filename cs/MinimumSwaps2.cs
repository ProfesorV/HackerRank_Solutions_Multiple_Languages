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

    // int []
    static int minimumSwaps(int[] arr) {
        //set to
        var result = 0;
        //for condition (int < int[].Length)
        for (var i = 0; i < arr.Length - 1; i++)
        {
            //set to
            var temp = arr[i];
            //set to
            var wentIn = false;
            //while condition (int != int[int-1])
            while (temp != arr[temp - 1])
            {
                //set to
                wentIn = true;
                //set to
                var temp2 = arr[temp - 1];
                //set to int[int-1]
                arr[temp - 1] = temp;
                //set to
                temp = temp2;
                //increment
                result++;
            }
            //if condition
            if(wentIn)
            //decrement
            result--;
        }
        //return
        return result;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = minimumSwaps(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
