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

    // int, string
    static int countingValleys(int n, string pStringSteps) {
        //=
        var valleys = 0;
        //new [] {,}
        var intArrDeltas = new [] {1, -1};
        //= new []{'',''}
        var charArrDirections = new [] {'U', 'D'};
        //=
        var current = 0;
        //=
        var wentIntoValley = false;
        //foreach (in . ToCharArray())
        foreach(var s in pStringSteps.ToCharArray()){
            //if !.Contains() throw new ()
            if(!charArrDirections.Contains(s)) throw new ArgumentException();
            //= .IndexOf(,)
            var effective = Array.IndexOf(charArrDirections, s);
            //=
            var temp = current;
            //+= []
            current += intArrDeltas[effective];
            //if == && <
            if(current == 0 && temp < 0)
                //++
                valleys++;
        }
        //return
        return valleys;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        int result = countingValleys(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
