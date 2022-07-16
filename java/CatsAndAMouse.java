import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        //set to
        int queries = in.nextInt();
        //for <
        for(int fori = 0; fori < queries; fori++){
            //set to
            int x = in.nextInt();
            int y = in.nextInt();
            int z = in.nextInt();
            //
            int firstCatDistance = Math.abs(x-z);
            int secondCatDistance = Math.abs(y-z);
            if (firstCatDistance == secondCatDistance) {
                System.out.println("Mouse C");
            } else if (firstCatDistance < secondCatDistance) {
                System.out.println("Cat A");
            } else {
                System.out.println("Cat B");
            }
            
        }
    }
}