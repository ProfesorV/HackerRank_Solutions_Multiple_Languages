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
    static string[] crosswordPuzzle(string[] crossword, string words)
    {
    //set to .,.
        var wordsArray = words.Split(';').ToArray();
        //if function . passon => .,.
        if (TryFill(crossword.Select(x => x.Replace("-", ".")).ToArray(), wordsArray, out var result))
        //return
            return result;
        else
            throw new Exception("Could not find a solution.");
    }
    //3 string[]
    static bool TryFill(
        string[] crossword,
        string[] words,
        out string[] result)
    {
        //set to . passon =>.
        result = crossword.Select(x => x).ToArray();
        //set to create new Regex
        var regex = new Regex("[^\\+]*\\.[^\\+]*");
        //set to
        var colCount = crossword[0].Length;
        //set to
        var rowCount = crossword.Length;
        //set to create new
        var pivotCrossword = new string[colCount];
        //for <
        for (var i = 0; i < rowCount; i++)
            //for <
            for (var j = 0; j < colCount; j++)
                //set to +
                pivotCrossword[j] = (pivotCrossword[j] ?? "") + crossword[i][j];
        //for <
        for (var index = 0; index < rowCount; index++)
        {
            //foreach
            foreach (Match match in regex.Matches(result[index]))
            {
                //set to create new
                var matchRegex = new Regex(match.Value);
                //foreach . passon => ==  && .. 
                foreach (var word in words.Where(x => x.Length == match.Value.Length && matchRegex.IsMatch(x)))
                {
                    //set to 
                    var temp = result[index];
                    //for <
                    for (var j = 0; j < match.Length; j++)
                    //set to 
                        result[index] = Replace(result[index], match.Index + j, word[j]);
                        //if . passon =>
                    if (TryFill(result, words.Where(x => x != word).ToArray(), out var grandResult))
                    {
                        //set to
                        result = grandResult;
                        //return
                        return true;
                    }
                    else
                    {
                        //set to
                        result[index] = temp;
                    }

                    //for (int j = 0; j < match.Length; j++)
                    //    pivotCrossword[match.Index + j] = Replace(
                    //        pivotCrossword[match.Index + j], 
                    //        index + j, 
                    //        word[j]);
                }
            }
            //foreach
            foreach (Match match in regex.Matches(pivotCrossword[index]))
            {
                //set to create new
                var matchRegex = new Regex(match.Value);
                //foreach . passon => == &&
                foreach (var word in words.Where(x => x.Length == match.Value.Length && matchRegex.IsMatch(x)))
                {
                    //set to
                    var temp = "";
                    //for <
                    for (var j = 0; j < match.Length; j++)
                    {
                        //+=
                        temp += match.Value[j];
                        //set to
                        result[match.Index + j] = Replace(
                            result[match.Index + j],
                            index,
                            word[j]);
                    }
                    //if . passon => .
                    if (TryFill(result, words.Where(x => x != word).ToArray(), out var grandResult))
                    {
                        //set to
                        result = grandResult;
                        //return
                        return true;
                    }
                    else
                    {
                        //for
                        for (var j = 0; j < match.Length; j++)
                        {
                            //+=
                            temp += pivotCrossword[match.Index + j];
                            //set to
                            result[match.Index + j] = Replace(
                                result[match.Index + j],
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
    static string Replace(string input, int index, char @char)
    {
        //set to .
        var array = input.ToCharArray();
        //set to
        array[index] = @char;
        //return .
        return string.Concat(array);
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] crossword = new string [10];

        for (int i = 0; i < 10; i++) {
            string crosswordItem = Console.ReadLine();
            crossword[i] = crosswordItem;
        }

        string words = Console.ReadLine();

        string[] result = crosswordPuzzle(crossword, words);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
