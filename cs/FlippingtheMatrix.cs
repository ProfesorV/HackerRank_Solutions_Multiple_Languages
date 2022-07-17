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

    //int[][]
    static int MatrixFlip(int[][] pMultiDimMatrix)
    {
        //set to
        var sum = 0;
        //set to calculate
        var n = pMultiDimMatrix.Length / 2;
        //for condition
        for (var row = 0; row < n; row++)
        {
            //for condition
            for (var col = 0; col < n; col++)
            {
                //agument by apply function
                sum += maxForMatrix(pMultiDimMatrix, row, col);
            }
        }
        //return
        return sum;
    }
    //int[][], int, int
    static int maxForMatrix(int[][] pMultiDimMatrix, int row, int col)
    {
        //set to calculate
        var n2 = pMultiDimMatrix.Length - 1;
        //return apply function in apply function and apply function
        return Math.Max(
            Math.Max(
                pMultiDimMatrix[row][col],
                pMultiDimMatrix[n2 - row][col]),
            Math.Max(
                pMultiDimMatrix[row][n2 - col],
                pMultiDimMatrix[n2 - row][n2 - col])
        );
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] pMultiDimMatrix = new int[2 * n][];

            for (int i = 0; i < 2 * n; i++)
            {
                pMultiDimMatrix[i] = Array.ConvertAll(Console.ReadLine().Split(' '), matrixTemp => Convert.ToInt32(matrixTemp));
            }

            int result = MatrixFlip(pMultiDimMatrix);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
