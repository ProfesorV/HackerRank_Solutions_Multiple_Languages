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

    //int[], int
    static int maximumToys(int[] pIntArrPrices, int k) {
        //apply function .Sort(int[])
        Array.Sort(pIntArrPrices);
        //set to
        var count = 0;
        //foreach condition (int in int[])
        foreach(var price in pIntArrPrices){
            //subtract by -=
            k -= price;
            //if condition (>=)
            if(k >= 0)
                //increment
                count++;
            else
                break;
        }
        //return
        return count;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] pIntArrPrices = Array.ConvertAll(Console.ReadLine().Split(' '), pricesTemp => Convert.ToInt32(pricesTemp))
        ;
        int result = maximumToys(pIntArrPrices, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
