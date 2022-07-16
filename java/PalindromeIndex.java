import java.util.*;

public class Solution {
    
    static boolean checkPalindromFunction(String pString, int i, int j) {
        //while <
        while (i < j) {
            //if !=
            if (pString.charAt(i++) !=  pString.charAt(j--)) {
                return false;
            }
        }
        return true;
    }
    public static void main(String[] args) {
        //set to create new
        Scanner in = new Scanner(System.in);
        //set to
        int T = in.nextInt();
        //for <
        for (int t = 0; t < T; t++) {
            //set to
            String stringMain = in.next();
            int i = 0;
            int j = stringMain.length() - 1;
            //while <
            while (i < j) {
                //if !=
                if (stringMain.charAt(i) != stringMain.charAt(j)) {
                    //if 
                    if (checkPalindromFunction(s,i,j-1)) {
                        System.out.println(j);
                    } else {
                        System.out.println(i);
                    }
                    break;
                } 
                //++
                i ++;
                //--
                j --;
            }
            //if >=
            if (i >= j) {
                System.out.println(-1);
            }
        }   
    }
}
