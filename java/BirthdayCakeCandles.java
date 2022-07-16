import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        //set to
        int n = in.nextInt();
        int max = 0;
        int sum = 0;
        int num;
        //for <
        for(int i =0; i < n; i++){
            //set to
            num = in.nextInt();
            //if >
            if(num > max){
                //set to
                sum = 1;
                max = num;
            //else if ==
            }else if(num == max){
                //++
                sum++;
            }
        }
        //print
        System.out.println(sum);
    }
}