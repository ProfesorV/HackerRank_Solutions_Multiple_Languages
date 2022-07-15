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
    static void whatFlavors(int[] intArrCost, int money)
    {
        //set to create new
        var intListIntDic = new Dictionary<int, List<int>>();
        //for < 
        for (var index = 0; index < intArrCost.Length; index++)
        {
            //if .
            if (intListIntDic.TryGetValue(intArrCost[index], out var val))
                //.
                val.Add(index + 1);
            else
                //.
                intListIntDic.Add(intArrCost[index], new List<int> { index + 1 });
        }
        //set to
        var first = 0;
        //set to
        var second = 0;
        //foreach
        foreach (var c in intArrCost)
        {
            //set to 
            var needed = money - c;
            //if ==
            if (needed == c)
            {
                //if >
                if (intListIntDic[c].Count > 1)
                {
                    //set to 
                    first = intListIntDic[c][0];
                    //set to
                    second = intListIntDic[c][1];
                    break;
                }
            }
            //else if .
            else if (intListIntDic.TryGetValue(needed, out var list))
            {
                //set to
                first = intListIntDic[c][0];
                //set to
                second = list[0];
                break;
            }
        }
        //set to .
        var min = Math.Min(first, second);
        var max = Math.Max(first, second);
        //WriteLine
        Console.WriteLine($"{min} {max}");
    }
    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int money = Convert.ToInt32(Console.ReadLine().Trim());

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int[] intArrCost = Array.ConvertAll(Console.ReadLine().Trim().Split(' ')
            .Select(x => x.Trim()).ToArray(), costTemp => Convert.ToInt32(costTemp));

            whatFlavors(intArrCost, money);
        }
    }
}
