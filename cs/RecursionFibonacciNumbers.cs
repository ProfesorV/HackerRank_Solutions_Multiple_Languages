// Recursion: Fibonacci Numbers
using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    //int
    public static int Fibonacci(int n) {
        //if condition(int < 2) return
        if(n < 2) return n;
        //return function (int - 2) + function (int -1)
        return Fibonacci(n - 2) + Fibonacci(n - 1);
    }
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));
    }
}

