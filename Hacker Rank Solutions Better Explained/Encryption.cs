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
    static string encryption(string s) {
        //string = string.Replace() set to
        s = s.Replace(" ", "");
        //int set to
        var rows = (int)Math.Floor(Math.Sqrt(s.Length));
        //int set to
        var cols = (int)Math.Ceiling(Math.Sqrt(s.Length));
        //if(int * int < string.Length) if condition
        if(rows * cols < s.Length)
        //int increment
            rows++;
            //string set to
        var result = "";
        //for(int < int) loop condition
        for (int c = 0; c < cols; c++)
        {
            //for(int < int) loop condition
            for (int r = 0; r < rows; r++)
            {
                //int = int*int+int set to
                var index = r * cols + c;
                //string += int < string.Length ? string. Substring() int, 1 : "" augment conditional
                result += index < s.Length ? s.Substring(index, 1) : "";
            }
            //string augment
            result += " ";
        }
        //string
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
