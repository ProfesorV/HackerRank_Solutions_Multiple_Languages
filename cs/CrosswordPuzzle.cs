// Crossword Puzzle
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
    // string [], string
    static string[] crosswordPuzzle(string[] pStringArrCrossword, string pStringWords)
    {
    //= .Split().ToArray()
        var wordsArray = pStringWords.Split(';').ToArray();
        //FillCrosswordAtt(.Select( =>.Replace("","")).ToArray(), , out)
        if (FillCrosswordAtt(pStringArrCrossword.Select(x => x.Replace("-", ".")).ToArray(), 
        wordsArray, out var result))
        //return
            return result;
        else
        //throw new Exception()
            throw new Exception("Could not find a solution.");
    }
    static bool FillCrosswordAtt(string[] pStringArrCrossword,string[] pStringWords,
    out string[] pStringArrResult)
    {
        //= .Select(=>).ToArray()
        pStringArrResult = pStringArrCrossword.Select(x => x).ToArray();
        //new ("")
        var regex = new Regex("[^\\+]*\\.[^\\+]*");
        //= [0].Length
        var colCount = pStringArrCrossword[0].Length;
        //=
        var rowCount = pStringArrCrossword.Length;
        //= new []
        var stringArrPivotCrossWord = new string[colCount];
        //for <
        for (var i = 0; i < rowCount; i++)
            //for <
            for (var j = 0; j < colCount; j++)
                //[] = ([]??"") + [][]
                stringArrPivotCrossWord[j] = (stringArrPivotCrossWord[j] ?? "") + 
                    pStringArrCrossword[i][j];
        //for <
        for (var index = 0; index < rowCount; index++)
        {
            //foreach in .Matches([])
            foreach (Match match in regex.Matches(pStringArrResult[index]))
            {
                //= new(.Value)
                var matchRegex = new Regex(match.Value);
                //foreach in .Where( => .Length == .Value.Length && .IsMatch())
                foreach (var word in 
                pStringWords.Where(x => x.Length == match.Value.Length 
                && matchRegex.IsMatch(x)))
                {
                    //= []
                    var temp = pStringArrResult[index];
                    //for < .Length
                    for (var j = 0; j < match.Length; j++)
                    //[] = Replace([], .Index +, [])
                        pStringArrResult[index] = 
                        Replace(pStringArrResult[index], match.Index + j, word[j]);
                        //if .FillCrosswordArr(,.Where(=> !=).ToArray(), out)
                    if (FillCrosswordAtt(pStringArrResult, pStringWords.Where(x => x != word)
                    .ToArray(), out var grandResult))
                    {
                        //=
                        pStringArrResult = grandResult;
                        //return
                        return true;
                    }
                    else
                    {
                        //[]=
                        pStringArrResult[index] = temp;
                    }
            }
            //foreach (in .Matches([]))
            foreach (Match match in regex.Matches(stringArrPivotCrossWord[index]))
            {
                //new
                var matchRegex = new Regex(match.Value);
                //foreach in .Where(=> ,Length == .Value.Length && .IsMatch())
                foreach (var word in 
                pStringWords.Where(x => x.Length == match.Value.Length 
                && matchRegex.IsMatch(x)))
                {
                    //set to
                    var temp = "";
                    //for < .Length
                    for (var j = 0; j < match.Length; j++)
                    {
                        //+= .Value[]
                        temp += match.Value[j];
                        //[.Index +] = Replace([.Index + ],[])
                        pStringArrResult[match.Index + j] = Replace(
                            pStringArrResult[match.Index + j],
                            index,
                            word[j]);
                    }
                    //if FillCrosswordAtt(, .Where(=> !=).ToArray() out)
                    if (FillCrosswordAtt(pStringArrResult, pStringWords.Where(x => x != word)
                    .ToArray(), out var grandResult))
                    {
                        //=
                        pStringArrResult = grandResult;
                        //return
                        return true;
                    }
                    else
                    {
                        //for <
                        for (var j = 0; j < match.Length; j++)
                        {
                            //+= [.Index + ]
                            temp += stringArrPivotCrossWord[match.Index + j];
                            //[.Index + ] = Replace([.Index +], +, [])
                            pStringArrResult[match.Index + j] = Replace(
                                respStringArrResultult[match.Index + j],
                                index + j,
                                temp[j]);
                        }
                    }
                }
            }
        }
        //return ! .Any( => .Matches().Count >)
        return !result.Any(x => regex.Matches(x).Count > 0);
    }
    //string, int, char
    static string Replace(string pStringInput, int index, char @char)
    {
        //= .ToCharArray()
        var array = pStringInput.ToCharArray();
        //[] = @
        array[index] = @char;
        //return .Concat()
        return string.Concat(array);
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] pStringArrCrossword = new string [10];

        for (int i = 0; i < 10; i++) {
            string crosswordItem = Console.ReadLine();
            pStringArrCrossword[i] = crosswordItem;
        }

        string pStringWords = Console.ReadLine();

        string[] result = crosswordPuzzle(pStringArrCrossword, pStringWords);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
