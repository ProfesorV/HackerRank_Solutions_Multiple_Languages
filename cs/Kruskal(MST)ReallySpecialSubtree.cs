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
    public static int kruskals(int gNodes, 
    List<int> pListIntFrom, List<int> pListIntTo, List<int> pListIntWeight)
    {
        //set to crearte new DisjointSets(List<int>)
        var disJointSetClass = new DisjointSets(gNodes);
        //set to create new Edge[int]
        var edgeClassArr = new Edge[pListIntFrom.Count];
        //for condition (int < int)
        for(var index = 0; index < pListIntFrom.Count; index++)
        {
            //set to create new Edge
            edgeClassArr[index] = new Edge
            {
                //set to List<int>[int]
                From = pListIntFrom[index],
                To = pListIntTo[index],
                Weight = pListIntWeight[index]
            };
        }
        //apply function .Sort()
        Array.Sort(edgeClassArr);
        //set to
        var edgesUsed = 0;
        var sum = 0;
        //foreach condition ()
        foreach(var edge in edgeClassArr)
        {
            //if condition (==)
            if(edgesUsed == gNodes - 1) break;
            //if condition ( apply function .FindValue() ==)
            if(disJointSetClass.FindValue(edge.From) == disJointSetClass.FindValue(edge.To)) continue;
            //increment
            edgesUsed++;
            //augment by +=
            sum += edge.Weight;
            //apply function .SetUnion()
            disJointSetClass.SetUnion(edge.From, edge.To);
        }
        //return
        return sum;
    }
    class DisjointSets
    {
        //int[]
        int[] intArrParents;
        int[] intArrRanks;

        public DisjointSets(int nodes)
        {
            //set to create new int[]
            intArrParents = new int[nodes];
            intArrRanks = new int[nodes];
            //for condition (int < int)
            for(var index = 0; index < nodes; index++)
                //int[int] = int
                intArrParents[index] = index;
        }
        //int => apply function FindImplementation(int-1)+1
        public int FindValue(int value) => FindImplementation(value - 1) + 1;
        //int
        private int FindImplementation(int value)
        {
            //if condition (int[int]==int)
            if(intArrParents[value] == value)
                //return
                return value;
            else
                //return apply function FindImplementation(int[int])
                return FindImplementation(intArrParents[value]);
        }
        //int, int
        public void SetUnion(int left, int right)
        {
            //set to apply function FindValue(int)-1
            left = FindValue(left) - 1;
            right = FindValue(right) - 1;
            //if condition (>))
            if(intArrRanks[left] > intArrRanks[right])
            {
                //set to
                intArrParents[right] = left;
            }
            //else if condition (<)
            else if(intArrRanks[left] < intArrRanks[right])
            {  
                //set to
                intArrParents[left] = right;
            }
            else
            {
                //set to
                intArrParents[right] = left;
                //increment
                intArrRanks[left]++;
            }                
        }
    }
    class Edge : IComparable<Edge>
    {
        public int From;
        public int To;
        public int Weight;
        //Edge
        public int CompareEdges(Edge other)
        {
            //set to apply function .CompareEdges()
            var result = Weight.CompareEdges(other.Weight);
            //if condition (!=)
            if(result != 0) return result;
            //return calculation apply function .CompareEdges(calculation)
            return (From + Weight + To).CompareEdges(other.From + other.Weight + other.To);
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

        List<int> pListIntFrom = new List<int>();
        List<int> pListIntTo = new List<int>();
        List<int> pListIntWeight = new List<int>();

        for (int i = 0; i < gEdges; i++)
        {
            string[] gFromToWeight = Console.ReadLine().TrimEnd().Split(' ');

            pListIntFrom.Add(Convert.ToInt32(gFromToWeight[0]));
            pListIntTo.Add(Convert.ToInt32(gFromToWeight[1]));
            pListIntWeight.Add(Convert.ToInt32(gFromToWeight[2]));
        }

        int res = Result.kruskals(gNodes, pListIntFrom, pListIntTo, pListIntWeight);

        textWriter.Write(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
