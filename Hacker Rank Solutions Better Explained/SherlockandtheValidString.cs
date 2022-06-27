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
    static string isValid(string s)
    {
        //set to apply function CreateDictionary()
        var dic = CreateDictionary(s);
        //set to create new Dictionary<int,int>
        var countDic = new Dictionary<int, int>();
        //foreach condition (in CreateDictionary(s))
        foreach (var item in dic)
        {
            //if condition (apply function .TryGetValue())
            if (countDic.TryGetValue(item.Value, out var value))
                //set to Dictionary<int,int>[.value] = value + 1
                countDic[item.Value] = value + 1;
            else
                //set to
                countDic[item.Value] = 1;
        }
        //switch condition (Dictionary<int,int>)
        switch (countDic.Count)
        {
            //return
            case 1: return "YES";
            case 2:
                //set to apply function .First()
                var first = countDic.First();
                //set to apply function .Last()
                var last = countDic.Last();
                //if condition (== && ==)
                if (first.Value == 1 && first.Key == 1)
                    return "YES";
                //if conditon (== && ==)
                if (last.Value == 1 && last.Key == 1)
                    return "YES";
                //if condition (> && >)
                if (last.Value > 1 && first.Value > 1)
                    return "NO";
                //if condition (apply function .Abs()>1)
                if (Math.Abs(last.Key - first.Key) > 1)
                    return "NO";
                else
                    return "YES";
            default: return "NO";
        }
    }
    //string
    static Dictionary<char, int> CreateDictionary(string str)
    {
        //set to create new Dictionary<char,int>
        var dic = new Dictionary<char, int>();
        //for condition (int < string.Length)
        for (var index = 0; index < str.Length; index++)
        {
            //if condition (apply function .TryGetValue(string[int],int))
            if (dic.TryGetValue(str[index], out var value))
                //set to calculate
                dic[str[index]] = value + 1;
            else
                //set to
                dic[str[index]] = 1;
        }
        //return
        return dic;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = isValid(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
