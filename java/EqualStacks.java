import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        //<Integer,ArrayList<Integer>> = new <,< >>
        HashMap<Integer, ArrayList<Integer>> IntArrLisIntHashMap = new HashMap<Integer, ArrayList<Integer>>();
        //= new []
        int[] intArrSum = new int[3];
        //= new []
        int[] intArrSn = new int[3];
        //for <
        for (int i =0; i< 3 ; i++)
        {
            //[] = .nextInt()
            intArrSn[i] = in.nextInt();
        }
        //for <
        for(int i =0; i < 3; i++)
        {
            //.put(,new < >())
            IntArrLisIntHashMap.put(i, new ArrayList<Integer>());
            //for <
            for(int j=0 ; j < intArrSn[i]; j++)
            {
                //= .nextInt()
                int k = in.nextInt();
                //[] += 
                intArrSum[i] += k;
                //.get().add(,)
                IntArrLisIntHashMap.get(i).add(0,k);
            }
        }
        //while !(([]==[]) && ([]==[]))
        while (!((intArrSum[0] == intArrSum[1]) && (intArrSum[1] == intArrSum[2])))
        {
            //= .max(.max([],[],[]))
            int minSum = Math.max(Math.max(intArrSum[0], intArrSum[1]), intArrSum[2]);
            //=
            int j = 0;
            //if ==[]
            if (minSum == intArrSum[0])
                //=
                j =0;
            //else == []
            else if (minSum == intArrSum[1])
                //=
                j = 1;
            else
                //=
                j = 2;
                //[] -= .get().get(.get().size()-1)
                intArrSum[j] -=  IntArrLisIntHashMap.get(j).get(IntArrLisIntHashMap.get(j).size() - 1);
                //.get().remove(.get().size()-1)
                IntArrLisIntHashMap.get(j).remove(IntArrLisIntHashMap.get(j).size() - 1);
        }
        //println([])
        System.out.println(intArrSum[0]);
    }
}