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

    // int[], int[], int[]
    static long triplets(int[] a, int[] b, int[] c)
    {
        //int[] = int[].Distinct().ToArray(), set to apply functions
        a = a.Distinct().ToArray();
        b = b.Distinct().ToArray();
        c = c.Distinct().ToArray();
        //Array.Sort() Int[] apply functions        
        Array.Sort(a);
        Array.Sort(b);
        Array.Sort(c);
        //Int set to
        var result = 0L;
        //foreach(int int[]) loop through
        foreach (var item in b)
        {
            //int = Count(int[],int) set to function
            var countA = Count(a, item);
            //int = Count(int[],int) set to function
            var countB = Count(c, item);
            //int = int * int augment by
            result += countA * countB;
        }
        //int
        return result;
    }
    //int[], int
    static int Count(int[] array, int item)
    {
        //int = Array.BinarySearch(int[], int)) set to calculate
        var searchIndex = Array.BinarySearch(array, item);
        //if(int >= 0) return int + 1 if condition return int
        if( searchIndex >= 0) return searchIndex + 1;
        //else return Math.Abs(int)-1 
        else return Math.Abs(searchIndex) - 1;
    }
    
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] lenaLenbLenc = Console.ReadLine().Split(' ');

        int lena = Convert.ToInt32(lenaLenbLenc[0]);

        int lenb = Convert.ToInt32(lenaLenbLenc[1]);

        int lenc = Convert.ToInt32(lenaLenbLenc[2]);

        int[] arra = Array.ConvertAll(Console.ReadLine().Split(' '), arraTemp => Convert.ToInt32(arraTemp))
        ;

        int[] arrb = Array.ConvertAll(Console.ReadLine().Split(' '), arrbTemp => Convert.ToInt32(arrbTemp))
        ;

        int[] arrc = Array.ConvertAll(Console.ReadLine().Split(' '), arrcTemp => Convert.ToInt32(arrcTemp))
        ;
        long ans = triplets(arra, arrb, arrc);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
