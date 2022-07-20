import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        //= .nextInt()
        int n = in.nextInt();
        //= .nextInt()
        int p = in.nextInt();
        // = /
        int bookFrontDistribution = p / 2;
        // = & == ? ( - +)/2 : (-)/2
        int bookBackDistribution = n % 2 == 0 ? (n - p + 1) / 2 : (n - p) / 2;
        //.println(.min(,))
        System.out.println(Math.min(bookFrontDistribution, bookBackDistribution));
    }
}