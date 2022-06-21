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
    static int surfaceArea(int[][] A)
    {
        //int; set to
        var sum = 0;
        //for(int < int[][].Length); loop condition
        for (var row = 0; row < A.Length; row++)
        //for(int < int[0].Length); loop condition
            for (var col = 0; col < A[0].Length; col++)
            //int += Count(int[][], int, int); augment
                sum += Count(A, row, col);
        //return int
        return sum;
    }
    //int[][], int, int
    private static int Count(int[][] a, int row, int col)
    {
        //int = 2; set to
        var sum = 2;
        //int[]; set to
        var rowDelta = new[] { -1, 0, 1, 0 };
        //int[]; set to
        var colDelta = new[] { 0, 1, 0, -1 };
        //for(int < int[].Length); for condition
        for (var index = 0; index < rowDelta.Length; index++)
        {
            //int = int + int[int]; set to
            var r = row + rowDelta[index];
            //int = int + int[int]; set to
            var c = col + colDelta[index];
            //if(IsValid(int[][],int,int)); if condition
            if (IsValid(a, r, c))
            //int += Math.Max() 0,int[int][int] - int[int][int]; augment
                sum += Math.Max(0, a[row][col] - a[r][c]);
            else
            //int+= int[int][int]; augment
                sum += a[row][col];
        }
        //return int
        return sum;
    }
    //int[][], int, int
    private static bool IsValid(int[][] a, int row, int col)
    {
        //return int >= 0 && int >= 0 && int < int[][] && int < int[0][].Length; compare
        return row >= 0 && col >= 0 && row < a.Length && col < a[0].Length;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] HW = Console.ReadLine().Split(' ');

        int H = Convert.ToInt32(HW[0]);

        int W = Convert.ToInt32(HW[1]);

        int[][] A = new int[H][];

        for (int i = 0; i < H; i++)
        {
            A[i] = Array.ConvertAll(Console.ReadLine().Split(' '), ATemp => Convert.ToInt32(ATemp));
        }

        int result = surfaceArea(A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
