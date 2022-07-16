import java.util.*;
import java.lang.*;
import java.io.*;
import java.math.*;

public class Main {
    
    public static int intArrMonths[];
    
    public static void main (String[] args) throws java.lang.Exception {
        Scanner in  = new Scanner(System.in);
        //set to create new
        intArrMonths = new int[15];
        //set to
        String s = in.nextLine();
        //set to create new
        StringTokenizer str = new StringTokenizer(s, "- ");
        //set to
        int firstDay = Integer.parseInt(str.nextToken());
        int firstMonth = Integer.parseInt(str.nextToken());
        int firstYear = Integer.parseInt(str.nextToken());
        int secondDay = Integer.parseInt(str.nextToken());
        int secondMonth = Integer.parseInt(str.nextToken());
        int secondYear = Integer.parseInt(str.nextToken());
      
        int result = findPrimeDates(firstDay, firstMonth, firstYear, 
        secondDay, secondMonth, secondYear);
        System.out.println(result);
   }

    public static void updateLeapYear(int year) {
        if(year % 400 == 0) {
            intArrMonths[2] = 29;
        } else if(year % 100 == 0) {
            intArrMonths[2] = 28;
        } else if(year % 4 == 0) {
            intArrMonths[2] = 29;
        } else {
            intArrMonths[2] = 28;
        }
    }
    
    public static void storeintArrMonths() {
        intArrMonths[1] = 31;
        intArrMonths[2] = 28;
        intArrMonths[3] = 31;
        intArrMonths[4] = 30;
        intArrMonths[5] = 31;
        intArrMonths[6] = 30;
        intArrMonths[7] = 31;
        intArrMonths[8] = 31;
        intArrMonths[9] = 30;
        intArrMonths[10] = 31;
        intArrMonths[11] = 30;
        intArrMonths[12] = 31;
    }
   
   public static int findPrimeDates(int firstDay, int firstMonth, int firstYear, 
   int secondDay, int secondMonth, int secondYear) {
        storeintArrMonths();
        //set to
        int result = 0;
    
        while(true) {
            //set to
            int x = firstDay;
            x = x * 100 + firstMonth;
            x = x * 10000 + firstYear;
            //if == || ==
            if(x % 4 == 0 || x % 7 == 0) {
                //set to
                result = result + 1;
            }
            if(firstDay == secondDay && firstMonth == secondMonth 
            && firstYear == secondYear) {
                break;
            }
            updateLeapYear(firstYear);
            firstDay = firstDay + 1;
            if(firstDay > intArrMonths[firstMonth]) {
                firstMonth = firstMonth + 1;
                firstDay = 1;
                if(firstMonth > 12) {
                    firstYear =  firstYear + 1;
                    firstMonth = 1;
                }
            }
        }
        return result;
    }
}