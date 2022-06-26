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
        //int[]
        static void minimumBribes(int[] q)
        {
            //set to
            int ans = 0;
            //for condition (int = int[].Length -1)
            for (var i = q.Length - 1; i >= 0; i--) {
                //if condition (int[int]-(int+1)>2)
                if (q[i] - (i + 1) > 2) {
                    Console.WriteLine("Too chaotic");
                    return;
        }
        //for condition (int < int)
        for (int j = Math.Max(0, q[i] - 2); j < i; j++)
        //if condition (int[int] > int[int]) increment++
        if (q[j] > q[i]) ans++;
        }
            Console.WriteLine(ans);
        }
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
                ;
                minimumBribes(q);
            }
        }
    }
