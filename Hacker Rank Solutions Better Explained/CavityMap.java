import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int n = Integer.parseInt(in.nextLine());
        //setmto create new int[int][int]
        int[][] array = new int[n][n];
        int[][] target = new int[n][n];
        //for condition (int < int)
        for(int i=0; i<n; i++){
        	String line = in.nextLine();
        	char[] data = line.toCharArray();
            for(int j=0; j<n; j++){
                array[i][j] = Character.getNumericValue(data[j]);
            }
        }
        cavityMap(array, target);
        for(int i=0; i<n; i++){
            for(int j=0; j<n; j++){
                if(target[i][j] == -1)
                    System.out.print("X");
                else
                    System.out.print(array[i][j]);
            }
            System.out.println("");
        }
    }
    //int[][], int[][]
    public static void cavityMap(int[][] array, int[][] target) {
        //set to int[][].length
        int row = array.length;
        //set to int[0][].length
        int col = array[0].length;
        //for condition (int<int-1)
        for(int i=1; i<row-1; i++){
            //for condition (int<int-1)
            for(int j=1; j<col-1; j++){
                //if condition (apply function isMaximum(int[][],int,int))
                if(isMaximum(array, i, j)){
                    //int[int][int]=-1
                    target[i][j] = -1;
                }
            }
        }
    }
    //int[][], int, int
    public static boolean isMaximum(int[][] array, int i, int j) {
        //set to apply function .max(apply function .max(int[int-1][int], int[int+1][int]), apply function .max(int[int][int-1], int[int][int+1]))
        int max = Math.max(Math.max(array[i-1][j], array[i+1][j]), Math.max(array[i][j-1], array[i][j+1]));
        //if int >= int[int][int]
        if(max >= array[i][j])
            //return
            return false;
        else
            //return
            return true;
    }
}