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
    class Data{
        //declare
        public readonly int Index;
        public readonly int Size;
        //int, int
        public Data(int index, int size){
            //set to
            Index = index;
            Size = size;
        }
    }
    //int[]
    static long largestRectangle(int[] pintArrH)
    {
        //set to
        var max = 0L;
        //set to create new Stack<Data>
        var dataStack = new Stack<Data>();
        //for condition (int < int.Length)
        for (var index = 0; index < pintArrH.Length; index++)
        {
            //if condition (! apply function TryPeek() ||)
            if (!TryPeek(dataStack, out var value) || value.Size < pintArrH[index])
                //apply function .Push(create new Data())
                dataStack.Push(new Data(index, pintArrH[index]));
            //else if (>)
            else if (value.Size > pintArrH[index])
            {
                //set to
                var lastBlockIndex = 0;
                //do condition
                do
                {
                    //set to apply function .Max()
                    max = Math.Max(max,
                        value.Size * (index - value.Index));
                    //set to
                    lastBlockIndex = value.Index;
                    //apply function .Pop()
                    dataStack.Pop();
                    //apply function TryPeek()
                    TryPeek(dataStack, out value);
                    //while condition (!= && >)
                } while (value != null && value.Size > pintArrH[index]);
                //if condition (==)
                if(value == null)
                    //apply function .Push(create new Data())
                    dataStack.Push(new Data(0, pintArrH[index]));
                //else if(<)
                else if(value.Size < pintArrH[index])
                    //apply function .Push(create new Data())
                    dataStack.Push(new Data(lastBlockIndex, pintArrH[index]));
            }
        }
        //while condition (apply function TryPop())
        while (TryPop(dataStack, out var val))
        {
            //set to apply function .Max()
            max = Math.Max(max,
                val.Size * (pintArrH.Length - val.Index));
        }
        //return
        return max;
    }
    //Stack<Data>, Data
    static bool TryPeek(Stack<Data> pdataStack, out Data value)
    {
        //set to
        value = null;
        //if condition (==) return
        if (pdataStack.Count == 0) return false;
        //set to apply function .Peek()
        value = pdataStack.Peek();
        //return
        return true;
    }
    //Stack<Data>, Data
    static bool TryPop(Stack<Data> pdataStack, out Data value)
    {
        //set to
        value = null;
        //if condition (==)
        if (pdataStack.Count == 0) return false;
        //set to apply function .Pop()
        value = pdataStack.Pop();
        //return
        return true;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp))
        ;
        long result = largestRectangle(h);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
