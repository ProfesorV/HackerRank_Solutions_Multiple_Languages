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
    //long[], long
    static long minTime(long[] machines, long goal) {
        //apply function .Sort(long[])
        Array.Sort(machines);
        //set to long[long.Length-1]
        long max = machines[machines.Length - 1];
        //set to
        long minDays = 0;
        //set to
        long maxDays = max * goal;
        //subtract by
        long result = -1;
        //while condition (<)
        while (minDays < maxDays)
        {
            //set to calculate
            long mid = (minDays + maxDays) / 2;
            //set to
            long unit = 0;
            //foreach conditiono (long in long[])
            foreach (long machine in machines)
            {
                //augment by
                unit += mid / machine;
            }
            //if condition (<)
            if (unit < goal)
            {
                //set to 
                minDays = mid + 1;
            }
            else
            {
                //set to
                result = mid;
                //set to
                maxDays = mid;
            }
        }
        //return
        return result;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nGoal = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nGoal[0]);

        long goal = Convert.ToInt64(nGoal[1]);

        long[] machines = Array.ConvertAll(Console.ReadLine().Split(' '), machinesTemp => Convert.ToInt64(machinesTemp))
        ;
        long ans = minTime(machines, goal);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
