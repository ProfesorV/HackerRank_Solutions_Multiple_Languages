import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int count = input.nextInt();
        //set to create new int[int]
        int[] sticks = new int[count];
        //set to
        int in = 0;
        //while condition (int < int)
        while(in < count) {
            //set to
            sticks[in] = input.nextInt();
            //increment
            in++;
        }
        //while condition (true)
        while(true) {
            //set to
            int min = Integer.MAX_VALUE;
            //for condition (int < int)
            for (int i = 0; i < count; i++) {
                //if condition (int[int] < int && int[1]!=0)
                if (sticks[i] < min && sticks[i] != 0) {
                    //int = int[int]
                    min = sticks[i];
                }
            }
            //set to
            int slices = 0;
            //for condition (int < int)
            for (int i = 0; i < count; i++)  {
                //if condition (int[int]>0)
                if (sticks[i] > 0) {
                    //set to int[int]
                    int temp = sticks[i];
                    //set to int-int
                    sticks[i] = temp - min;
                    //increment
                    slices++;
                }
            }
            //if condition (int > 0)
            if (slices > 0) 
                System.out.printf("%d%n", slices);
            else
                break;
        }
    }
}