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
        //if != && != return new
        if (k != 0 && n % (k * 2) != 0) return new[] { -1 };
        //set to create new
        var intArrResult = new int[n];
        //if ==
        if (k == 0)
        //for
            for (int index = 0; index < n; index++)
            //set to
                intArrResult[index] = index + 1;
        else
        //for
            for (var index = 0; index < n / (k * 2); index++)
            {
                //for
                for (int inner = 0; inner < k; inner++)
                {
                    //set to
                    intArrResult[index * k * 2 + inner] = index * k * 2 + k + inner + 1;
                    //set to
                    intArrResult[index * k * 2 + k + inner] = index * k * 2 + inner + 1;
                }
            }
            //return
        return intArrResult;
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

            int[] intArrResult = absolutePermutation(n, k);

            textWriter.WriteLine(string.Join(" ", intArrResult));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
