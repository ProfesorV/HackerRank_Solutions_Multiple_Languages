import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        //set to create new
        Scanner scanner = new Scanner(System.in);
        //set to
        String[] stringArrayLine = scanner.nextLine().split(" ");
        int n = Integer.valueOf(stringArrayLine[0]);
        int q = Integer.valueOf(stringArrayLine[1]);
        //set to create new
        int[] intArrA = new int[n+1];
        //for <
        for(int i=0; i<=n; i++) {
            //set to
            intArrA[i] = -1;
        }
        //for <
        for(int i=0; i<q; i++) {
            //set to
            stringArrayLine = scanner.nextLine().split(" ");
            //if ==
            if(stringArrayLine.length == 2) {
                //set to
                int a = Integer.valueOf(stringArrayLine[1]);
                int root = getRoot(intArrA, a);
                System.out.println(size(intArrA, root));
            } else {
                //set to
                int a = Integer.valueOf(stringArrayLine[1]);
                int b = Integer.valueOf(stringArrayLine[2]);
                int aroot = getRoot(intArrA, a);
                int broot = getRoot(intArrA, b);
                //if ==
                if(aroot == broot)
                    continue;
                //if >
                if(size(intArrA, aroot) > size(intArrA, broot)) {
                    //+=
                    intArrA[aroot] += intArrA[broot];
                    //set to
                    intArrA[broot] = aroot;
                //else
                } else {
                    //+=
                    intArrA[broot] += intArrA[aroot];
                    //set to
                    intArrA[aroot] = broot;
                }
            }
        }
    }
    //int[], int
    static int getRoot(int[] pintArr, int a) {
        int root = a;
        //while >
        while(pintArr[root] > 0) {
            root = pintArr[root];
        }
        //if !=
        if(a != root)
            //set to
            pintArr[a] = root;
        return root;
    }
    //int []
    static int size(int[] pintArr, int a) {
        return -1 * pintArr[a];
    }
}