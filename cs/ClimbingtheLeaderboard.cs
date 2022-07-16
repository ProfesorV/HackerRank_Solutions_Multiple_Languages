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
    static int[] climbingLeaderboard(int[] pIntArrScore, int[] pIntArrAlice)
    {
        //set to .,.
        var distinct = pIntArrScore.Distinct().ToArray();
        //set to create new
        var intArrResult = new int[pIntArrAlice.Length];
        //set to create new
        var ReverseCompClass = new ReverseComparer<int>();
        //for <
        for (int index = 0; index < pIntArrAlice.Length; index++)
        {
            //set to .
            var search = Array.BinarySearch(distinct, pIntArrAlice[index], 
            ReverseCompClass);
            //if >=
            if(search >= 0)
            //set to
                intArrResult[index] = search + 1;
            else
            //set to =-
                intArrResult[index] = -search;
        }
        //return
        return intArrResult;
    }
    class ReverseComparer<T> : IComparer<T>
    {
        //parameters, pass on =>, .
        public int Compare(T x, T y) => Comparer<T>.Default.Compare(y, x);
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int scoresCount = Convert.ToInt32(Console.ReadLine());

        int[] pIntArrScore = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
        ;
        int aliceCount = Convert.ToInt32(Console.ReadLine());

        int[] pIntArrAlice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp))
        ;
        int[] intArrResult = climbingLeaderboard(pIntArrScore, pIntArrAlice);

        textWriter.WriteLine(string.Join("\n", intArrResult));

        textWriter.Flush();
        textWriter.Close();
    }
}
