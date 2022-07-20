import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        //set to create new
    	Scanner scan = new Scanner(System.in);
		//= new []
    	int[] intArrAlice = new int[3];
		//= new []
    	int[] intArrBob = new int[3];
        //=, =
    	int a=0, b=0;
        //for <
    	for(int i=0;i<3;i++)
            //[]= .nextInt()
    		intArrAlice[i]=scan.nextInt();
        //for <
    	for(int i=0;i<3;i++)
            //[] = .nextInt()
    		intArrBob[i]=scan.nextInt();
        //for <
    	for(int i=0;i<3;i++)
            //if []>[]
    		if(intArrAlice[i]>intArrBob[i])
                //++
    			a++;
            //else if []<[]
    		else if(intArrAlice[i]<intArrBob[i])
                //++
    			b++;
		//println(+""+)
    	System.out.println(a+" "+b);
		//.close()
    	scan.close();
    }
}