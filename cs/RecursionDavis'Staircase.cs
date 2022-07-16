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
    static int stepPerms(int n) {
        //set to create new Dictionary<int,int>
        var map = new Dictionary<int, int>();
        //apply function .Add(1,1)
        map.Add(1, 1);
        map.Add(2, 2);
        map.Add(3, 4);
        //return function count(int, Dictionary<int,int>)
        return count(n, map);
    }
    //int, Dictionary<int,int>
    static int count(int n, Dictionary<int, int> map){
        //if condition (apply function .ContainsKey()) return Dictionary<int,int>[int]
        if(map.ContainsKey(n)) return map[n];
        //set to
        int res = 0;
        //augment by apply function count(int-1,Dictionary<int,int>)
        res += count(n - 1, map);
        res += count(n - 2, map);
        res += count(n - 3, map);
        //apply function .Add(int, int)
        map.Add(n, res);
        //return int
        return res;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int s = Convert.ToInt32(Console.ReadLine());

        for (int sItr = 0; sItr < s; sItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int res = stepPerms(n);

            textWriter.WriteLine(res);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
