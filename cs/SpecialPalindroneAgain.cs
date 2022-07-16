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

    class Point
    {
        //declare
        public char text;
        public long counter;
        //char, long
        public Point(char t, long c)
        {
            //set to
            text = t;
            counter = c;
        }
    }
    //int, string
    static long substrCount(int n, string s) {
        //set to
        var count = 0L;
        var repeatingCounter = 1L;
        //set to create new List<Point>
        var list = new List<Point>();
        //for condition (int < string.Length)
        for (int i = 1; i < s.Length; i++)
        {
            //if string[int] == string[int-1]
            if (s[i] == s[i - 1])
            {
                //increment
                repeatingCounter++;
            }
            else
            {
                //apply function .Add(create new (string[int-1],int))
                list.Add(new Point(s[i - 1], repeatingCounter));
                //set to
                repeatingCounter = 1L;
            }
        }
        //apply function .Add(create new s[s.Length-1],int)
        list.Add(new Point(s[s.Length - 1], repeatingCounter));
        //for condition (int <  List<Point>.Count)
        for (int i = 0; i < list.Count; i++)
            //augment by (List<Point>.+1)*List<Point>[int]./2
            count += (list[i].counter + 1) * list[i].counter / 2;
        //for condition (int < List<Point> -1)
        for (int i = 1; i < list.Count - 1; i++)
            //if condition (== && ==)
            if (list[i].counter == 1 && list[i - 1].text == list[i + 1].text)
                //augment by apply function .Min
                count += Math.Min(list[i - 1].counter, list[i + 1].counter);
        //return
        return count;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        long result = substrCount(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
