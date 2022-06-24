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

class Solution
{

    //int, int
    static string timeInWords(int h, int m)
    {
        //set to create new []
        var numbers = new[] {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen",
            "twenty",
            "twenty one",
            "twenty two",
            "twenty three",
            "twenty four",
            "twenty five",
            "twenty six",
            "twenty seven",
            "twenty eight",
            "twenty nine"
        };
        //if condition (int = 0) return
        if (m == 0) return $"{numbers[h]} o' clock";
        //if condition(int = 0) return
        if (m == 30) return $"half past {numbers[h]}";
        //set to int > ?
        var effectiveMinutes = m > 30 ? 60 - m : m;
        //set to int[int]
        var minutes = numbers[effectiveMinutes];
        //if condition(int ==)
        if (effectiveMinutes == 15)
            //set to
            minutes = "quarter";
        //else if condition (int >)
        else if (effectiveMinutes > 1)
            //augment by
            minutes += " minutes";
        else
            //augment by
            minutes += " minute";
        //set to int >
        var linker = m > 30 ? "to" : "past";
        //if (int > 30) int set to int + 1
        if (m > 30) h = (h + 1) % 24;
        //return
        return $"{minutes} {linker} {numbers[h]}";
    }
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        string result = timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
