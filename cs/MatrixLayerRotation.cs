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
    static void matrixRotation(List<List<int>> pListListIntMatrix, int r)
    {
        //set to apply function .Min()/2
        var ringsCount = 
        Math.Min(pListListIntMatrix.Count, pListListIntMatrix[0].Count) / 2;
        //for condition (int < int)
        for (var index = 0; index < ringsCount; index++)
            //apply function Rotate()
            Rotate(pListListIntMatrix, index, r);
        //set to create new StringBuilder()
        var stringBuilder = new StringBuilder();
        //for condition (int < List<List<int>>.Count)
        for (var row = 0; row < pListListIntMatrix.Count; row++)
        {
            //set to create new StringBuilder
            var stringBuilderColumn = new StringBuilder();
            //for condition
            for (var col = 0; col < pListListIntMatrix[0].Count; col++)
                //apply function .Append()
                stringBuilderColumn.Append(" " + pListListIntMatrix[row][col]);
            //apply function .AppendLind(apply functions .ToString() .Trim())
            stringBuilder.AppendLine(stringBuilderColumn.ToString().Trim());
        }
        Console.Write(stringBuilder.ToString());
    }
    //List<List<int>>, int, int
    private static void Rotate(List<List<int>> pListListIntMatrix, 
    int ringOffset, int rotationCount)
    {
        //set to create new []
        var intArrRowMovement = new[] { 0, 1, 0, -1 };
        var intArrColumnMovement = new[] { 1, 0, -1, 0 };
        //set to
        var effectiveMove = 0;
        //set to calculate
        var rowsCount = pListListIntMatrix.Count - 2 * ringOffset;
        var colsCount = pListListIntMatrix[0].Count - 2 * ringOffset;
        var itemsCount = 2 * (rowsCount + colsCount - 2);
        //set to create new Data[int]
        var dataClassArrayMap = new Data[itemsCount];
        //set to create new int[int]
        var intArrValues = new int[itemsCount];
        //set to create new Data(int, int)
        dataClassArrayMap[0] = new Data(ringOffset, ringOffset);
        //set to List<List<int>>[int][int]
        intArrValues[0] = pListListIntMatrix[ringOffset][ringOffset];
        //for condition (int < int)
        for (var index = 1; index < itemsCount; index++)
        {
            //set to calculate
            var row = dataClassArrayMap[index - 1].Row + 
            intArrRowMovement[effectiveMove];
            var col = dataClassArrayMap[index - 1].Col + 
            intArrColumnMovement[effectiveMove];
            //if condition (apply function IsInvalid())
            if (IsInvalid(row, col, rowsCount, colsCount, ringOffset))
            {
                //increment ++
                effectiveMove++;
                //set to calculate
                row = dataClassArrayMap[index - 1].Row + 
                intArrRowMovement[effectiveMove];
                col = dataClassArrayMap[index - 1].Col + 
                intArrColumnMovement[effectiveMove];
            }
            //set to new Data(int,int)
            dataClassArrayMap[index] = new Data(row, col);
            //set to
            intArrValues[index] = pListListIntMatrix[row][col];
        }
        //for condition (int < int)
        for (var index = 0; index < itemsCount; index++)
        {
            //set to calculate
            var effective = (itemsCount - (rotationCount % itemsCount) + index) % itemsCount;
            //set to
            var data = dataClassArrayMap[effective];
            //set to
            pListListIntMatrix[data.Row][data.Col] = intArrValues[index];
        }
    }
    //int, int, int, int, int
    private static bool IsInvalid(int newRow, int newCol, 
    int rowsCount, int colsCount, int ringOffset)
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

        List<List<int>> pListListIntMatrix = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            pListListIntMatrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        matrixRotation(pListListIntMatrix, r);
    }
}
