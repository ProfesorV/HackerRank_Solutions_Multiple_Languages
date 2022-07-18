using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        string[] stringArrContainer = Console.ReadLine().Split(' ');
        int[] intArr = Array.ConvertAll(stringArrContainer,Int32.Parse);
        string word = Console.ReadLine();
        Console.Out.WriteLine(word.ToCharArray().Max(ch => intArr[ch - 'a']) 
        * word.Length);
    }
}