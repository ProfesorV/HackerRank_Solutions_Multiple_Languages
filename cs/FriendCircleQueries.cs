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
    static int[] maxCircle(int[][] pIntMultiDimArrQueries)
    {
        //set to create new DisjointSets()
        var disjointSetsClass = new DisjointSets();
        //set to create new int[]
        var intArrResults = new int[pIntMultiDimArrQueries.Length];
        //set to
        var max = 0;
        //for condition (int, int[][].Length)
        for (int index = 0; index < pIntMultiDimArrQueries.Length; index++)
        {
            //set to apply function .FindOrAddValue(int[int][0])
            var left = disjointSetsClass.FindOrAddValue(pIntMultiDimArrQueries[index][0]);
            var right = disjointSetsClass.FindOrAddValue(pIntMultiDimArrQueries[index][1]);
            //set to apply function .Max()
            max = Math.Max(max, disjointSetsClass.SetUnion(left, right));
            //set to
            intArrResults[index] = max;
        }
        //return
        return intArrResults;
    }
    class DisjointSets
    {
        //set to create new Dictionary<int,int>
        Dictionary<int, int> intIntDicParents = new Dictionary<int, int>();
        Dictionary<int, int> intIntDicCount = new Dictionary<int, int>();
        Dictionary<int, int> intIntDicLevels = new Dictionary<int, int>();
        //int
        public void AddNewKey(int key)
        {
            //apply function .Add(int,ints)
            intIntDicParents.Add(key, key);
            intIntDicCount.Add(key, 1);
            intIntDicLevels.Add(key, 1);
        }
        //int, arrow function Dictionary<int,int>[int]==int ? int : apply function FindValue(Dictionary<int,int>[int])
        public int FindValue(int value) => 
        intIntDicParents[value] == value ? value : FindValue(intIntDicParents[value]);
        //int
        public int FindOrAddValue(int value)
        {
            //if condition(apply function .ContainsKey())
            if(intIntDicParents.ContainsKey(value))
                //return apply function FindValue()
                return FindValue(value);
            //apply function AddNewKey(s)
            AddNewKey(value);
            //return
            return value;
        }
        //int, int
        public int SetUnion(int left, int right)
        {
            //if condition (int == int) return
            if(left == right) return intIntDicCount[left];
            //declare
            int newLevel;
            //if condition (>)
            if (intIntDicLevels[left] > intIntDicLevels[right])
            {
                //set to
                newLevel = intIntDicLevels[left];
            }
            //else if condition (<)
            else if (intIntDicLevels[left] < intIntDicLevels[right])
            {
                //set to
                newLevel = intIntDicLevels[right];
                //set to
                var temp = left;
                left = right;
                right = temp;
            }
            else
            {
                //set to calculate
                newLevel = intIntDicLevels[left] + 1;
            }
            //set to
            intIntDicParents[right] = left;
            //set to calculate
            intIntDicCount[left] = intIntDicCount[left] + intIntDicCount[right];
            //set to
            intIntDicLevels[left] = newLevel;
            //return
            return intIntDicCount[left];
        }
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        int[][] pIntMultiDimArrQueries = new int[q][];

        for (int i = 0; i < q; i++) {
            pIntMultiDimArrQueries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        int[] ans = maxCircle(pIntMultiDimArrQueries);

        textWriter.WriteLine(string.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
