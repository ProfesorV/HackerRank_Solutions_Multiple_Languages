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
    static int maxRegion(int[][] matrix)
    {
        //set to create new
        var xOffset = new[] { -1, 0, 1, -1 };
        //set to create new
        var yOffset = new[] { -1, -1, -1, 0 };
        //set to create new
        var ds = new DisjointSets();
        //set to
        var rows = matrix.Length;
        //set to
        var cols = matrix[0].Length;
        //set to
        var max = 0;
        //declare delegate
        Func<int, int, bool> isValid = (int x, int y) =>
        {
            //return comparison && && &&
            return x >= 0 && x < cols && y >= 0 && y < rows;
        };
        //for condition
        for (int y = 0; y < rows; y++)
        {
            //for condition
            for (int x = 0; x < cols; x++)
            {
                //if condition
                if(matrix[y][x] == 0) continue;
                //set to create new
                var current = new CellKey(x, y);
                //apply function
                ds.AddNew(current);
                //set to apply function
                max = Math.Max(max, 1);
                //for condition
                for (int index = 0; index < xOffset.Length; index++)
                {
                    //set to calculate
                    var ox = x + xOffset[index];
                    //set to calculate
                    var oy = y + yOffset[index];
                    //if condition ! function
                    if (!isValid(ox, oy)) continue;
                    //if condition compare
                    if(matrix[oy][ox] == 0) continue;
                    //set to create new
                    var offset = new CellKey(ox, oy);
                    //if condition not equal
                    if (ds.Find(current) != ds.Find(offset))
                        //set to apply function
                        max = Math.Max(max, ds.Union(current, offset));
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
        public override bool Equals(object obj) => this == (CellKey) obj;
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => $"{Y} - {X}";
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
            //apply function
            Parents.Add(key, key);
            //apply function
            Counts.Add(key, 1);
        }
        //CellKey
        public CellKey Find(CellKey value) => Parents[value] == value ? value : Find(Parents[value]);
        //CellKey, CellKey
        public int Union(CellKey left, CellKey right)
        {
            //set to apply function
            var pLeft = Find(left);
            //set to apply function
            var pRight = Find(right);
            //set to
            Parents[pRight] = pLeft;
            //set to
            Counts[pLeft] = Counts[pLeft] + Counts[pRight];
            //return
            return Counts[pLeft];
        }
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        int[][] grid = new int[n][];

        for (int i = 0; i < n; i++) {
            grid[i] = Array.ConvertAll(Console.ReadLine().Split(' '), gridTemp => Convert.ToInt32(gridTemp));
        }

        int res = maxRegion(grid);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
