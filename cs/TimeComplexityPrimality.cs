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

    // int
    static string primality(int n) {
        //if condition (int == 1) return
        if(n == 1) return "Not prime";
        //if condition (int < 4) return
        if(n < 4) return "Prime";
        //for condition (int <= Math.Sqrt(int))
        for(var index = 2; index <= Math.Sqrt(n); index++)
            //if condition (int % int ==0)
            if(n % index == 0)
                //return
                return "Not prime";
        //return
        return "Prime";
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        var temp = Console.ReadLine();

        int p = Convert.ToInt32(temp);

        for (int pItr = 0; pItr < p; pItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            string result = primality(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
