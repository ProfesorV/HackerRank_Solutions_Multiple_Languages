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

    // int[]
    static void countSwaps(int[] a) {
        //int[].Length if condition
        if(a.Length == 0)
            throw new ArgumentException();
            //int set to
        var counter = 0;
        //for(int < int[].Length) loop condition
        for (int i = 0; i < a.Length; i++) {
            //for(int < int[].Length - 1 - int) loop condition
            for (int j = 0; j < a.Length - 1 - i; j++) {
                //if(int[int] > int[int+1]) if condition
                if (a[j] > a[j + 1]) {
                    //int = int[int + 1] set to calculate
                    var temp = a[j + 1];
                    //int[int + 1] = int[int] set to
                    a[j + 1] = a[j];
                    //int[int] = int set to
                    a[j] = temp;
                    //int++ increment                    
                    counter++;
                }
            }   
        }
        //
        Console.WriteLine($"Array is sorted in {counter} swaps.");
        Console.WriteLine($"First Element: {a[0]}");
        Console.WriteLine($"Last Element: {a[a.Length - 1]}");
    }

    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
        countSwaps(a);
    }
}
