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

    // int
    static void extraLongFactorials(int n) {
        //set to
        var result = System.Numerics.BigInteger.One;
        //for condition (int <= int)
        for(var index = 2; index <= n; index++)
        //augment by *=
            result *= index;
        //apply function .WriteLine
        Console.WriteLine(result);
    }
    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());

        extraLongFactorials(n);
    }
}
