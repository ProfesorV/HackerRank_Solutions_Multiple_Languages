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
    static string abbreviation(string pStringa, string pStringb) {
        //set to
        var diff = 'a' - 'A';
        //set to
        var m = pStringa.Length;
        //set to
        var n = pStringb.Length;
        //set to create new
        var multiDimBoolArr = new bool[n + 1, m + 1];
        //set to
        multiDimBoolArr[0, 0] = true;
        //for
        for (int i = 0; i < n + 1; i++)
        {
            //for
            for (int j = 0; j < m + 1; j++)
            {
                //if == && !=
                if (i == 0 && j != 0)
                //set to > &&
                    multiDimBoolArr[i, j] = a[j - 1] > 'Z' 
                    && multiDimBoolArr[i, j - 1];
                    //else if != && !=
                else if (i != 0 && j != 0)
                    //if ==
                    if (a[j - 1] == b[i - 1])
                    //set to
                        multiDimBoolArr[i, j] = multiDimBoolArr[i - 1, j - 1];
                        //else if
                    else if (a[j - 1] - diff == b[i - 1])
                    //set to ||
                        multiDimBoolArr[i, j] = multiDimBoolArr[i - 1, j - 1] || multiDimBoolArr[i, j - 1];
                        //else if ! < && <
                    else if (!(a[j - 1] < 'a' && b[i - 1] < 'a'))
                    //set to
                        multiDimBoolArr[i, j] = multiDimBoolArr[i, j - 1];
            }
        }
        //return ? "" : ""
        return multiDimBoolArr[n, m] ? "YES" : "NO";
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
