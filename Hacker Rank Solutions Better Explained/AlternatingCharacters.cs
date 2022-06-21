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

    // string
    static int alternatingCharacters(string s) {
        //char; set to
        var @char = 'z';
        //int set to
        var counter = 0;
        //for(int < string.Length) loop condition
        for (var index = 0; index < s.Length; index++)
        {
            //if(string[int]==char) if condition equals
            if (s[index] == @char) 
            //int++ increment
                counter++;
                //char = string[int] set to
            @char = s[index];
        }
        //return int
        return counter;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s = Console.ReadLine();

            int result = alternatingCharacters(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
