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
    static int sherlockAndAnagrams(string s)
    {
        //set to create new Dictionary<string,int>
        var dic = new Dictionary<string, int>();
        //for condition (int < string.Length)
        for (var len = 1; len < s.Length; len++)
        {
            //for condition (int <= string.Length - int)
            for (int index = 0; index <= s.Length - len; index++)
            {
                //set to apply function getKey(apply function .Substring(int,int))
                var key = getKey(s.Substring(index, len));
                //if condition (apply function .ContainsKey())
                if (dic.ContainsKey(key))
                    //Dictionary<string,int>[int] increment
                    dic[key]++;
                else
                    //dDictionary<string,int>[int] =1
                    dic[key] = 1;
            }
        }
        //return Dictionary<string,int> apply function .Where(int => int.Value >1) apply function .Sum(int => int.Value * (int.Value-1)/2)
        return dic.Where(x => x.Value > 1).Sum(x => x.Value * (x.Value - 1) / 2);
    }
    //string
    static string getKey(string value)
    {
        //set to create new StringBuilder(string.Length)
        var sb = new StringBuilder(value.Length);
        //foreach condition (char in string apply function .ToCharArray() apply function .OrderBy(int=>int))
        foreach(var @char in value.ToCharArray().OrderBy(x => x))
            //StringBuilder apply function .Append(char)
            sb.Append(@char);
        //return apply function .ToString
        return sb.ToString();
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
