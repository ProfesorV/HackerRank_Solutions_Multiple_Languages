import java.io.*;
import java.util.*;

public class Solution {

    	public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int N = Integer.parseInt(scan.nextLine());
        int[][] arr = new int[N][2];
        
        for(int i = 0; i< N; i++){
            String line = scan.nextLine();
            String[] query = line.split(" ");
            
            arr[i][0] = Integer.parseInt(query[0]);
            if(query.length ==2){
                arr[i][1] = Integer.parseInt(query[1]);
            }
        }
        
        heapMethods(arr);     
    }
    //int[][]
    public static void heapMethods(int[][] arr){
        //set to int[][].length
        int N = arr.length;
        //set to create new PriorityQueue<Integer>
        PriorityQueue<Integer> minHeap = new PriorityQueue<Integer>();
        //for condition(int < int)
        for(int i = 0; i<N; i++){
            //if condition(int[int][0]==1)
            if(arr[i][0] == 1){
                //apply function .add((int[int][1]))
                minHeap.add((arr[i][1]));
                //else if condition (int[int][0]==2)
            } else if(arr[i][0] == 2){
                //apply function .remove((int[int][1]))
                minHeap.remove((arr[i][1]));
            } else{
                //apply function .peek()
                System.out.println(minHeap.peek());
            }
        }
    }
}