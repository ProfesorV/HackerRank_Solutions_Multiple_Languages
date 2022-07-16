import java.util.Scanner;

public class BigSum {
    public static void main(String[] args) {
        //set to create new
        Scanner scanner = new Scanner(System.in);
        //set to .
        int N = scanner.nextInt();
        //set to
        long sum = 0;
        //while
        while (N-- > 0 ) {
            //augment by
            sum += scanner.nextInt();
        }
        System.out.println(sum);
    }
}