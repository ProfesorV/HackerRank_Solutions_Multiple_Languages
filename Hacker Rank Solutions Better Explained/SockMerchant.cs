// Sock Merchant
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

    // int, int[]
    static int sockMerchant(int n, int[] ar) {
        //List<int> set to create new
        var temp = new  List<int>();
        //int set to
        var pairs = 0;
        //int i in int[] loop through
        foreach(var i in ar){
            //if(List<int>.Contains(int)) if condition
            if(temp.Contains(i)){
                //List<int>.Remove(int) apply function
                temp.Remove(i);
                //int++ increment
                pairs++;
            }
            else
            {
                //List<int>.Add(int)apply function
                temp.Add(i);
            }
        }
        //int return
        return pairs;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
        int result = sockMerchant(n, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
