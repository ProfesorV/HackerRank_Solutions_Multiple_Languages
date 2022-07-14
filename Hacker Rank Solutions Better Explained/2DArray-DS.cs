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
    
    // int [][]
    static int hourglassSum(int[][] arr) {
        //set to
        var  xPattern = new [] {0, 1, 2, 1, 0, 1, 2 };
        var  yPattern = new [] {0, 0, 0, 1, 2, 2, 2 };
        //delegate name, set to, parameters, pass on
        Func<int, int, int> calculateHourglass = (int x, int y) => {
            //set to
            var sum = 0;
            //for
            for(var i = 0; i < yPattern.Length; i++){
                //add on 
                sum += arr[y + yPattern[i]][x + xPattern[i]];
            }
            //return
            return sum;
        };
        //set to
        var maxSum = int.MinValue;
        //for
        for(var y = 0; y < arr.Length - 2; y++){
            //for
            for(var x = 0; x < arr[y].Length - 2; x++){
                //set to function calculate
                var temp = calculateHourglass(x, y);
                //if, compare, set to
                if(temp > maxSum) maxSum = temp;
            }
        }
        return maxSum;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++) {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
