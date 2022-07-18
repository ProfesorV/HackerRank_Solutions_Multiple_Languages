import java.util.Scanner;
public class Solution {
    public static void main(String[] args) {
        final int TROPICALSEASON = 100, SUMMERSEASON = 200;
        Scanner input = new Scanner(System.in);
        int potentialCases = Integer.parseInt(input.nextLine());
        for (int i = 0; i < potentialCases; i++) {
            int treeHeight = 1;
            int cycleOf = TROPICALSEASON;
            int numberOfCycles = Integer.parseInt(input.nextLine());
            for (int j = 0; j < numberOfCycles; j++) {
                switch (cycleOf) {
                case TROPICALSEASON:
                    treeHeight = treeHeight * 2;
                    cycleOf = SUMMERSEASON;
                    break;
                case SUMMERSEASON:
                    treeHeight += 1;
                    cycleOf = TROPICALSEASON;
                    break;
                }
            }
            System.out.println(treeHeight);
        }
    }
}