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

    //int[]
    static int jumpingOnClouds(int[] c) {
        //int set to
        var current = 0;
        //int set to
        var jumps = 0;
        //int = int[].Length set to
        var max = c.Length;
        //for(int<int-1) loop condition
        for(var i = 0; i< max - 1; i++){
            //if(int+2<int && int[int + 2] ==0) if condition compare increment         
            if(i + 2 < max && c[i + 2] == 0) i++;
            //if(int[int+1]==1) if condition compare throw new
            if(c[i + 1] == 1) throw new Exception();
            //int++ increment
            jumps++;
        }
        //return int
        return jumps;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = jumpingOnClouds(c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
