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

    // int[][]
    static int formingMagicSquare(int[][] pIntMultiDimArr)
    {
        //set to create new List<int[,]<
        var listIntMultiDimArr = new List<int[,]>{new int[,]
        {
            { 8, 1, 6 },
            { 3, 5, 7 },
            { 4, 9, 2 },
        }};
        //apply function .Add(.FlipMultiDim(List<int[,]>)
        listIntMultiDimArr.Add(FlipMultiDim(listIntMultiDimArr[0]));
        //apply function .AddRange(RotateMultiDim())
        listIntMultiDimArr.AddRange(RotateMultiDim(listIntMultiDimArr[0], 4));
        listIntMultiDimArr.AddRange(RotateMultiDim(listIntMultiDimArr[1], 4));
        //set to
        var min = int.MaxValue;
        //foreach condition
        foreach (var item in listIntMultiDimArr)
        {
            //set to
            var sum = 0;
            //for condition (int < int)
            for (var row = 0; row < 3; row++)
                //for condition (int < int)
                for (var col = 0; col < 3; col++)
                    //augment += apply function .Abs()
                    sum += Math.Abs(item[row, col] - s[row][col]);
            //set to
            min = Math.Min(sum, min);
        }
        //return
        return min;
    }
    //int[,], int
    private static IEnumerable<int[,]> RotateMultiDim(int[,] pIntMultiDArr, int count)
    {
        //if condition (==)
        if (count == 0) yield break;
        //set to create new int [,]
        var result = new int[3, 3];
        //for condition (int < int)
        for (var row = 0; row < 3; row++)
            //for condition (int, int)
            for (var col = 0; col < 3; col++)
                //set to int[int,2-int]
                result[row, col] = pIntMultiDArr[col, 2 - row];
        //return
        yield return result;
        //foreach condition
        foreach (var item in RotateMultiDim(result, count - 1))
            //return
            yield return item;
    }
    //int[,]
    static int[,] FlipMultiDim(int[,] pIntMultiDArr)
    {
        //set to create new int[]
        var result = new int[3, 3];
        //for condition (int < int)
        for (var row = 0; row < 3; row++)
            //for condition (int < int)
            for (var col = 0; col < 3; col++)
                //set to = int[int,2-int]
                result[row, col] = pIntMultiDArr[row, 2 - col];
        //return
        return result;
    }
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] s = new int[3][];

        for (int i = 0; i < 3; i++)
        {
            s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
        }

        int result = formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
