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
    //int, int[], int[], long[], int
    static int findShortest(int graphNodes, 
    int[] pIntArrFrom, int[] pIntArrTo, long[] pLongArrID, int val) {
        //set to create new bool[]
        var boolArrVisited = new bool[graphNodes];
        //set to create new int[]
        var intArrSteps = new int[graphNodes];
        //set to create new Dictionary<int, List<int>>s
        var intListIntDicPath = new Dictionary<int, List<int>>();
        //set to create new Dictionary <int, long>
        var intLongDicColor = new Dictionary<int, long>();
        //for condition (int < int[].Length)
        for(var index = 0; index < pIntArrFrom.Length; index++)
            //apply function()
            AddTo(intListIntDicPath, pIntArrFrom[index], pIntArrTo[index]);
        //for (int < long[].Length)
        for(var index = 0; index < pLongArrID.Length; index++)
            //apply function .Add()
            intLongDicColor.Add(index + 1, pLongArrID[index]);
        //set to create new Queue<int>
        var intQueue = new Queue<int>();
        //apply function .Enqueue()
        intQueue.Enqueue(val);
        //while condition (apply function DequeueAttempt())
        while(DequeueAttempt(intQueue, out var current))
        {
            //if condition(== && !=) return
            if(intLongDicColor[current] == intLongDicColor[val] && current != val) 
            return intArrSteps[current - 1];
            //if condition ()
             if (boolArrVisited[current - 1]) continue;
            //else
            else boolArrVisited[current - 1] = true;
            //if condition (apply function .TryGetValue())
            if (intListIntDicPath.TryGetValue(current, out var outVarList))
            {
                //foreach condition ()
                foreach (var next in outVarList)
                {
                    //set to int[int-1]+1
                    intArrSteps[next - 1] = intArrSteps[current - 1] + 1;
                    //apply .Enqueue()
                    intQueue.Enqueue(next);
                }
            }
        }
        //return
        return -1;
    }
    //Queue<T>, T
    static bool DequeueAttempt<T>(Queue<T> pIntQueue, out T value)
    {
        //set to
        value = default(T);
        //if condition (==)
        if(pIntQueue.Count == 0) return false;
        //set to, apply function .Dequeue
        value = pIntQueue.Dequeue();
        //return
        return true;
    }
    //Dictionary<int, List<int>, int, int, bool
    static void AddTo(Dictionary<int, List<int>> pIntListIntDicPath, 
    int from, int to, bool bothWays = true)
    {
        //if condition (apply function TryGetValue())
        if (pIntListIntDicPath.TryGetValue(from, out var outVarList))
        {
            //if condition(! apply function .Contains())
            if (!outVarList.Contains(to))
                //apply function .Add()
                outVarList.Add(to);
        }
        //else
        else
            //apply function .Add()
            pIntListIntDicPath.Add(from, new List<int> { to });
        //if condition
        if(bothWays)
            //apply function
            AddTo(pIntListIntDicPath, to, from, false);
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] graphNodesEdges = Console.ReadLine().Split(' ');
        int graphNodes = Convert.ToInt32(graphNodesEdges[0]);
        int graphEdges = Convert.ToInt32(graphNodesEdges[1]);

        int[] pIntArrFrom = new int[graphEdges];
        int[] pIntArrTo = new int[graphEdges];

        for (int i = 0; i < graphEdges; i++) {
            string[] graphFromTo = Console.ReadLine().Split(' ');
            pIntArrFrom[i] = Convert.ToInt32(graphFromTo[0]);
            pIntArrTo[i] = Convert.ToInt32(graphFromTo[1]);
        }

        long[] pLongArrID = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), pLongArrIDTemp => Convert.ToInt64(pLongArrIDTemp))
        ;
        int val = Convert.ToInt32(Console.ReadLine());

        int ans = findShortest(graphNodes, pIntArrFrom, pIntArrTo, pLongArrID, val);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
