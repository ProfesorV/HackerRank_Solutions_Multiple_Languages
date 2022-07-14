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
        //foreach
        foreach (var c in s.ToCharArray())
        {
            //if .
            if (openings.Contains(c))
            //.
                stack.Push(c);
                //else if ==
            else if (c == ']')
                //if !function || !=
                if (!TryPeek(stack, out var c1) || c1 != '[')
                //return
                    return "NO";
                else
                //function
                    stack.Pop();
            //else if
            else if (c == ')')
                //if !function ||
                if (!TryPeek(stack, out var c2) || c2 != '(')
                    //return
                    return "NO";
                else
                    //function
                    stack.Pop();
            //else if ==
            else if (c == '}')
                //if !function ||
                if (!TryPeek(stack, out var c3) || c3 != '{')
                    //return
                    return "NO";
                else
                    //function
                    stack.Pop();
        }
        //return == ?
        return stack.Count == 0 ? "YES" : "NO";
    }
    //<char>, char
    static bool TryPeek(Stack<char> stack, out char value)
    {
        //set to
        value = default(char);
        //if == return
        if (stack.Count == 0) return false;
        //set to .function
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
