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

    // int[], int
    static int activityNotifications(int[] pIntArrExpense, int d)
    {
        //set to
        int count = 0;
        //set to create new int[]
        var intArrFrequency = new int[201];
        //set to create new List<int>
        List<int> listIntQ = new List<int>();
        //for condition (int < int[].Length)
        for (int i = 0; i < pIntArrExpense.Length; i++)
        {
            //while condition (int < int)
            while (i < d)
            {
                //apply function .Add(int[int])
                listIntQ.Add(pIntArrExpense[i]);
                //set to int[int[int]]+1
                intArrFrequency[pIntArrExpense[i]] = 
                intArrFrequency[pIntArrExpense[i]] + 1;
                //increment
                i++;
            }
            //set to apply function
            float median = getMedianValue(intArrFrequency, d);
            //if condition (>= )
            if (pIntArrExpense[i] >= 2 * median)
            {
                //increment
                count++;
            }
            // set to int[0]
            int elem = listIntQ[0];
            //apply function .RemoveAt()
            listIntQ.RemoveAt(0);
            //set to int[int]-1
            intArrFrequency[elem] = intArrFrequency[elem] - 1;
            //apply function .Add(int[int])
            listIntQ.Add(pIntArrExpense[i]);
            //set to int[int[int]]+1
            intArrFrequency[pIntArrExpense[i]] = intArrFrequency[pIntArrExpense[i]] + 1;
        }
        //return
        return count;
    }
    //int[], int
    private static float getMedianValue(int[] pIntArr, int d)
    {
        //if condition(==)
        if (d % 2 == 1)
        {
            //set to
            int center = 0;
            //for condition (int < int[].Length)
            for (int i = 0; i < pIntArr.Length; i++)
            {
                //set to calculate
                center = center + pIntArr[i];
                //if condition (int > int/2)
                if (center > d / 2)
                {
                    //return
                    return i;
                }
            }
        }
        else
        {
            //set to
            int count = 0;
            int first = -1;
            int second = -1;
            //for condition (int < int[].Length)
            for (int i = 0; i < pIntArr.Length; i++)
            {
                //set to
                count = count + pIntArr[i];
                //if condition (==)
                if (count == d / 2)
                {
                    //set to
                    first = i;
                }
                //else if (int > int/2)
                else if (count > d / 2)
                {
                    //if condition (<) set to
                    if (first < 0) first = i;
                    second = i;
                    //return
                    return ((float)first + (float)second) / 2;
                }
            }
        }
        //return
        return 0f;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] pIntArrExpense = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp))
        ;
        int result = activityNotifications(pIntArrExpense, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
