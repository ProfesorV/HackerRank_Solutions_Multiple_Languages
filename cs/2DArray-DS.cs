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
    
    // [][]
    static int hourglassSum(int[][] pIntArr) {
        //= new []{}
        var  intArrX = new [] {0, 1, 2, 1, 0, 1, 2 };
        var  intArrY = new [] {0, 0, 0, 1, 2, 2, 2 };
        //<,,> = (,) => {}
        Func<int, int, int> delegateCalculateHourglass = (int x, int y) => {
            //=
            var sum = 0;
            //for <
            for(var i = 0; i < intArrY.Length; i++){
                //+= [+[]][+[]]
                sum += pIntArr[y + intArrY[i]][x + intArrX[i]];
            }
            //return
            return sum;
        };
        //=
        var maxSum = int.MinValue;
        //for <
        for(var y = 0; y < pIntArr.Length - 2; y++){
            //for <[].Length-2
            for(var x = 0; x < pIntArr[y].Length - 2; x++){
                //= delegateCalculateHourglass(,)
                var temp = delegateCalculateHourglass(x, y);
                //if > =
                if(temp > maxSum) maxSum = temp;
            }
        }
        return maxSum;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] pIntArr = new int[6][];

        for (int i = 0; i < 6; i++) {
            pIntArr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(pIntArr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
