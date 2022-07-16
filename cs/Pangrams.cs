using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        //set to
        string parameterSentence = Console.ReadLine();
        //set to create new
        int []intArr = new int[26];
        //for <
        for (int i = 0; i < 26; ++i)
            //set to
            intArr[i] = 0;
            parameterSentence = parameterSentence.ToLower();
            //for <
            for(int i = 0; i < parameterSentence.Length; ++i)
            {
                //if !=
                if(parameterSentence[i] != ' ')
                {
                    //set to
                    intArr[parameterSentence[i] - 'a'] = 1;
                }
            }
            //set to
            int j = 0;
            //for <
            for (j = 0; j < 26; ++j)
                //if ==
                if (intArr[j] == 0)
                    break;
            //if ==
            if (j == 26)
                Console.WriteLine("pangram");
            else
                Console.WriteLine("not pangram");
        }
}
