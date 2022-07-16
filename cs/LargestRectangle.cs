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
    static long largestRectangle(int[] h)
    {
        //set to
        var max = 0L;
        //set to create new Stack<Data>
        var stack = new Stack<Data>();
        //for condition (int < int.Length)
        for (var index = 0; index < h.Length; index++)
        {
            //if condition (! apply function TryPeek() ||)
            if (!TryPeek(stack, out var value) || value.Size < h[index])
                //apply function .Push(create new Data())
                stack.Push(new Data(index, h[index]));
            //else if (>)
            else if (value.Size > h[index])
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
                    stack.Pop();
                    //apply function TryPeek()
                    TryPeek(stack, out value);
                    //while condition (!= && >)
                } while (value != null && value.Size > h[index]);
                //if condition (==)
                if(value == null)
                    //apply function .Push(create new Data())
                    stack.Push(new Data(0, h[index]));
                //else if(<)
                else if(value.Size < h[index])
                    //apply function .Push(create new Data())
                    stack.Push(new Data(lastBlockIndex, h[index]));
            }
        }
        //while condition (apply function TryPop())
        while (TryPop(stack, out var val))
        {
            //set to apply function .Max()
            max = Math.Max(max,
                val.Size * (h.Length - val.Index));
        }
        //return
        return max;
    }
    //Stack<Data>, Data
    static bool TryPeek(Stack<Data> stack, out Data value)
    {
        //set to
        value = null;
        //if condition (==) return
        if (stack.Count == 0) return false;
        //set to apply function .Peek()
        value = stack.Peek();
        //return
        return true;
    }
    //Stack<Data>, Data
    static bool TryPop(Stack<Data> stack, out Data value)
    {
        //set to
        value = null;
        //if condition (==)
        if (stack.Count == 0) return false;
        //set to apply function .Pop()
        value = stack.Pop();
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
