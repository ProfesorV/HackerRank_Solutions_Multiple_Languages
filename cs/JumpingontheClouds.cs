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
    static int jumpingOnClouds(int[] intArrClouds) {
        // set to
        var current = 0;
        // set to
        var jumps = 0;
        //set to .
        var max = intArrClouds.Length;
        //for <
        for(var i = 0; i< max - 1; i++){
            //if < && == ++         
            if(i + 2 < max && intArrClouds[i + 2] == 0) i++;
            //if == 
            if(intArrClouds[i + 1] == 1) throw new Exception();
            //++
            jumps++;
        }
        //return
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
