import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        //= new
        Scanner scanner = new Scanner(System.in);
        //= .nextInt()
        int n = scanner.nextInt();
        //= new[* +]
        int[] parent = new int[2 * n + 1];
        //= new[* +]
        int[] count = new int[2 * n + 1];
        //for <=
        for (int i = 1; i <= 2 * n; i++) {
            //[] =
            count[i] = 1;
            //[] =
            parent[i] = i;
        }
        //for <
        for (int i = 0; i < n; i++) {
            //= .nextInt()
            int g = scanner.nextInt();
            int b = scanner.nextInt();  
            //=         
            int root_g = g;
            int root_b = b;
            //while []!= =[]
            while (parent[root_g] != root_g) root_g = parent[root_g];
            //while []!= =[]
            while (parent[root_b] != root_b) root_b = parent[root_b];
            //if ==
            if (root_b == root_g) continue;
            //if [] < []
            if (count[root_b] < count[root_g]) {
                //[] =
                parent[root_b] = root_g;
                //[] += []
                count[root_g] += count[root_b];
            } else {
                //[] =
                parent[root_g] = root_b;
                //[] += []
                count[root_b] += count[root_g];               
            }
        }
        //set to
        int min = 2 * n + 1;
        int max = 2;
        //for <=
        for (int i = 1; i <= 2 * n; i++) {
            //if []!=
            if (parent[i] != i) continue;
            //if []==
            if (count[i] == 1) continue;
            //.min(,[])
            min = Math.min(min, count[i]);
            //.max(,[])
            max = Math.max(max, count[i]);
        }
        System.out.println(min + " " + max);
    }
}