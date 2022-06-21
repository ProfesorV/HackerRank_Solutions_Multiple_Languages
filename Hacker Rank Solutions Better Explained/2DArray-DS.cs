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
        //int[], int[]; set to
        var  xPattern = new [] {0, 1, 2, 1, 0, 1, 2 };
        var  yPattern = new [] {0, 0, 0, 1, 2, 2, 2 };
        //delegate<int, int,int> = (int, int) => {var}; set to
        Func<int, int, int> calculateHourglass = (int x, int y) => {
            //int, set to
            var sum = 0;
            //for(int i < int[].Length); loop condition
            for(var i = 0; i < yPattern.Length; i++){
                //int += int[int + int[int]][int+int[int]]; augment
                sum += arr[y + yPattern[i]][x + xPattern[i]];
            }
            //int
            return sum;
        };
        //int; set to
        var maxSum = int.MinValue;
        //for(int < int[][].Length - 2); loop condition
        for(var y = 0; y < arr.Length - 2; y++){
            //for(int<int[int].Length-2); loop condition
            for(var x = 0; x < arr[y].Length - 2; x++){
                //int = function(x,y); set to
                var temp = calculateHourglass(x, y);
                //if(int > int); if condition
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
