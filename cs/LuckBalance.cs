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

    // int, int[][]
    static int luckBalance(int k, int[][] pIntMultiDimArrContest) {
        //int set to
        var grandTotal = 0;
        //List<int> create new
        var intListImportant = new List<int>();
        //(int[] in int[][]) loop through condition
        foreach (var contest in pIntMultiDimArrContest)
        {
            //int += int[0] augment by
            grandTotal += contest[0];
            //if(int[1]==1) if condition
            if (contest[1] == 1)
            //List<int>.Add(int[0]) apply function
                intListImportant.Add(contest[0]);
        }
        //List<int>.Sort() appky function
        intListImportant.Sort(); 
        //int = List<int> set to
        var impotantScores = intListImportant
        //List<int>.Take() Math.Math (0,List<int>.Count-int)).Sum() apply function apply function
            .Take(Math.Max(0, intListImportant.Count - k))
            .Sum();
            //return int-int*2
        return grandTotal - impotantScores * 2;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[][] pIntMultiDimArrContest = new int[n][];

        for (int i = 0; i < n; i++) {
            pIntMultiDimArrContest[i] = Array.ConvertAll(Console.ReadLine().Split(' '), contestsTemp => Convert.ToInt32(contestsTemp));
        }

        int result = luckBalance(k, pIntMultiDimArrContest);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
