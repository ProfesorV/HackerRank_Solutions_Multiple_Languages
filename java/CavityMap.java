import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int n = Integer.parseInt(in.nextLine());
        //= new [][]
        int[][] array = new int[n][n];
        //= new [][]
        int[][] target = new int[n][n];
        //for < 
        for(int i=0; i<n; i++){
            //= .nextLine()
        	String line = in.nextLine();
            //= .toCharArray()
        	char[] data = line.toCharArray();
            //for <
            for(int j=0; j<n; j++){
                //[][] = .getNumericValue([])
                array[i][j] = Character.getNumericValue(data[j]);
            }
        }
        cavityMap(array, target);
        //for <
        for(int i=0; i<n; i++){
            //for <
            for(int j=0; j<n; j++){
                //if [][] == 
                if(target[i][j] == -1)
                    System.out.print("X");
                //else
                else
                    //.print([][])
                    System.out.print(array[i][j]);
            }
            System.out.println("");
        }
    }
    //int[][], int[][]
    public static void cavityMap(int[][] array, int[][] target) {
        //= .length
        int row = array.length;
        //= [].length
        int col = array[0].length;
        //for <
        for(int i=1; i<row-1; i++){
            //for <
            for(int j=1; j<col-1; j++){
                //if isMaximum(,,)
                if(isMaximum(array, i, j)){
                    //[][]=
                    target[i][j] = -1;
                }
            }
        }
    }
    //int[][], int, int
    public static boolean isMaximum(int[][] array, int i, int j) {
        //.max(.max([-][],[+][])), .max([][-],[][+])
        int max = Math.max(Math.max(array[i-1][j], array[i+1][j]), Math.max(array[i][j-1], array[i][j+1]));
        //if  >= [][]
        if(max >= array[i][j])
            //return
            return false;
        else
            //return
            return true;
    }
}