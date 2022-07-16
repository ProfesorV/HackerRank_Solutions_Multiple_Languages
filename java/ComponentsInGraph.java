import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        //set to create new
        Scanner scanner = new Scanner(System.in);
        //set to
        int n = scanner.nextInt();
        //set to create new
        int[] parent = new int[2 * n + 1];
        int[] count = new int[2 * n + 1];
        //for <=
        for (int i = 1; i <= 2 * n; i++) {
            //set to
            count[i] = 1;
            parent[i] = i;
        }
        //for <
        for (int i = 0; i < n; i++) {
            //set to
            int g = scanner.nextInt();
            int b = scanner.nextInt();           
            int root_g = g;
            int root_b = b;
            //while !=
            while (parent[root_g] != root_g) root_g = parent[root_g];
            while (parent[root_b] != root_b) root_b = parent[root_b];
            //if ==
            if (root_b == root_g) continue;
            //if <
            if (count[root_b] < count[root_g]) {
                //set to
                parent[root_b] = root_g;
                //+=
                count[root_g] += count[root_b];
            } else {
                //set to
                parent[root_g] = root_b;
                //+=
                count[root_b] += count[root_g];               
            }
        }
        //set to
        int min = 2 * n + 1;
        int max = 2;
        //for <=
        for (int i = 1; i <= 2 * n; i++) {
            //if !=
            if (parent[i] != i) continue;
            //if ==
            if (count[i] == 1) continue;
            //set to
            min = Math.min(min, count[i]);
            max = Math.max(max, count[i]);
        }
        System.out.println(min + " " + max);
    }
}