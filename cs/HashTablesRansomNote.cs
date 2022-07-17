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
    // string[], string[]
    static void checkMagazine(string[] pStringArrMagazine, string[] pStringArrNotes)
    {
        //set to create new SortedDictionary<string,int>
        var stringIntSortedDic = new SortedDictionary<string, int>();
        //foreach condition (in apply function .GroupBy(=>))
        foreach (var group in pStringArrMagazine.GroupBy(x => x))
            //apply function .Add()
            stringIntSortedDic.Add(group.Key, group.Count());
        //foreach condition (in apply function GroupBy(=>))
        foreach (var word in pStringArrNotes.GroupBy(x => x))
        {
            //if condition (! .TryGetValue()||.Count())
            if(!stringIntSortedDic.TryGetValue(word.Key, out int count) || 
            word.Count() > count)
            {
                //apply function .WriteLine()
                Console.WriteLine("No");
                //return
                return;
            }
        }
        Console.WriteLine("Yes");
    }
    static void Main(string[] args)
    {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] pStringArrMagazine = Console.ReadLine().Split(' ');

        string[] pStringArrNotes = Console.ReadLine().Split(' ');

        checkMagazine(pStringArrMagazine, pStringArrNotes);
    }
}
