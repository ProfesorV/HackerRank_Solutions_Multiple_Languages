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
        //=
        var sum = 0;
        //for < .Length
        for (var row = 0; row < pIntMuDiArr.Length; row++)
        //for < [].Length
            for (var col = 0; col < pIntMuDiArr[0].Length; col++)
            //+= Count(,,)
                sum += Count(pIntMuDiArr, row, col);
        //return
        return sum;
    }
    //int[][], int, int
    private static int Count(int[][] pIntMDArr, int row, int col)
    {
        //=
        var sum = 2;
        //new []{,,,}
        var intArrRowDelta = new[] { -1, 0, 1, 0 };
        var intArrColDelta = new[] { 0, 1, 0, -1 };
        //for < .Length
        for (var index = 0; index < intArrRowDelta.Length; index++)
        {
            //= + []
            var r = row + intArrRowDelta[index];
            //= + []
            var c = col + intArrColDelta[index];
            //if isValid(,,)
            if (IsValid(pIntMDArr, r, c))
            //+= .Max(,[][]-[][])
                sum += Math.Max(0, pIntMDArr[row][col] - pIntMDArr[r][c]);
            else
            //+= [][]
                sum += pIntMDArr[row][col];
        }
        //return
        return sum;
    }
    //int[][], int, int
    private static bool IsValid(int[][] pIntMuDArr, int row, int col)
    {
        //return >=  && >= && < .Length &&  < [].Length 
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
