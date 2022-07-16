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
    static int findShortest(int graphNodes, int[] graphFrom, int[] graphTo, long[] ids, int val) {
        //set to create new bool[]
        var visited = new bool[graphNodes];
        //set to create new int[]
        var stepsToReach = new int[graphNodes];
        //set to create new Dictionary<int, List<int>>s
        var path = new Dictionary<int, List<int>>();
        //set to create new Dictionary <int, long>
        var colors = new Dictionary<int, long>();
        //for condition (int < int[].Length)
        for(var index = 0; index < graphFrom.Length; index++)
            //apply function()
            AddPath(path, graphFrom[index], graphTo[index]);
        //for (int < long[].Length)
        for(var index = 0; index < ids.Length; index++)
            //apply function .Add()
            colors.Add(index + 1, ids[index]);
        //set to create new Queue<int>
        var queue = new Queue<int>();
        //apply function .Enqueue()
        queue.Enqueue(val);
        //while condition (apply function TryDequeue())
        while(TryDequeue(queue, out var current))
        {
            //if condition(== && !=) return
            if(colors[current] == colors[val] && current != val) return stepsToReach[current - 1];
            //if condition ()
             if (visited[current - 1]) continue;
            //else
            else visited[current - 1] = true;
            //if condition (apply function .TryGetValue())
            if (path.TryGetValue(current, out var list))
            {
                //foreach condition ()
                foreach (var next in list)
                {
                    //set to int[int-1]+1
                    stepsToReach[next - 1] = stepsToReach[current - 1] + 1;
                    //apply .Enqueue()
                    queue.Enqueue(next);
                }
            }
        }
        //return
        return -1;
    }
    //Queue<T>, T
    static bool TryDequeue<T>(Queue<T> queue, out T value)
    {
        //set to
        value = default(T);
        //if condition (==)
        if(queue.Count == 0) return false;
        //set to, apply function .Dequeue
        value = queue.Dequeue();
        //return
        return true;
    }
    //Dictionary<int, List<int>, int, int, bool
    static void AddPath(Dictionary<int, List<int>> path, int from, int to, bool bothWays = true)
    {
        //if condition (apply function TryGetValue())
        if (path.TryGetValue(from, out var list))
        {
            //if condition(! apply function .Contains())
            if (!list.Contains(to))
                //apply function .Add()
                list.Add(to);
        }
        //else
        else
            //apply function .Add()
            path.Add(from, new List<int> { to });
        //if condition
        if(bothWays)
            //apply function
            AddPath(path, to, from, false);
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] graphNodesEdges = Console.ReadLine().Split(' ');
        int graphNodes = Convert.ToInt32(graphNodesEdges[0]);
        int graphEdges = Convert.ToInt32(graphNodesEdges[1]);

        int[] graphFrom = new int[graphEdges];
        int[] graphTo = new int[graphEdges];

        for (int i = 0; i < graphEdges; i++) {
            string[] graphFromTo = Console.ReadLine().Split(' ');
            graphFrom[i] = Convert.ToInt32(graphFromTo[0]);
            graphTo[i] = Convert.ToInt32(graphFromTo[1]);
        }

        long[] ids = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), idsTemp => Convert.ToInt64(idsTemp))
        ;
        int val = Convert.ToInt32(Console.ReadLine());

        int ans = findShortest(graphNodes, graphFrom, graphTo, ids, val);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
