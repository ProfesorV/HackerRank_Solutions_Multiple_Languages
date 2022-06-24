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

class Result
{
    //int, List<int>, List<int>, List<int>
    public static int kruskals(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight)
    {
        //set to crearte new DisjointSets(List<int>)
        var ds = new DisjointSets(gNodes);
        //set to create new Edge[int]
        var edges = new Edge[gFrom.Count];
        //for condition (int < int)
        for(var index = 0; index < gFrom.Count; index++)
        {
            //set to create new Edge
            edges[index] = new Edge
            {
                //set to List<int>[int]
                From = gFrom[index],
                To = gTo[index],
                Weight = gWeight[index]
            };
        }
        //apply function .Sort()
        Array.Sort(edges);
        //set to
        var edgesUsed = 0;
        var sum = 0;
        //foreach condition ()
        foreach(var edge in edges)
        {
            //if condition (==)
            if(edgesUsed == gNodes - 1) break;
            //if condition ( apply function .Find() ==)
            if(ds.Find(edge.From) == ds.Find(edge.To)) continue;
            //increment
            edgesUsed++;
            //augment by +=
            sum += edge.Weight;
            //apply function .Union()
            ds.Union(edge.From, edge.To);
        }
        //return
        return sum;
    }
    class DisjointSets
    {
        //int[]
        int[] Parents;
        int[] Ranks;

        public DisjointSets(int nodes)
        {
            //set to create new int[]
            Parents = new int[nodes];
            Ranks = new int[nodes];
            //for condition (int < int)
            for(var index = 0; index < nodes; index++)
                //int[int] = int
                Parents[index] = index;
        }
        //int => apply function FindImpl(int-1)+1
        public int Find(int value) => FindImpl(value - 1) + 1;
        //int
        private int FindImpl(int value)
        {
            //if condition (int[int]==int)
            if(Parents[value] == value)
                //return
                return value;
            else
                //return apply function FindImpl(int[int])
                return FindImpl(Parents[value]);
        }
        //int, int
        public void Union(int left, int right)
        {
            //set to apply function Find(int)-1
            left = Find(left) - 1;
            right = Find(right) - 1;
            //if condition (>))
            if(Ranks[left] > Ranks[right])
            {
                //set to
                Parents[right] = left;
            }
            //else if condition (<)
            else if(Ranks[left] < Ranks[right])
            {  
                //set to
                Parents[left] = right;
            }
            else
            {
                //set to
                Parents[right] = left;
                //increment
                Ranks[left]++;
            }                
        }
    }
    class Edge : IComparable<Edge>
    {
        public int From;
        public int To;
        public int Weight;
        //Edge
        public int CompareTo(Edge other)
        {
            //set to apply function .CompareTo()
            var result = Weight.CompareTo(other.Weight);
            //if condition (!=)
            if(result != 0) return result;
            //return calculation apply function .CompareTo(calculation)
            return (From + Weight + To).CompareTo(other.From + other.Weight + other.To);
        }
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] gNodesEdges = Console.ReadLine().TrimEnd().Split(' ');

        int gNodes = Convert.ToInt32(gNodesEdges[0]);
        int gEdges = Convert.ToInt32(gNodesEdges[1]);

        List<int> gFrom = new List<int>();
        List<int> gTo = new List<int>();
        List<int> gWeight = new List<int>();

        for (int i = 0; i < gEdges; i++)
        {
            string[] gFromToWeight = Console.ReadLine().TrimEnd().Split(' ');

            gFrom.Add(Convert.ToInt32(gFromToWeight[0]));
            gTo.Add(Convert.ToInt32(gFromToWeight[1]));
            gWeight.Add(Convert.ToInt32(gFromToWeight[2]));
        }

        int res = Result.kruskals(gNodes, gFrom, gTo, gWeight);

        textWriter.Write(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
