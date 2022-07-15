import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        //set to create new
        HashMap<Integer, ArrayList<Integer>> IntArrLisIntHashMap = new HashMap<Integer, ArrayList<Integer>>();
        int[] intArrSum = new int[3];
        int[] intArrSn = new int[3];
        //for <
        for (int i =0; i< 3 ; i++)
        {
            //set to
            intArrSn[i] = in.nextInt();
        }
        //for <
        for(int i =0; i < 3; i++)
        {
            //., create new
            IntArrLisIntHashMap.put(i, new ArrayList<Integer>());
            //for <
            for(int j=0 ; j < intArrSn[i]; j++)
            {
                //set to .
                int k = in.nextInt();
                //+=
                intArrSum[i] += k;
                //.,.
                IntArrLisIntHashMap.get(i).add(0,k);
            }
        }
        //while !(== & ==)
        while (!((intArrSum[0] == intArrSum[1]) && (intArrSum[1] == intArrSum[2])))
        {
            //set to
            int minSum = Math.max(Math.max(intArrSum[0], intArrSum[1]), intArrSum[2]);
            int j = 0;
            //if ==
            if (minSum == intArrSum[0])
                //set to
                j =0;
            //else ==
            else if (minSum == intArrSum[1])
                //set to
                j = 1;
            else
                //set to
                j = 2;
                //-= .,.,.
                intArrSum[j] -=  IntArrLisIntHashMap.get(j).get(IntArrLisIntHashMap.get(j).size() - 1);
                //.,.,.,.
                IntArrLisIntHashMap.get(j).remove(IntArrLisIntHashMap.get(j).size() - 1);
        }
        System.out.println(intArrSum[0]);
    }
}