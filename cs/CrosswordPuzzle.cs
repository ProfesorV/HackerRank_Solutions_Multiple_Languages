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
    //set to .,.
        var wordsArray = pStringWords.Split(';').ToArray();
        //if function . passon => .,.
        if (TryFill(pStringArrCrossword.Select(x => x.Replace("-", ".")).ToArray(), 
        wordsArray, out var result))
        //return
            return result;
        else
            throw new Exception("Could not find a solution.");
    }
    //3 string[]
    static bool TryFill(string[] pStringArrCrossword,string[] pStringWords,
    out string[] pStringArrResult)
    {
        //set to . passon =>.
        pStringArrResult = pStringArrCrossword.Select(x => x).ToArray();
        //set to create new Regex
        var regex = new Regex("[^\\+]*\\.[^\\+]*");
        //set to
        var colCount = pStringArrCrossword[0].Length;
        //set to
        var rowCount = pStringArrCrossword.Length;
        //set to create new
        var stringArrPivotCrossWord = new string[colCount];
        //for <
        for (var i = 0; i < rowCount; i++)
            //for <
            for (var j = 0; j < colCount; j++)
                //set to +
                stringArrPivotCrossWord[j] = (stringArrPivotCrossWord[j] ?? "") + 
                    pStringArrCrossword[i][j];
        //for <
        for (var index = 0; index < rowCount; index++)
        {
            //foreach
            foreach (Match match in regex.Matches(pStringArrResult[index]))
            {
                //set to create new
                var matchRegex = new Regex(match.Value);
                //foreach . passon => ==  && .. 
                foreach (var word in 
                pStringWords.Where(x => x.Length == match.Value.Length 
                && matchRegex.IsMatch(x)))
                {
                    //set to 
                    var temp = pStringArrResult[index];
                    //for <
                    for (var j = 0; j < match.Length; j++)
                    //set to 
                        pStringArrResult[index] = 
                        Replace(pStringArrResult[index], match.Index + j, word[j]);
                        //if . passon =>
                    if (TryFill(pStringArrResult, pStringWords.Where(x => x != word)
                    .ToArray(), out var grandResult))
                    {
                        //set to
                        pStringArrResult = grandResult;
                        //return
                        return true;
                    }
                    else
                    {
                        //set to
                        pStringArrResult[index] = temp;
                    }
            }
            //foreach
            foreach (Match match in regex.Matches(stringArrPivotCrossWord[index]))
            {
                //set to create new
                var matchRegex = new Regex(match.Value);
                //foreach . passon => == &&
                foreach (var word in 
                pStringWords.Where(x => x.Length == match.Value.Length 
                && matchRegex.IsMatch(x)))
                {
                    //set to
                    var temp = "";
                    //for <
                    for (var j = 0; j < match.Length; j++)
                    {
                        //+=
                        temp += match.Value[j];
                        //set to
                        pStringArrResult[match.Index + j] = Replace(
                            pStringArrResult[match.Index + j],
                            index,
                            word[j]);
                    }
                    //if . passon => .
                    if (TryFill(pStringArrResult, pStringWords.Where(x => x != word)
                    .ToArray(), out var grandResult))
                    {
                        //set to
                        pStringArrResult = grandResult;
                        //return
                        return true;
                    }
                    else
                    {
                        //for
                        for (var j = 0; j < match.Length; j++)
                        {
                            //+=
                            temp += stringArrPivotCrossWord[match.Index + j];
                            //set to
                            pStringArrResult[match.Index + j] = Replace(
                                respStringArrResultult[match.Index + j],
                                index + j,
                                temp[j]);
                        }
                    }
                }
            }
        }
        //return !. passon => . >
        return !result.Any(x => regex.Matches(x).Count > 0);
    }
    //string, int, char
    static string Replace(string pStringInput, int index, char @char)
    {
        //set to .
        var array = pStringInput.ToCharArray();
        //set to
        array[index] = @char;
        //return .
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
