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

    // int, int
    static int[] absolutePermutation(int n, int k)
    {
        //if(int != 0 && int % (int * 2) != 0); if condition crete new
        if (k != 0 && n % (k * 2) != 0) return new[] { -1 };
        //return int[]; create new set to
        var result = new int[n];
        //if(int==0); if condition
        if (k == 0)
        //for(int < int); loop condition
            for (int index = 0; index < n; index++)
            //int[int] = int + 1; set to
                result[index] = index + 1;
        else
        //for(int < n/(int * 2)); loop condition
            for (var index = 0; index < n / (k * 2); index++)
            {
                //for (int < int); loop condition
                for (int inner = 0; inner < k; inner++)
                {
                    //int[int * int * 2 + int] = int * int * 2 + int + int + 1; set to
                    result[index * k * 2 + inner] = index * k * 2 + k + inner + 1;
                    //int[int * int * 2 + int + int] = int * int * 2 + int + 1; set to
                    result[index * k * 2 + k + inner] = index * k * 2 + inner + 1;
                }
            }
            //return int[]
        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] result = absolutePermutation(n, k);

            textWriter.WriteLine(string.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
