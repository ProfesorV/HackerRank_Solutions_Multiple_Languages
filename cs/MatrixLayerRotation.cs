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

    //List<List<int>>, int
    static void matrixRotation(List<List<int>> matrix, int r)
    {
        //set to apply function .Min()/2
        var ringsCount = Math.Min(matrix.Count, matrix[0].Count) / 2;
        //for condition (int < int)
        for (var index = 0; index < ringsCount; index++)
            //apply function Rotate()
            Rotate(matrix, index, r);
        //set to create new StringBuilder()
        var sbRow = new StringBuilder();
        //for condition (int < List<List<int>>.Count)
        for (var row = 0; row < matrix.Count; row++)
        {
            //set to create new StringBuilder
            var sbCol = new StringBuilder();
            //for condition
            for (var col = 0; col < matrix[0].Count; col++)
                //apply function .Append()
                sbCol.Append(" " + matrix[row][col]);
            //apply function .AppendLind(apply functions .ToString() .Trim())
            sbRow.AppendLine(sbCol.ToString().Trim());
        }
        Console.Write(sbRow.ToString());
    }
    //List<List<int>>, int, int
    private static void Rotate(List<List<int>> matrix, int ringOffset, int rotationCount)
    {
        //set to create new []
        var rowMoves = new[] { 0, 1, 0, -1 };
        var colMoves = new[] { 1, 0, -1, 0 };
        //set to
        var effectiveMove = 0;
        //set to calculate
        var rowsCount = matrix.Count - 2 * ringOffset;
        var colsCount = matrix[0].Count - 2 * ringOffset;
        var itemsCount = 2 * (rowsCount + colsCount - 2);
        //set to create new Data[int]
        var map = new Data[itemsCount];
        //set to create new int[int]
        var values = new int[itemsCount];
        //set to create new Data(int, int)
        map[0] = new Data(ringOffset, ringOffset);
        //set to List<List<int>>[int][int]
        values[0] = matrix[ringOffset][ringOffset];
        //for condition (int < int)
        for (var index = 1; index < itemsCount; index++)
        {
            //set to calculate
            var row = map[index - 1].Row + rowMoves[effectiveMove];
            var col = map[index - 1].Col + colMoves[effectiveMove];
            //if condition (apply function IsInvalid())
            if (IsInvalid(row, col, rowsCount, colsCount, ringOffset))
            {
                //increment ++
                effectiveMove++;
                //set to calculate
                row = map[index - 1].Row + rowMoves[effectiveMove];
                col = map[index - 1].Col + colMoves[effectiveMove];
            }
            //set to new Data(int,int)
            map[index] = new Data(row, col);
            //set to
            values[index] = matrix[row][col];
        }
        //for condition (int < int)
        for (var index = 0; index < itemsCount; index++)
        {
            //set to calculate
            var effective = (itemsCount - (rotationCount % itemsCount) + index) % itemsCount;
            //set to
            var data = map[effective];
            //set to
            matrix[data.Row][data.Col] = values[index];
        }
    }
    //int, int, int, int, int
    private static bool IsInvalid(int newRow, int newCol, int rowsCount, int colsCount, int ringOffset)
    {
        //return comparison <  || < || >= || >=
        return newRow < ringOffset ||
            newCol < ringOffset ||
            newRow - ringOffset >= rowsCount ||
            newCol - ringOffset >= colsCount;
    }
    class Data
    {
        //declare
        public int Row { get; set; }
        public int Col { get; set; }
        public Data(int row, int col)
        {
            //set to
            Row = row;
            Col = col;
        }
    }
    static void Main(string[] args)
    {
        string[] mnr = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(mnr[0]);

        int n = Convert.ToInt32(mnr[1]);

        int r = Convert.ToInt32(mnr[2]);

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        matrixRotation(matrix, r);
    }
}
