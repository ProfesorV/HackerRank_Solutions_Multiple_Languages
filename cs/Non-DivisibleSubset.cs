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

class Result
{
    //int, List<int>
    public static int nonDivisibleSubset(int k, List<int> s)
    {
        //set to create new int[int]
        var remainders = new int[k];
        //set to
        int count = 0;
        //apply function .ForEach(int => int[int % int]++)
        s.ForEach(x => remainders[x % k]++);
        //for condition (int <= (int/2))
        for (var j = 1; j <= (k / 2); j++)
        {
            //if (int == int - int)
            if (j == k - j)
                //increment ++
                count++;
            else
                //augment by apply function .Max(int[int],int[int-int])
                count += Math.Max(remainders[j], remainders[k - j]);
        }
        //if(int[0]>0)
        if (remainders[0] > 0)
            //increment
            count++;
        //return
        return count;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int result = Result.nonDivisibleSubset(k, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
