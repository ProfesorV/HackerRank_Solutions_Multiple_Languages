import java.io.*;
import java.util.*;

public class Solution {
    private static void getMaxElementFromStack()
    {
        //set to create new
        Stack<Integer> stack = new Stack<Integer>();
        Stack<Integer> maxElements = new Stack<Integer>();
        Scanner sc = new Scanner(System.in);
        //set to
        int N = Integer.parseInt(sc.nextLine());
        int temp = 0;
        //while .
        while(sc.hasNext())
        {
            //set to .,.
            String type[] = sc.nextLine().split(" ");
            //switch
            switch(type[0])
            {
                //case
                case "1":
                //set to .
                temp = Integer.parseInt(type[1]);
                // .
                stack.push(temp);
                //if . || . <=
                 if(maxElements.isEmpty() || maxElements.peek() <= temp)
                    //.
                     maxElements.push(temp);
                break;
                //case
                case "2":
                //set to
                temp = stack.pop();
                //if == .
                if(temp == maxElements.peek())
                    //.
                    maxElements.pop();
                break;
                case "3":
                //.
                System.out.println(maxElements.peek());
            }
            //--
            N--;
        }
        //while >
        while(N-- > 0)
            System.out.println(maxElements.peek());
        
    }
    public static void main(String[] args) {
        getMaxElementFromStack();
    }
}