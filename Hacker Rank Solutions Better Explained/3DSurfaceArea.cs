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

    // int [][]
    static int surfaceArea(int[][] pIntMuDiArr)
    {
        //set to
        var sum = 0;
        //for
        for (var row = 0; row < pIntMuDiArr.Length; row++)
        //for 
            for (var col = 0; col < pIntMuDiArr[0].Length; col++)
            //add to
                sum += Count(pIntMuDiArr, row, col);
        //return
        return sum;
    }
    //int[][], int, int
    private static int Count(int[][] pIntMDArr, int row, int col)
    {
        //set to
        var sum = 2;
        //set to create new
        var intArrRowDelta = new[] { -1, 0, 1, 0 };
        //set to create new
        var intArrColDelta = new[] { 0, 1, 0, -1 };
        //for
        for (var index = 0; index < intArrRowDelta.Length; index++)
        {
            //set to
            var r = row + intArrRowDelta[index];
            //set to
            var c = col + intArrColDelta[index];
            //if, function apply
            if (IsValid(pIntMDArr, r, c))
            //add to
                sum += Math.Max(0, pIntMDArr[row][col] - pIntMDArr[r][c]);
            else
            //add to
                sum += pIntMDArr[row][col];
        }
        //return
        return sum;
    }
    //int[][], int, int
    private static bool IsValid(int[][] pIntMuDArr, int row, int col)
    {
        //return >=,  && >= , && <, &&  < 
        return row >= 0 && col >= 0 && row < pIntMuDArr.Length && col < pIntMuDArr[0].Length;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] HW = Console.ReadLine().Split(' ');

        int H = Convert.ToInt32(HW[0]);

        int W = Convert.ToInt32(HW[1]);

        int[][] pIntMuDiArr = new int[H][];

        for (int i = 0; i < H; i++)
        {
            pIntMuDiArr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), ATemp => Convert.ToInt32(ATemp));
        }

        int result = surfaceArea(pIntMuDiArr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
