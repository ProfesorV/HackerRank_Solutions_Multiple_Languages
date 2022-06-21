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

    // string s
    static string reverseShuffleMerge(string s)
    {
        //int set to        
        int a = 'a';
        //int = ''-int + 1 set to calculate
        var m = 'z' - a + 1;
        //int[] = new int[int] set to create new
        var frequency = new int[m];
        //for(int < int[].Length) loop condition
        for (var index = 0; index < frequency.Length; index++)
        //int[int]=0 set to
            frequency[index] = 0;
        //(char in string.ToCharArray()) loop through
        foreach (var c in s.ToCharArray())
        //int[char - int]++ increment
            frequency[c - a]++;
        //int[] set to create new
        var count = new int[m];
        //int < int[].Length loop condition
        for (var index = 0; index < frequency.Length; index++)
        //int[int] = int[int]/2 set to calculate
            count[index] = frequency[index] / 2;
        //int set to
        var top = -1;
        //int [] = new int[string.Length] set to create new
        var stack = new int[s.Length];
        //for(int = string.Length) loop condition
        for (int n = s.Length; --n >= 0;)
        {
            //int = string[int] - int set to calculate
            int c = s[n] - a;
            //int[int]-- decrement
            frequency[c]--;
            //if(int[int]<1) if condition continue
            if (count[c] < 1) continue;
            //int[int]-- decrement
            count[c]--;
            //int >= 0 && int[int] > int && int[int[int]] > int[int[int]]) while condition comparison
            while (top >= 0 && stack[top] > c &&frequency[stack[top]] > count[stack[top]])
            {
                //int[int[int--]]++ increment
                count[stack[top--]]++;
            }
            //int[++int]=int increment set to
            stack[++top] = c;
        }
        //string.Concat(int[].Take(int + 1).Select(x=>(char)(x+a))) apply functions and return
        return string.Concat(stack.Take(top + 1).Select(x => (char)(x + a)));
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = reverseShuffleMerge(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
