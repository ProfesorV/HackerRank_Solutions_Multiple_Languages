import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {

    static int purchasableGames(int p, int d, int m, int s) {
        //set to
        int currentPrice = p;
        int i=0;
        //while >=
        while(s>=currentPrice){
            //set to
            s=s-currentPrice;
            //if >=
            if(currentPrice>=m+d){
                //set to
                currentPrice=currentPrice-d;
            //else
            }else{
                currentPrice = m;
            }
            //++
            i++;
        }
        //return
        return i;
    }

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int p = in.nextInt();
        int d = in.nextInt();
        int m = in.nextInt();
        int s = in.nextInt();
        int answer = purchasableGames(p, d, m, s);
        System.out.println(answer);
        in.close();
    }
}
