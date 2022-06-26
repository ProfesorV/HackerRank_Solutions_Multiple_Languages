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

    // long[]
    static long[] riddle(long[] arr)
    {
        //set to long[].Length
        int N = arr.Length;
        //set to create new long[int]
        long[] result = new long[N];
        long[] span = new long[N];
        //set to create new Stack<long>()
        var deckValues = new Stack<long>();
        //set to create new Stack<long>()
        var deckIndexes = new Stack<long>();
        //apply function .Push()
        deckIndexes.Push(-1L);
        //for condition (int < int)
        for (int index = 0; index < N; index++)
        {
            //while condition (apply function .TryPeek( && >=))
            while (TryPeek(deckValues, out var val) && val >= arr[index])
            {
                //apply function .Pop()
                deckValues.Pop();
                //apply function .Pop()
                deckIndexes.Pop();
            }
            //set to calculate - apply function .Peek()
            span[index] = index - deckIndexes.Peek() - 1;
            //apply function .Push(long[int])
            deckValues.Push(arr[index]);
            //apply function .Push(int)
            deckIndexes.Push(index);
        }
        // apply function .Clear()
        deckValues.Clear();
        //apply function .Clear()
        deckIndexes.Clear();
        //apply function .Push()
        deckIndexes.Push(N);
        //for condition (int >=0)
        for (int index = N - 1; index >= 0; index--)
        {
            //while condition (TryPeek( && >=))
            while (TryPeek(deckValues, out var val) && val >= arr[index])
            {
                //apply function .Pop()
                deckValues.Pop();
                //apply function .Pop()
                deckIndexes.Pop();
            }
            //augment by apply function .Peek() - int - 1
            span[index] += deckIndexes.Peek() - index - 1;
            //apply function .Push(long[int])
            deckValues.Push(arr[index]);
            //apply function .Push(int)
            deckIndexes.Push(index);
        }
        //for condition (int < int)
        for (int i = 0; i < N; i++)
            //set to apply function .Max(long[(int)long[int]],long[int])
            result[(int)span[i]] = Math.Max(result[(int)span[i]], arr[i]);
        //for condition (int >=0)
        for (int i = N - 2; i >= 0; i--)
            //set to apply function .Max(long[int],long[int +1])
            result[i] = Math.Max(result[i], result[i + 1]);
        //return
        return result;
    }
    //Stack<T>, T
    static bool TryPeek<T>(Stack<T> stack, out T value)
    {
        //set to
        value = default(T);
        //if condition (Stack<T> ==0)
        if (stack.Count == 0) return false;
        //set to apply function .Peek()
        value = stack.Peek();
        //return
        return true;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt64(arrTemp))
        ;
        long[] res = riddle(arr);

        textWriter.WriteLine(string.Join(" ", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
