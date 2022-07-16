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
    //string
    static int sherlockAndAnagrams(string pString)
    {
        //set to create new 
        var stringIntDic = new Dictionary<string, int>();
        //for <
        for (var len = 1; len < pString.Length; len++)
        {
            //for <=
            for (int index = 0; index <= pString.Length - len; index++)
            {
                //set to 
                var key = getKey(pString.Substring(index, len));
                //if .
                if (stringIntDic.ContainsKey(key))
                    //++
                    stringIntDic[key]++;
                else
                    //set to
                    stringIntDic[key] = 1;
            }
        }
        //return . passon . > . passon .
        return stringIntDic.Where(x => x.Value > 1).Sum(x => x.Value * (x.Value - 1) / 2);
    }
    //string
    static string getKey(string pStringValue)
    {
        //set to create new
        var StringB = new StringBuilder(pStringValue.Length);
        //foreach . . passon
        foreach(var @char in pStringValue.ToCharArray().OrderBy(x => x))
            //.
            StringB.Append(@char);
        //return .
        return StringB.ToString();
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
