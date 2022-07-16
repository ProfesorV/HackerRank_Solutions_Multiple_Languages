import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        //set to create new
        Scanner sc = new Scanner(System.in);
        //set to
        int n = sc.nextInt();
        //set to create new
        Node[] nodes = new Node[n + 1];
        //for <=
        for(int i = 1; i <= n; i++){
            //set to create new
            nodes[i] = new Node();
        }
        //for <
        for(int i = 1; i < n; i++){
            //set to
            int i1 = sc.nextInt();
            int i2 = sc.nextInt();
            String c = sc.next();
            //if .
            if(c.equals("b")){
                merge(nodes[i1], nodes[i2]);
            }
        }
        //set to
        long sum = (long)n * (n - 1) * (n - 2) / 6;
        //for <=
        for(int i = 1; i <= n; i++){
            //set to .
            Node r = nodes[i].getRoot();
            //if ==
            if(r.size == 1) continue;
            //if .
            if(r.seen) continue;
            //set to
            r.seen = true;
            //-=
            sum -= (long)r.size * (r.size - 1) * (r.size - 2) / 6;
            sum -= (long)r.size * (r.size - 1) / 2 * (n - r.size);
        }
        System.out.println(sum % 1000000007);
    }
    //Node, Node
    static void merge(Node n1, Node n2){
        //set to .
        Node r1 = n1.getRoot();
        Node r2 = n2.getRoot();
        //if ==
        if(r1 == r2) return;
        //if >
        if(r1.size > r2.size){
            //+=
            r1.size += r2.size;
            //set to
            r2.parent = r1;
        } else {
            //+=
            r2.size += r1.size;
            //set to
            r1.parent = r2;
        }
    }
    static class Node{
        //constructor   
        Node(){
            //set to
            size = 1;
        }
        //declare
        boolean seen;
        int size;
        Node parent;

        Node getRoot(){
            //set to
            Node r = this;
            //while !=
            while(r.parent != null) r = r.parent;
            //return
            return r;
        }
    }
}