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
using System.Threading.Tasks;

class Solution {
    //declare
    static List<long> s_Array;
    //declare
    static long s_Ratio;


    // List<long>, long.
    static long countTriplets(List<long> arr, long r)
    {
        //set to new Dictionary<long,long>
        var mp2 = new System.Collections.Generic.Dictionary<long, long>();
        //set to new Dictionary<long,long>
        var mp3 = new System.Collections.Generic.Dictionary<long, long>();
        //set to
        long res = 0;
        //foreach condition (long in List<long>)
        foreach (long val in arr)
        {
            //if condition (apply function .ContainsKey(long))
            if (mp3.ContainsKey(val))
            //augment by Dictionary[long]
                res += mp3[val];
            //if condition(apply function .ContainsKey(long))
            if (mp2.ContainsKey(val))
                //if condition (apply function .ContainsKey(long * long))
                if (mp3.ContainsKey(val * r))
                    //augment by 
                    mp3[val * r] += mp2[val];
                else
                    //set to
                    mp3[val * r] = mp2[val];
            //if condition (apply function .ContainsKey(long * long))
            if (mp2.ContainsKey(val * r))
                //increment
                mp2[val * r]++;
            else
                //set to
                mp2[val * r] = 1;
        }
        //return
        return res;
    }
    //int, int
    static long Count(int index, int level)
    {
        //if condition (==)
        if(level == 2)
        {
            //set to
            long result = 0;
            //for condition (int < int)
            for (int i = index + 1; i < s_Array.Count; i++)
                //if condition (==)
                if(s_Array[index] * s_Ratio == s_Array[i] )
                    //increment
                    result++;
            //return
            return result;
        }
        else
        {
            //set to
            long result = 0;
            //for condition (int < int)
            for (int i = index + 1; i < s_Array.Count; i++)
                //if condition (==)
                if (s_Array[index] * s_Ratio == s_Array[i])
                    //augment by apply function Count(int, int+1)
                    result += Count(i, level + 1);
            //return
            return result;
        }
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
