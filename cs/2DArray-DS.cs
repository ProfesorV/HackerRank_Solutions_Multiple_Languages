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
    static int hourglassSum(int[][] pIntArr) {
        //set to
        var  intArrX = new [] {0, 1, 2, 1, 0, 1, 2 };
        var  intArrY = new [] {0, 0, 0, 1, 2, 2, 2 };
        //delegate name, set to, parameters, pass on
        Func<int, int, int> delegateCalculateHourglass = (int x, int y) => {
            //set to
            var sum = 0;
            //for
            for(var i = 0; i < intArrY.Length; i++){
                //add on 
                sum += paraIntArr[y + intArrY[i]][x + intArrX[i]];
            }
            //return
            return sum;
        };
        //set to
        var maxSum = int.MinValue;
        //for
        for(var y = 0; y < paraIntArr.Length - 2; y++){
            //for
            for(var x = 0; x < paraIntArr[y].Length - 2; x++){
                //set to function calculate
                var temp = delegateCalculateHourglass(x, y);
                //if, compare, set to
                if(temp > maxSum) maxSum = temp;
            }
        }
        return maxSum;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] paraIntArr = new int[6][];

        for (int i = 0; i < 6; i++) {
            paraIntArr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(paraIntArr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
