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
    static int countingValleys(int n, string steps) {
        //set to
        var valleys = 0;
        //set to create new 
        var deltas = new [] {1, -1};
        //set to create new
        var directions = new [] {'U', 'D'};
        //set to
        var current = 0;
        //set to
        var wentIntoValley = false;
        //foreach condition (char in string.ToCharArray())
        foreach(var s in steps.ToCharArray()){
            //if condition (![].Contains(char))
            if(!directions.Contains(s)) throw new ArgumentException();
            //set to apply function .IndexOf([], string)
            var effective = Array.IndexOf(directions, s);
            //set to
            var temp = current;
            //augment by [int]
            current += deltas[effective];
            //if condition (== && <)
            if(current == 0 && temp < 0)
                //increment
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
