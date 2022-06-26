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
    static string morganAndString(string a, string b) {
        //set to create new StringBuilder(string.Length + string.Length)
        var result = new StringBuilder(a.Length + b.Length);
    //set to
    var ia = 0;
    var ib = 0;
    //while condition ( < && <)
    while (ia < a.Length && ib < b.Length)
    {
        //switch condition (apply function .BreakTie())
        switch (BreakTie(a, b, ia, ib))
        {
            case -1:
            case 0:
                //set to
                var aa = a[ia];
                //while condition (< && ==)
                while (ia < a.Length && aa == a[ia])
                {
                    //apply function .Append(int)
                    result.Append(aa);
                    //increment
                    ia++;
                }
                break;
            case 1:
                //set to
                var bb = b[ib];
                //while condition (< && ==)
                while (ib < b.Length && bb == b[ib])
                {
                    //apply function .Append()
                    result.Append(bb);
                    //increment
                    ib++;
                }
                break;
        }
    }
    //apply function .Append(apply function .Substring())
    result.Append(a.Substring(ia));
    result.Append(b.Substring(ib));
    //return
    return result.ToString();
}
//string, string, int, int
static int BreakTie  (string a, string b, int ja, int jb) 
{
    //while condition (< && <)
    while (ja < a.Length && jb < b.Length)
    {
        //if condition (<)
        if (a[ja] < b[jb])
            //return
            return -1;
        //if condition (>)
        if (a[ja] > b[jb])
            //return
            return 1;
        //increment
        ja++;
        //increment
        jb++;
    }
    //return < ? :
    return ja < a.Length ? -1 : 1;
}
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            string result = morganAndString(a, b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
