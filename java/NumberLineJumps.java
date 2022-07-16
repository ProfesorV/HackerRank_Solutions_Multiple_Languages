import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        //Physical representation: Kangaroo's velocity and location
        //set to 
        int x1 = in.nextInt();
        int v1 = in.nextInt();
        int x2 = in.nextInt();
        int v2 = in.nextInt();
        //set to
        int vdiff = v1 - v2;
        //if <=
        if (vdiff <= 0) {
            System.out.println("NO");
            return;
        }
        //set to
        int xdiff = x1 - x2;
        System.out.println(xdiff % vdiff == 0 ? "YES" : "NO");
    }
}