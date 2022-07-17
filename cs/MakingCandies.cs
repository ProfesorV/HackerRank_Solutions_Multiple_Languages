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

    // long, long, long, long
    static long minimumPasses(long machines, long workers, long cost, long goal)
    {
        //set to
        var lower = 1L;
        var upper = 1000000000000L;
        //while (<)
        while (lower < upper)
        {
            //set to calculate
            long mid = (lower + upper) / 2;
            //if condition (apply function ProductionPossible())
            if (ProductionPossible(machines, workers, cost, goal, mid))
                //set to
                upper = mid;
            else
                //set to
                lower = mid + 1;
        }
        //return
        return lower;
    }
    //long, long, long, long, long
    static bool ProductionPossible(long machines, long workers, long price, long target, long days)
    {
        //if condition (>= /) return
        if (machines >= (target + workers - 1) / workers) return true;
        //set to
        var current = machines * workers;
        //decrement
        days--;
        //if (==)
        if (days == 0) return false;
        //while condition
        while (true)
        {
            //set to
            var remaining = target - current;
            //set to
            var daysWithCurrentSettings = (remaining + machines * workers - 1) / (machines * workers);
            //if condition (<=)
            if (daysWithCurrentSettings <= days) return true;
            //if condition (<)
            if (current < price)
            {
                //set to 
                remaining = price - current;
                //set to calculate
                daysWithCurrentSettings = (remaining + machines * workers - 1) / (machines * workers);
                //subtract by -=
                days -= daysWithCurrentSettings;
                //if condition (<)
                if (days < 1) return false;
                //augment by +=
                current += daysWithCurrentSettings * machines * workers;
            }
            //subtract by -=
            current -= price;
            //if condition (>)
            if (machines > workers)
                //increment
                workers++;
            else
                //increment
                machines++;
        }
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] mwpn = Console.ReadLine().Split(' ');

        long m = Convert.ToInt64(mwpn[0]);

        long w = Convert.ToInt64(mwpn[1]);

        long p = Convert.ToInt64(mwpn[2]);

        long n = Convert.ToInt64(mwpn[3]);

        long result = minimumPasses(m, w, p, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
