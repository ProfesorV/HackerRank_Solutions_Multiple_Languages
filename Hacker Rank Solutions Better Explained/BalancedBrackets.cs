// Balanced Brackets
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

    //string
    static string isBalanced(string s)
    {
        //set to create new
        var openings = new[] { '[', '{', '(' };
        //set to create new
        var stack = new Stack<char>();
        //foreach condition
        foreach (var c in s.ToCharArray())
        {
            //if condition apply function
            if (openings.Contains(c))
            //apply function
                stack.Push(c);
                //else if condition
            else if (c == ']')
                //if condition ! apply function or
                if (!TryPeek(stack, out var c1) || c1 != '[')
                //return ""
                    return "NO";
                else
                //apply function
                    stack.Pop();
            //else if condition
            else if (c == ')')
                //if condition ! apply function or
                if (!TryPeek(stack, out var c2) || c2 != '(')
                    //return ""
                    return "NO";
                else
                    //apply function
                    stack.Pop();
            //else if condition
            else if (c == '}')
                //if condition ! apply function or
                if (!TryPeek(stack, out var c3) || c3 != '{')
                    //return
                    return "NO";
                else
                    //apply function
                    stack.Pop();
        }
        //return
        return stack.Count == 0 ? "YES" : "NO";
    }
    //<char>, char
    static bool TryPeek(Stack<char> stack, out char value)
    {
        //set to
        value = default(char);
        //if condition return
        if (stack.Count == 0) return false;
        //set to apply function
        value = stack.Peek();
        //return
        return true;
    }
    
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            string s = Console.ReadLine();

            string result = isBalanced(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
