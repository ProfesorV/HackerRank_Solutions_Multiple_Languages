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

    // int[][]
    static int connectedCell(int[][] pMultiDimIntMatrix)
    {
        //set to create new
        var intArrXOff = new[] { -1, 0, 1, -1 };
        //set to create new
        var intArrYOff = new[] { -1, -1, -1, 0 };
        //set to create new
        var disjointSetsClass = new DisjointSets();
        //set to
        var rowArr = pMultiDimIntMatrix.Length;
        //set to
        var colsArr = pMultiDimIntMatrix[0].Length;
        //set to
        var max = 0;
        //create delegate, parameters, pass on =>
        Func<int, int, bool> isValid = (int x, int y) =>
        {
            //return >= && < && >= && <
            return x >= 0 && x < colsArr && y >= 0 && y < rowArr;
        };
        //for <
        for (int y = 0; y < rowArr; y++)
        {
            //for <
            for (int x = 0; x < colsArr; x++)
            {
                //if <
                if(pMultiDimIntMatrix[y][x] == 0) continue;
                //set to create new
                var current = new CellKey(x, y);
                //.
                disjointSetsClass.AddNew(current);
                //set to .
                max = Math.Max(max, 1);
                //for <
                for (int index = 0; index < intArrXOff.Length; index++)
                {
                    //set to +
                    var ox = x + intArrXOff[index];
                    //set to +
                    var oy = y + intArrYOff[index];
                    //if !function
                    if (!isValid(ox, oy)) continue;
                    //if ==
                    if(pMultiDimIntMatrix[oy][ox] == 0) continue;
                    //set to create new
                    var offset = new CellKey(ox, oy);
                    //if .!= .
                    if (disjointSetsClass.Find(current) != disjointSetsClass.Find(offset))
                    //set to .
                        max = Math.Max(max, disjointSetsClass.Union(current, offset));
                }
            }
        }
        //return 
        return max;
    }

    struct CellKey
    {
        public int X;
        public int Y;
        public CellKey(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static bool operator !=(CellKey lhs, CellKey rhs) => !(lhs == rhs);
        public static bool operator ==(CellKey lhs, CellKey rhs) => lhs.X == rhs.X && lhs.Y == rhs.Y;
    }
    class DisjointSets
    {
        //set to create new
        Dictionary<CellKey, CellKey> Parents = new Dictionary<CellKey, CellKey>();
        //set to create new
        Dictionary<CellKey, int> Counts = new Dictionary<CellKey, int>();
        //CellKey
        public void AddNew(CellKey key)
        {
            //.
            Parents.Add(key, key);
            //.
            Counts.Add(key, 1);
        }
        //CellKey
        public CellKey Find(CellKey value) => Parents[value] == value ? value : Find(Parents[value]);
        //CellKey *2
        public int Union(CellKey left, CellKey right)
        {
            //set to
            var pLeft = Find(left);
            //set to
            var pRight = Find(right);
            //set to
            Parents[pRight] = pLeft;
            //set to +
            Counts[pLeft] = Counts[pLeft] + Counts[pRight];
            //return
            return Counts[pLeft];
        }
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        int[][] pMultiDimIntMatrix = new int[n][];

        for (int i = 0; i < n; i++) {
            pMultiDimIntMatrix[i] = Array.ConvertAll(Console.ReadLine().Split(' '), matrixTemp => Convert.ToInt32(matrixTemp));
        }

        int result = connectedCell(pMultiDimIntMatrix);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
