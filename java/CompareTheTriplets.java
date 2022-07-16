import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        //set to create new
    	Scanner scan = new Scanner(System.in);
    	int[] intArrAlice = new int[3];
    	int[] intArrBob = new int[3];
        //set to
    	int a=0, b=0;
        //for <
    	for(int i=0;i<3;i++)
            //set to
    		intArrAlice[i]=scan.nextInt();
        //for <
    	for(int i=0;i<3;i++)
            //set to
    		intArrBob[i]=scan.nextInt();
        //for <
    	for(int i=0;i<3;i++)
            //if >
    		if(intArrAlice[i]>intArrBob[i])
                //++
    			a++;
            //else if <
    		else if(intArrAlice[i]<intArrBob[i])
                //++
    			b++;
    	System.out.println(a+" "+b);
    	scan.close();
    }
}