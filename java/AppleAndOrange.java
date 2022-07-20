import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {

    public static void main(String[] args) {
        //new
        Scanner in = new Scanner(System.in);
        //= .nextInt
        int s = in.nextInt();
        int t = in.nextInt();
        int a = in.nextInt();
        int b = in.nextInt();
        int m = in.nextInt();
        int n = in.nextInt();
        //new []
        int[] intListApple = new int[m];
        //for <
        for(int iApple=0; iApple < m; iApple++){
            //[] = .nextInt() +
            intListApple[iApple] = in.nextInt() + a;
        }
        //= new []
        int[] intListOrange = new int[n];
        //for <
        for(int iOrange=0; iOrange < n; iOrange++){
            //[] = .nextInt() +
            intListOrange[iOrange] = in.nextInt() + b;
        }
        //=
        int numberOfApples = 0;
        int numberOfOranges = 0;
        //for (:) 
        for (int appleInIntList : intListApple) {
            //if >= && <=
            if (appleInIntList >= s && appleInIntList <= t) {
                //+=
                numberOfApples += 1;
            }
        }//for
        for (int orangeInIntList : intListOrange) {
            //if
            if (orangeInIntList >= s && orangeInIntList <= t) {
                //+=
                numberOfOranges += 1;
            }
        }
        System.out.println(numberOfApples);
        System.out.println(numberOfOranges);
    }
}


