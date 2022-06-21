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
    // string, long
    static long repeatedString(string s, long n) {
        //var = long/string.Length set to calculate
        var fullRepeatCount = n / s.Length;
        //var = GerRepeatCount(string) set to
        var countOriginalText = GetRepeatCount(s);
        //int = Convert.ToInt32(long - var * string.Length) set to calculate
        int temp = Convert.ToInt32(n - fullRepeatCount * s.Length);
        //var = GetRepeatCount(string.Substring(0,int)) set to calculate
        var countInPartial = GetRepeatCount(s.Substring(0, temp));
        //return var * var + var return calculation
        return countOriginalText * fullRepeatCount + countInPartial;
    }
    //string
    static int GetRepeatCount(string s) => s.ToCharArray().Count(x => x == 'a');

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine());

        long result = repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
