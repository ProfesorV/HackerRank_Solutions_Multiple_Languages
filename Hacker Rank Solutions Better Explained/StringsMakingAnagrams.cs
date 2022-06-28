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
    static int makeAnagram(string a, string b) {
        //set to
        var sum = 0;
        //apply function CreateDictionary()
        var aChars = CreateDictionary(a);
        var bChars = CreateDictionary(b);
        //foreach condition ()
        foreach (var item in aChars)
        {
            //if condition (apply function .TryGetValue)
            if (bChars.TryGetValue(item.Key, out var value))
                //augment by .Abs()
                sum += Math.Abs(item.Value - value);
            else
                //augment by
                sum += item.Value;
        }
        //foreach condition (in)
        foreach (var item in bChars)
            //if condition (! apply function .TryGetValue)
            if (!aChars.TryGetValue(item.Key, out var value))
                //augment by
                sum += item.Value;
        //return
        return sum;
    }
    //string
    static Dictionary<char, int> CreateDictionary(string str)
    {
        //set to create new Dictionary<char,int>
        var dic = new Dictionary<char, int>();
        //for condition (int < string.Length)
        for (var index = 0; index < str.Length; index++)
        {
            //if condition (apply function .TryGetValue(string[int]))
            if (dic.TryGetValue(str[index], out var value))
                //Dictionary<char,int>[string[int]]=int+1
                dic[str[index]] = value + 1;
            else
                //Dictionary<char,int>[string[int]]=1
                dic[str[index]] = 1;
        }
        //return
        return dic;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string a = Console.ReadLine();

        string b = Console.ReadLine();

        int res = makeAnagram(a, b);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
