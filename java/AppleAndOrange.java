import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {

    public static void main(String[] args) {
        //set to create new
        Scanner in = new Scanner(System.in);
        //set to
        int s = in.nextInt();
        int t = in.nextInt();
        int a = in.nextInt();
        int b = in.nextInt();
        int m = in.nextInt();
        int n = in.nextInt();
        //set to create new
        int[] intListApple = new int[m];
        //for <
        for(int iApple=0; iApple < m; iApple++){
            //set to
            intListApple[iApple] = in.nextInt() + a;
        }
        //set to create new
        int[] intListOrange = new int[n];
        //for <
        for(int iOrange=0; iOrange < n; iOrange++){
            //set to
            intListOrange[iOrange] = in.nextInt() + b;
        }
        //set to
        int numberOfApples = 0;
        int numberOfOranges = 0;
        //for 
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


