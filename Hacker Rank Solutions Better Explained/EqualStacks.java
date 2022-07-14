import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        //set to create new
        HashMap<Integer, ArrayList<Integer>> map = new HashMap<Integer, ArrayList<Integer>>();
        int[] sum = new int[3];
        int[] sn = new int[3];
        //for <
        for (int i =0; i< 3 ; i++)
        {
            //set to
            sn[i] = in.nextInt();
        }
        //for <
        for(int i =0; i < 3; i++)
        {
            //., create new
            map.put(i, new ArrayList<Integer>());
            //for <
            for(int j=0 ; j < sn[i]; j++)
            {
                //set to .
                int k = in.nextInt();
                //+=
                sum[i] += k;
                //.,.
                map.get(i).add(0,k);
            }
        }
        //while !(== & ==)
        while (!((sum[0] == sum[1]) && (sum[1] == sum[2])))
        {
            //set to
            int minSum = Math.max(Math.max(sum[0], sum[1]), sum[2]);
            int j = 0;
            //if ==
            if (minSum == sum[0])
                //set to
                j =0;
            //else ==
            else if (minSum == sum[1])
                //set to
                j = 1;
            else
                //set to
                j = 2;
                //-= .,.,.
                sum[j] -=  map.get(j).get(map.get(j).size() - 1);
                //.,.,.,.
                map.get(j).remove(map.get(j).size() - 1);
        }
        System.out.println(sum[0]);
    }
}