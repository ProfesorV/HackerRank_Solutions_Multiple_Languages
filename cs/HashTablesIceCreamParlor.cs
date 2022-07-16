// Hash Tables: Ice Cream Parlor
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

class Solution
{

    // int[], int
    static void whatFlavors(int[] cost, int money)
    {
        //set to create new Dictionary<int, List<int>>
        var dic = new Dictionary<int, List<int>>();
        //for condition (int < int[].Length)
        for (var index = 0; index < cost.Length; index++)
        {
            //if condition (apply function .TryGetValue())
            if (dic.TryGetValue(cost[index], out var val))
                //apply function .Add(int + 1)
                val.Add(index + 1);
            else
                //apply function .Add(int[int], create new List<int>{int + 1})
                dic.Add(cost[index], new List<int> { index + 1 });
        }
        //set to
        var first = 0;
        var second = 0;
        //foreach condition ()
        foreach (var c in cost)
        {
            //set to calculate
            var needed = money - c;
            //if condition (==)
            if (needed == c)
            {
                //if condition (>)
                if (dic[c].Count > 1)
                {
                    //set to 
                    first = dic[c][0];
                    second = dic[c][1];
                    break;
                }
            }
            //else if condition (apply function .TryGetValue())
            else if (dic.TryGetValue(needed, out var list))
            {
                //set to
                first = dic[c][0];
                second = list[0];
                break;
            }
        }
        //set to apply function .Min
        var min = Math.Min(first, second);
        //set to apply function .Max
        var max = Math.Max(first, second);
        Console.WriteLine($"{min} {max}");
    }
    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int money = Convert.ToInt32(Console.ReadLine().Trim());

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int[] cost = Array.ConvertAll(Console.ReadLine().Trim().Split(' ')
            .Select(x => x.Trim()).ToArray(), costTemp => Convert.ToInt32(costTemp));

            whatFlavors(cost, money);
        }
    }
}
