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
        //set to create new
        var charList = new List<char>();
        //for
        for (var i = w.Length - 1; i >= 0; i--)
        {
            //if, pass on to >
            if(charList.Any(x => x > w[i]))
            {
                //set to, ., pass on to >
                var c = charList.First(x => x > w[i]);
                //.
                charList.Remove(c);
                //.
                charList.Add(w[i]);
                //set to .
                var result = $"{w.Substring(0, i)}{c}";
                //.
                charList.Sort();
                //+=, .
                result += string.Concat(charList);
                //return
                return result;
            }
            else
                //.
                charList.Add(w[i]);
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
