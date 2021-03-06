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
    //< >
    static List<long> listLongArr;
    static long s_Ratio;


    // < >
    static long countTriplets(List<long> pListLongArr, long r)
    {
        //= new . . . .<,>()
        var dictionaryLongLongTwo = new System.Collections.Generic.Dictionary<long, long>();
        var dictionaryLongLongThree = new System.Collections.Generic.Dictionary<long, long>();
        //=
        long res = 0;
        //foreach (in)
        foreach (long val in pListLongArr)
        {
            //if .ContainsKey()
            if (dictionaryLongLongThree.ContainsKey(val))
            // +=[]
                res += dictionaryLongLongThree[val];
            //if .ContainsKey()
            if (dictionaryLongLongTwo.ContainsKey(val))
                //if .ContainsKey(*)
                if (dictionaryLongLongThree.ContainsKey(val * r))
                    //[*] += []
                    dictionaryLongLongThree[val * r] += dictionaryLongLongTwo[val];
                else
                    //[*] = []
                    dictionaryLongLongThree[val * r] = dictionaryLongLongTwo[val];
            //if .ContainsKey(*)
            if (dictionaryLongLongTwo.ContainsKey(val * r))
                //[*]++
                dictionaryLongLongTwo[val * r]++;
            else
                //[*] =
                 dictionaryLongLongTwo[val * r] = 1;
        }
        //return
        return res;
    }
    //int, int
    static long Count(int index, int level)
    {
        //if ==
        if(level == 2)
        {
            //set to
            long result = 0;
            //for <
            for (int i = index + 1; i < listLongArr.Count; i++)
                //if []* == []
                if(listLongArr[index] * s_Ratio == listLongArr[i] )
                    //++
                    result++;
            //return
            return result;
        }
        else
        {
            //set to
            long result = 0;
            //for <
            for (int i = index + 1; i < listLongArr.Count; i++)
                //if [] * == []
                if (listLongArr[index] * s_Ratio == listLongArr[i])
                    //+= Count(,+)
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

        List<long> pListLongArr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(pListLongArr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
