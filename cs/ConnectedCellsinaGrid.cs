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
        //new[] {}
        var intArrXOff = new[] { -1, 0, 1, -1 };
        //new[] {}
        var intArrYOff = new[] { -1, -1, -1, 0 };
        //new DisjointSets()
        var disjointSetsClass = new DisjointSets();
        //= .Length
        var rowArr = pMultiDimIntMatrix.Length;
        //= [].Length
        var colsArr = pMultiDimIntMatrix[0].Length;
        //=
        var max = 0;
        //<,,,> = () =>
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
                //if [][] == 
                if(pMultiDimIntMatrix[y][x] == 0) continue;
                //= new CellKey(,)
                var current = new CellKey(x, y);
                //.AddNew()
                disjointSetsClass.AddNew(current);
                //.Max(,)
                max = Math.Max(max, 1);
                //for < .Length
                for (int index = 0; index < intArrXOff.Length; index++)
                {
                    //= + []
                    var ox = x + intArrXOff[index];
                    //= + []
                    var oy = y + intArrYOff[index];
                    //if !isValid()
                    if (!isValid(ox, oy)) continue;
                    //if [][] ==
                    if(pMultiDimIntMatrix[oy][ox] == 0) continue;
                    //= new CellKey()
                    var offset = new CellKey(ox, oy);
                    //if .Find() != .Find()
                    if (disjointSetsClass.Find(current) != disjointSetsClass.Find(offset))
                    //.Max(,.Union(,))
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
        //operator !=(,) => !(==)
        public static bool operator !=(CellKey lhs, CellKey rhs) => !(lhs == rhs);
        //operator ==(,) => .X == .X && .Y && .Y
        public static bool operator ==(CellKey lhs, CellKey rhs) => lhs.X == rhs.X && lhs.Y == rhs.Y;
    }
    class DisjointSets
    {
        //<,> = new <,>
        Dictionary<CellKey, CellKey> Parents = new Dictionary<CellKey, CellKey>();
        //<,> = new <,>
        Dictionary<CellKey, int> Counts = new Dictionary<CellKey, int>();
        //AddNew()
        public void AddNew(CellKey key)
        {
            //.Add()
            Parents.Add(key, key);
            //.Add()
            Counts.Add(key, 1);
        }
        //() => []== ? : Find([])
        public CellKey Find(CellKey value) => Parents[value] == value ? value : Find(Parents[value]);
        //(,)
        public int Union(CellKey left, CellKey right)
        {
            //= Find()
            var pLeft = Find(left);
            //= Find()
            var pRight = Find(right);
            //[] = 
            Parents[pRight] = pLeft;
            //[] = [] + []
            Counts[pLeft] = Counts[pLeft] + Counts[pRight];
            //return []
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
