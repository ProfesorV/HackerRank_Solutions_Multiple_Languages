using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        //= .ReadLine().Split(' ')
        string[] stringArrContainer = Console.ReadLine().Split(' ');
        //= .ConvertAll(,.Parse)
        int[] intArr = Array.ConvertAll(stringArrContainer,Int32.Parse);
        //= .ReadLine()
        string word = Console.ReadLine();
        //.WriteLine(.ToCharArray().Max(=> [ - ' ']* .Length))
        Console.Out.WriteLine(word.ToCharArray().Max(ch => intArr[ch - 'a']) 
        * word.Length);
    }
}