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

    // string, string
    static string twoStrings(string s1, string s2) {
        //char[] = string. ToCharArray().Distinct().OrderBy(char => char).ToArray() apply functions
        var chars1 = s1.ToCharArray().Distinct().OrderBy(x => x).ToArray();
        //foreach(char in string.ToCharArray) loop through
        foreach (var ch in s2.ToCharArray())
        {
            //if(Array.BinarySearch(char[], char) >=0) if condition
            if (Array.BinarySearch(chars1, ch) >= 0)
            //return String
                return "YES";
        }
        //String return
        return "NO";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string result = twoStrings(s1, s2);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
