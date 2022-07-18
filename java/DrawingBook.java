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
        int p = in.nextInt();
        int bookFrontDistribution = p / 2;
        int bookBackDistribution = n % 2 == 0 ? (n - p + 1) / 2 : (n - p) / 2;
        System.out.println(Math.min(bookFrontDistribution, bookBackDistribution));
    }
}