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

    //List<List<int>>
    static List<int> queryFrequencyOf(List<List<int>> pListListIntQueries)
    {
        //set to create new Dictionary<int,int>
        var intIntDicData = new Dictionary<int, int>();
        //set to create new Dictionary<int,int>
        var intIntDicFrequency = new Dictionary<int, int>();
        //set to create new List<int>
        var intListResults = new List<int>();
        //foreach condition
        foreach (var command in pListListIntQueries)
        {
            //if condition ()
            if (command[0] == 1)
            {
                //if condition (apply function .TryGetValue())
                if (intIntDicData.TryGetValue(command[1], out var val))
                {
                    //if condition (apply function .TryGetValue())
                    if (intIntDicFrequency.TryGetValue(val, out var val2))
                        //set to apply function .Max()
                        intIntDicFrequency[val] = Math.Max(0, val2 - 1);
                    //augment by =++
                    intIntDicData[command[1]] = ++val;
                    //if condition (apply function .TryGetValue())
                    if (intIntDicFrequency.TryGetValue(val, out var val3))
                        //set to calculate
                        intIntDicFrequency[val] = val3 + 1;
                    else
                        //set to
                        intIntDicFrequency[val] = 1;
                }
                else
                {
                    //apply function .Add()
                    intIntDicData.Add(command[1], 1);
                    //if condition (apply function .TryGetValue())
                    if (intIntDicFrequency.TryGetValue(1, out var val3))
                        //set to calculates
                        intIntDicFrequency[1] = val3 + 1;
                    else
                        //set to
                        intIntDicFrequency[1] = 1;
                }
            }
            //else if condition (==)
            else if (command[0] == 2)
            {
                //if condition (apply function .TryGetValue())
                if (intIntDicData.TryGetValue(command[1], out var val))
                {
                    //if condition (apply function .TryGetValue())
                    if (intIntDicFrequency.TryGetValue(val, out var val2))
                        //set to apply function .Max()
                        intIntDicFrequency[val] = Math.Max(0, val2 - 1);
                    //set to apply function .Max()
                    intIntDicData[command[1]] = Math.Max(0, --val);
                    //if condition (apply function .TryGetValue())
                    if (intIntDicFrequency.TryGetValue(val, out var val3))
                        //set to calculates
                        intIntDicFrequency[val] = val3 + 1;
                    else
                        //set to
                        intIntDicFrequency[val] = 1;
                }
            }
            else
            {
                //apply function .Add(apply function .TryGetValue() && ?)
                intListResults.Add(intIntDicFrequency.TryGetValue(command[1], out var val) && val > 0 ? 1 : 0);
            }
        }
        //return
        return intListResults;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> pListListIntQueries = new List<List<int>>();

        for (int i = 0; i < q; i++) {
            pListListIntQueries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> ans = queryFrequencyOf(pListListIntQueries);

        textWriter.WriteLine(String.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
