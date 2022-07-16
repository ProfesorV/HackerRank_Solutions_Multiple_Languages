import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in=new Scanner(System.in);
        //set to create new
        long[] longArr=new long[5];
        //for <
        for(int i=0;i<5;i++){
            //set to
            longArr[i]=in.nextLong();
        }
        //.
        Arrays.sort(longArr);
        //set to
        long x=0;
        long y=0;
        //for <
        for(int i=0;i<4;i++){
            //+=
            x+=longArr[i];
        }
        //for <
        for(int i=1;i<5;i++){
            //+=
            y+=longArr[i];
        }
        System.out.println(x+" "+y);
    }
}