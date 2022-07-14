import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        //set to create new
        Scanner input = new Scanner(System.in);
        //set to
        int count = input.nextInt();
        //set to create new int[int]
        int[] sticks = new int[count];
        //set to
        int in = 0;
        //while <
        while(in < count) {
            //set to
            sticks[in] = input.nextInt();
            //++
            in++;
        }
        //while
        while(true) {
            //set to
            int min = Integer.MAX_VALUE;
            //for <
            for (int i = 0; i < count; i++) {
                //if < && !=
                if (sticks[i] < min && sticks[i] != 0) {
                    //set to
                    min = sticks[i];
                }
            }
            //set to
            int slices = 0;
            //for <
            for (int i = 0; i < count; i++)  {
                //if >
                if (sticks[i] > 0) {
                    //set to 
                    int temp = sticks[i];
                    //set to -
                    sticks[i] = temp - min;
                    //++
                    slices++;
                }
            }
            //if >
            if (slices > 0) 
                System.out.printf("%d%n", slices);
            else
                break;
        }
    }
}