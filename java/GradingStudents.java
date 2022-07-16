import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        //set to
        int n = in.nextInt();
        //for <
        for(int a0 = 0; a0 < n; a0++){
            //set to
            int grade = in.nextInt();
            //if >=
            if (grade >= 38) {
                //if > set to
                if (grade%5 >= 3) grade = grade/5*5 + 5;
            }
            //print
            System.out.println(grade);
        }
    }
}