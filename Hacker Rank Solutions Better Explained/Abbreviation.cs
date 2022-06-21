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

    //string, string
    static string abbreviation(string a, string b) {
        //int = '' - ''; subtract
        var diff = 'a' - 'A';
        //int = string.Length; set to
        var m = a.Length;
        //int = string.Length; set to
        var n = b.Length;
        //bool = bool[int +1,int + 1]; create and set to
        var dp = new bool[n + 1, m + 1];
        //bool[0,0] = true; set to
        dp[0, 0] = true;
        //for(int < int + 2); loop condition
        for (int i = 0; i < n + 1; i++)
        {
            //for(int < int + 1); loop condition
            for (int j = 0; j < m + 1; j++)
            {
                //if(int == 0 && int != 0); if condition
                if (i == 0 && j != 0)
                //bool[int,int] = string[int-1]>'Z' && bool[int, int-1]; set to comparison
                    dp[i, j] = a[j - 1] > 'Z' && dp[i, j - 1];
                    //else if(int != 0 && int != 0); if condition
                else if (i != 0 && j != 0)
                    //if(string[int-1] == string[int-1]); if condition
                    if (a[j - 1] == b[i - 1])
                    //bool[int,int]=bool[int-1,int-1]; set to
                        dp[i, j] = dp[i - 1, j - 1];
                        //else if(string[int-1]-int==string[int-1]); if condition
                    else if (a[j - 1] - diff == b[i - 1])
                    //bool[int,int] = bool[int-1,int-1] || bool[int, int-1]; set to comparison
                        dp[i, j] = dp[i - 1, j - 1] || dp[i, j - 1];
                        //else if(!(string[int-1]<'a' && string[int-1]<'a')); if condition
                    else if (!(a[j - 1] < 'a' && b[i - 1] < 'a'))
                    //bool[int,int] = bool[int,int-1]; set to
                        dp[i, j] = dp[i, j - 1];
            }
        }
        //return bool[int,int] ? "" : ""
        return dp[n, m] ? "YES" : "NO";
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            string result = abbreviation(a, b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
