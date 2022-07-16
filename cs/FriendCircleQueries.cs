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
    static int[] maxCircle(int[][] queries)
    {
        //set to create new DisjointSets()
        var ds = new DisjointSets();
        //set to create new int[]
        var result = new int[queries.Length];
        //set to
        var max = 0;
        //for condition (int, int[][].Length)
        for (int index = 0; index < queries.Length; index++)
        {
            //set to apply function .FindOrAdd(int[int][0])
            var left = ds.FindOrAdd(queries[index][0]);
            var right = ds.FindOrAdd(queries[index][1]);
            //set to apply function .Max()
            max = Math.Max(max, ds.Union(left, right));
            //set to
            result[index] = max;
        }
        //return
        return result;
    }
    class DisjointSets
    {
        //set to create new Dictionary<int,int>
        Dictionary<int, int> Parents = new Dictionary<int, int>();
        Dictionary<int, int> Counts = new Dictionary<int, int>();
        Dictionary<int, int> Level = new Dictionary<int, int>();
        //int
        public void AddNew(int key)
        {
            //apply function .Add(int,ints)
            Parents.Add(key, key);
            Counts.Add(key, 1);
            Level.Add(key, 1);
        }
        //int, arrow function Dictionary<int,int>[int]==int ? int : apply function Find(Dictionary<int,int>[int])
        public int Find(int value) => Parents[value] == value ? value : Find(Parents[value]);
        //int
        public int FindOrAdd(int value)
        {
            //if condition(apply function .ContainsKey())
            if(Parents.ContainsKey(value))
                //return apply function Find()
                return Find(value);
            //apply function AddNew(s)
            AddNew(value);
            //return
            return value;
        }
        //int, int
        public int Union(int left, int right)
        {
            //if condition (int == int) return
            if(left == right) return Counts[left];
            //declare
            int newLevel;
            //if condition (>)
            if (Level[left] > Level[right])
            {
                //set to
                newLevel = Level[left];
            }
            //else if condition (<)
            else if (Level[left] < Level[right])
            {
                //set to
                newLevel = Level[right];
                //set to
                var temp = left;
                left = right;
                right = temp;
            }
            else
            {
                //set to calculate
                newLevel = Level[left] + 1;
            }
            //set to
            Parents[right] = left;
            //set to calculate
            Counts[left] = Counts[left] + Counts[right];
            //set to
            Level[left] = newLevel;
            //return
            return Counts[left];
        }
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        int[][] queries = new int[q][];

        for (int i = 0; i < q; i++) {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        int[] ans = maxCircle(queries);

        textWriter.WriteLine(string.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
