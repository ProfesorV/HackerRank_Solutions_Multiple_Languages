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
    static int sockMerchant(int pIntn, int[] pIntArr) {
        //set to create new
        var listInt = new  List<int>();
        //set to
        var pairs = 0;
        //foreach in
        foreach(var i in pIntArr){
            //if .
            if(listInt.Contains(i)){
                //.
                listInt.Remove(i);
                //++
                pairs++;
            }
            else
            {
                //.
                listInt.Add(i);
            }
        }
        //return
        return pairs;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] pIntArr = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
        int result = sockMerchant(n, pIntArr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
