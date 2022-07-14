import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int n = Integer.parseInt(in.nextLine());
        //set to create new
        int[][] array = new int[n][n];
        int[][] target = new int[n][n];
        //for < 
        for(int i=0; i<n; i++){
            //set to
        	String line = in.nextLine();
            //set to
        	char[] data = line.toCharArray();
            //for <
            for(int j=0; j<n; j++){
                //set to
                array[i][j] = Character.getNumericValue(data[j]);
            }
        }
        cavityMap(array, target);
        //for <
        for(int i=0; i<n; i++){
            //for <
            for(int j=0; j<n; j++){
                //if ==
                if(target[i][j] == -1)
                    System.out.print("X");
                //else
                else
                    System.out.print(array[i][j]);
            }
            System.out.println("");
        }
    }
    //int[][], int[][]
    public static void cavityMap(int[][] array, int[][] target) {
        //set to
        int row = array.length;
        //set to
        int col = array[0].length;
        //for <
        for(int i=1; i<row-1; i++){
            //for <
            for(int j=1; j<col-1; j++){
                //if
                if(isMaximum(array, i, j)){
                    //set to
                    target[i][j] = -1;
                }
            }
        }
    }
    //int[][], int, int
    public static boolean isMaximum(int[][] array, int i, int j) {
        //set to .,.
        int max = Math.max(Math.max(array[i-1][j], array[i+1][j]), Math.max(array[i][j-1], array[i][j+1]));
        //if  >= 
        if(max >= array[i][j])
            //return
            return false;
        else
            //return
            return true;
    }
}