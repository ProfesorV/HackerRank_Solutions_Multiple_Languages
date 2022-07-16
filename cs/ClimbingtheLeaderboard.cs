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

    //int[], int[]
    static int[] climbingLeaderboard(int[] scores, int[] alice)
    {
        //set to .,.
        var distict = scores.Distinct().ToArray();
        //set to create new
        var result = new int[alice.Length];
        //set to create new
        var comparer = new ReverseComparer<int>();
        //for <
        for (int index = 0; index < alice.Length; index++)
        {
            //set to .
            var search = Array.BinarySearch(distict, alice[index], comparer);
            //if >=
            if(search >= 0)
            //set to
                result[index] = search + 1;
            else
            //set to =-
                result[index] = -search;
        }
        //return
        return result;
    }
    class ReverseComparer<T> : IComparer<T>
    {
        //parameters, pass on =>, .
        public int Compare(T x, T y) => Comparer<T>.Default.Compare(y, x);
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int scoresCount = Convert.ToInt32(Console.ReadLine());

        int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
        ;
        int aliceCount = Convert.ToInt32(Console.ReadLine());

        int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp))
        ;
        int[] result = climbingLeaderboard(scores, alice);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
