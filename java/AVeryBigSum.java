import java.util.Scanner;

public class BigSum {
    public static void main(String[] args) {
        // = new
        Scanner scanner = new Scanner(System.in);
        //= .nextInt()
        int N = scanner.nextInt();
        //=
        long sum = 0;
        //while -- >
        while (N-- > 0 ) {
            //+= .nextInt()
            sum += scanner.nextInt();
        }
        System.out.println(sum);
    }
}