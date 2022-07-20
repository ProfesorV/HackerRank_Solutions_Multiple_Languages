import java.io.*;
import java.util.*;

public class Solution {

    	public static void main(String[] args) {
        //= new
        Scanner scan = new Scanner(System.in);
        //= .parseInt(.nextLine())
        int N = Integer.parseInt(scan.nextLine());
        //= new [][]
        int[][] multiDimArr = new int[N][2];
        //for <
        for(int i = 0; i< N; i++){
            //= .nextLine()
            String stringLine = scan.nextLine();
            //= .split(" ")
            String[] stringArrayQuery = stringLine.split(" ");
            //[][] = .ParseInt([])
            multiDimArr[i][0] = Integer.parseInt(stringArrayQuery[0]);
            //if .length == 
            if(stringArrayQuery.length ==2){
                //[][]=.parseInt([])
                multiDimArr[i][1] = Integer.parseInt(stringArrayQuery[1]);
            }
        }
        heapMethods(multiDimArr);     
    }
    //int[][]
    public static void heapMethods(int[][] pMultiDimArr){
        //= .length
        int N = arr.length;
        //<Integer> = new <Interger>
        PriorityQueue<Integer> priorityQueueIntMinHeap = new PriorityQueue<Integer>();
        //for <
        for(int i = 0; i<N; i++){
            //if [][] == 
            if(pMultiDimArr[i][0] == 1){
                //.add(([][]))
                priorityQueueIntMinHeap.add((pMultiDimArr[i][1]));
                //[][]==
            } else if(pMultiDimArr[i][0] == 2){
                //.remove(([][]))
                priorityQueueIntMinHeap.remove((pMultiDimArr[i][1]));
            } else{
                //.printlin(.peek())
                System.out.println(priorityQueueIntMinHeap.peek());
            }
        }
    }
}