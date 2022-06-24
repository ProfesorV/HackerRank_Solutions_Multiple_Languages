// Maximum Xor
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
    class Trie
    {
        //declare
        Trie left;
        Trie right;
        //Trie, int
        public void Insert(Trie head, int n)
        {
            //for condition (int >= 0)
            for (int i = 31; i >= 0; i--)
            {
                //set to
                int value = (n >> i) & 1;
                //if condition (==)
                if (value == 0)
                {//if condition (Trie.Trie == null)
                    if (head.left == null)
                        //set to create new Trie()
                        head.left = new Trie();
                    //set to
                    head = head.left;
                }
                else
                {//if condition (Trie.Trie ==)
                    if (head.right == null)
                        //set to create new
                        head.right = new Trie();
                    //set to
                    head = head.right;
                }
            }
        }
        //Trie, int
        public uint MaxXor(Trie head, int n)
        {
            //set to
            uint max = 0;
            //for condition (int >= 0)
            for (int i = 31; i >= 0; i--)
            {
                //set to
                int value = (n >> i) & 1;
                //fif condition
                if (value == 0)
                {//if condition(Trie.Trie !=)
                    if (head.right != null)
                    {
                        //augment by apply function .Pow
                        max += (uint)Math.Pow(2, i);
                        //set to
                        head = head.right;
                    }
                    else
                        //set to
                        head = head.left;
                }
                else
                {//if condition (Trie.Trie !=)
                    if (head.left != null)
                    {
                        //augment by apply function .Pow
                        max += (uint)Math.Pow(2, i);
                        //set to
                        head = head.left;
                    }
                    else
                        //set to
                        head = head.right;
                }
            }
            //return
            return max;
        }
    }
    //int[], int[]
    static int[] maxXor(int[] arr, int[] queries)
    {
        //set to create new int[int[].Length]
        int[] result = new int[queries.Length];
        //set to create new Trie()
        Trie head = new Trie();
        //for condition (int < int[],Length)
        for (int i = 0; i < arr.Length; i++)
        {
            //apply function .Insert()
            head.Insert(head, arr[i]);
        }
        //for condition (int < int[].Length)
        for (int i = 0; i < queries.Length; i++)
        {
            //set to apply function .ToInt32(apply function .MaxXor())
            result[i] = Convert.ToInt32(head.MaxXor(head, queries[i]));
        }
        //return
        return result;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int m = Convert.ToInt32(Console.ReadLine());

        int[] queries = new int [m];

        for (int i = 0; i < m; i++) {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[i] = queriesItem;
        }

        int[] result = maxXor(arr, queries);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
