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
    // string[], string[]
    static int[] matchingStrings(string[] strings, string[] queries) {
        //set to create new int[string.Length]
        var result = new int[queries.Length];
        //set to create new Dictionary<string,int>
        var dic = new Dictionary<string, int>();
        //foreach condition (int in int[])
        foreach(var item in strings)
        {
            //if condition (apply function .TryGetValue(int, int))
            if(dic.TryGetValue(item, out var count))
                //Dictionary<string,int> set to int + 1
                dic[item] = count + 1;
            else
                //apply function .Add(int,1)
                dic.Add(item, 1);
        }
        //for condition (int < string.Length)
        for(var index = 0; index < queries.Length; index++)
        {
            //if condition (apply function .TryGetValue(string[int]))
            if(dic.TryGetValue(queries[index], out var count))
                //int[int]=int
                result[index] = count;
            else
                //int[int]=0
                result[index] = 0;
        }
        //return
        return result;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int stringsCount = Convert.ToInt32(Console.ReadLine());

        string[] strings = new string [stringsCount];

        for (int i = 0; i < stringsCount; i++) {
            string stringsItem = Console.ReadLine();
            strings[i] = stringsItem;
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine());

        string[] queries = new string [queriesCount];

        for (int i = 0; i < queriesCount; i++) {
            string queriesItem = Console.ReadLine();
            queries[i] = queriesItem;
        }

        int[] res = matchingStrings(strings, queries);

        textWriter.WriteLine(string.Join("\n", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
