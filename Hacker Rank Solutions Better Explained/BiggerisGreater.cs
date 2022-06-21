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
    // string w
    static string biggerIsGreater(string w) {
        //List<char> create new
        var list = new List<char>();
        //for(int = string.Length-1) loop condition
        for (var i = w.Length - 1; i >= 0; i--)
        {
            //List<char>.Any(x=>x>string[int]) if condition
            if(list.Any(x => x > w[i]))
            {
                //char = List<char>.First(int=>x>string[int]) set to
                var c = list.First(x => x > w[i]);
                //List<char>.Remove(char) apply function
                list.Remove(c);
                //List<char>.Add(string[int]) apply function
                list.Add(w[i]);
                //string = $"{string.Substring(0,int)}{char}" set to
                var result = $"{w.Substring(0, i)}{c}";
                //List<char>.Sort() apply function
                list.Sort();
                //string += string.Concat(List<char>) augment
                result += string.Concat(list);
                //return string
                return result;
            }
            else
                //List<char>.Add(string[int]) apply function
                list.Add(w[i]);
        }
        return "no answer";
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine());

        for (int TItr = 0; TItr < T; TItr++) {
            string w = Console.ReadLine();

            string result = biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
