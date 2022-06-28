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
    static List<long> Coins;
    static long?[,] Map;
    //int, List<long>
    public static long getWays(int n, List<long> c)
    {
        //apply function .Sort()
        c.Sort();
        //set to
        Coins = c;
        //set to create new?[int,List<long>]
        Map = new long?[n, Coins.Count];
        //return apply function Count(int, List<long>-1)
        return Count(n, Coins.Count - 1);
    }
    //long, int
    private static long Count(long target, int maxCointIndex)
    {
        //if condition (==) return
        if (target == 0) return 1;
        //if condition (<) return
        if (target < 0) return 0;
        if (maxCointIndex < 0) return 0;
        //if condition(int[long-1,int].)
        if (Map[target - 1, maxCointIndex].HasValue)
            //return int[long-1,int]
            return Map[target - 1, maxCointIndex].Value;
        //set to apply function Count(long, int-1) + apply function Count(long-List<long>[int],int)
        var sum = Count(target, maxCointIndex - 1) +
            Count(target - Coins[maxCointIndex], maxCointIndex);
        //set to
        Map[target - 1, maxCointIndex] = sum;
        //return
        return sum;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<long> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt64(cTemp)).ToList();

        long ways = Result.getWays(n, c);

        textWriter.WriteLine(ways);

        textWriter.Flush();
        textWriter.Close();
    }
}
