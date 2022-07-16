import java.io.*;
import java.util.*;

public class Solution {

    	public static void main(String[] args) {
        //set to create new
        Scanner scan = new Scanner(System.in);
        //set to
        int N = Integer.parseInt(scan.nextLine());
        //set to create new
        int[][] multiDimArr = new int[N][2];
        //for <
        for(int i = 0; i< N; i++){
            //set to
            String stringLine = scan.nextLine();
            String[] stringArrayQuery = stringLine.split(" ");
            
            multiDimArr[i][0] = Integer.parseInt(stringArrayQuery[0]);
            if(stringArrayQuery.length ==2){
                multiDimArr[i][1] = Integer.parseInt(stringArrayQuery[1]);
            }
        }
        heapMethods(multiDimArr);     
    }
    //int[][]
    public static void heapMethods(int[][] pMultiDimArr){
        //set to 
        int N = arr.length;
        //set to create new
        PriorityQueue<Integer> priorityQueueIntMinHeap = new PriorityQueue<Integer>();
        //for <
        for(int i = 0; i<N; i++){
            //if ==
            if(pMultiDimArr[i][0] == 1){
                //.
                priorityQueueIntMinHeap.add((pMultiDimArr[i][1]));
                //else if
            } else if(pMultiDimArr[i][0] == 2){
                //.
                priorityQueueIntMinHeap.remove((pMultiDimArr[i][1]));
            } else{
                //.
                System.out.println(priorityQueueIntMinHeap.peek());
            }
        }
    }
}