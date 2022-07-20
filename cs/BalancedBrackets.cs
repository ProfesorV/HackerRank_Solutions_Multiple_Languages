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
    static string isBalanced(string pStringS)
    {
        //new [] {,,}
        var charArrOpenings = new[] { '[', '{', '(' };
        //new <char>
        var charStack = new Stack<char>();
        //foreach (in .ToCharArray())
        foreach (var c in pStringS.ToCharArray())
        {
            //if .Contains()
            if (charArrOpenings.Contains(c))
            //.Push()
                charStack.Push(c);
                //else if == ''
            else if (c == ']')
                //if (!TryPeek(,out var)|| != '')
                if (!TryPeek(charStack, out var c1) || c1 != '[')
                //return
                    return "NO";
                else
                //.Pop()
                    charStack.Pop();
            //else if
            else if (c == ')')
                //if (!TryPeek(,out var)|| != '')
                if (!TryPeek(charStack, out var c2) || c2 != '(')
                    //return
                    return "NO";
                else
                    //.Pop()
                    charStack.Pop();
            //else if ==
            else if (c == '}')
                //if (!TryPeek(,out var)|| != '')
                if (!TryPeek(charStack, out var c3) || c3 != '{')
                    //return
                    return "NO";
                else
                    //.Pop()
                    charStack.Pop();
        }
        //return .Count == ? :
        return charStack.Count == 0 ? "YES" : "NO";
    }
    //<char>, char
    static bool TryPeek(Stack<char> charStack, out char value)
    {
        //= default()
        value = default(char);
        //if .Count == return
        if (charStack.Count == 0) return false;
        //= .Peek()
        value = charStack.Peek();
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
