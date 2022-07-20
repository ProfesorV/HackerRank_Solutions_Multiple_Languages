import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        //= .nextInt()
        int queries = in.nextInt();
        //for <
        for(int fori = 0; fori < queries; fori++){
            //.nextInt()
            int x = in.nextInt();
            int y = in.nextInt();
            int z = in.nextInt();
            //= .abs()
            int firstCatDistance = Math.abs(x-z);
            int secondCatDistance = Math.abs(y-z);
            //if ==
            if (firstCatDistance == secondCatDistance) {
                System.out.println("Mouse C");
                //else if <
            } else if (firstCatDistance < secondCatDistance) {
                System.out.println("Cat A");
                //else
            } else {
                System.out.println("Cat B");
            }
            
        }
    }
}