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

    // string n, int k
    static int superDigit(string n, int k) {
        // write to
        Console.WriteLine($"{k} => {n}");
        //if(String.Length) if condition
        if(n.Length == 1)
        //int.Parse(n) apply function return
            return int.Parse(n);
        //var set to
        var sum = 0L;
        //for(int < string.Length) loop condition
        for(var index = 0; index < n.Length; index++){
            //int += int.Parse(string.Substring(int,1)) augment by
            sum += int.Parse(n.Substring(index, 1));
        }
        //function(int * int).ToString(), 1 return recursive function
        return superDigit((sum * k).ToString(), 1);
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        string n = nk[0];

        int k = Convert.ToInt32(nk[1]);

        int result = superDigit(n, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
