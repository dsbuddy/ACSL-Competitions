import java.util.Scanner;

public class Main {

private static boolean again = true;
	
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		
		Scanner scanner = new Scanner(System.in);
		while (again) {
			System.out.println("Please enter a string below:");
			enterString(scanner.nextLine());
		}		
	}

	public static void enterString(String string) {
		int belowScore = 0;
		int aboveScore = 0;
		String result = "";
		
		string = string.replace(" ", "");
		string = string.toUpperCase();
		String[]  input = string.split(",");
		int bid = Integer.parseInt(input[0]);
		int won = Integer.parseInt(input[1]);
		String suit = input[2];
		String vun = input[3];
		
		
		if (won < (bid + 6)) {
			belowScore += 0;
			if (vun.equals("N")) {
				aboveScore += (Math.abs(bid + 6) - won) * 50;
			} else {
				aboveScore += (Math.abs(bid + 6) - won) * 100;
			}
		} else if (won == (bid + 6)) {
			aboveScore += 0;
		} else if (won > (bid + 6)) {
			belowScore += Math.abs(suitCalc(bid, won, suit, vun, 0, belowScore, aboveScore));
			aboveScore += Math.abs(suitCalc((Math.abs(bid + 6) - won), won, suit, vun, 1, belowScore, aboveScore));
		}
		
		result = Integer.toString(belowScore) + ", " + Integer.toString(aboveScore);
		System.out.println(result);
	}

	public static int suitCalc(int bid, int won, String suit, String vun, int aboveBelow, int belowScore, int aboveScore) {
		bid = Math.abs(bid);
		if (suit.equals("T")) {
			if (aboveBelow == 0) {
				if (bid == 0) {
					return 0; 
				} else {
					return ((bid * 30) + 10);
				}
			} else {
				if (belowScore >= 40) {
					System.out.println(bid);
					if (bid == 0) {
						return 0;
					} else if (bid == 1) {
						return 30;
					} else if (bid > 1) {
						return (bid * 30);
					}
				} else {
					if (bid == 0) {
						return 0; 
					} else {
						return ((bid * 30) + 10);
					}
				}
			}
		} else if (suit.equals("H") || suit.equals("S")) {
			return bid * 30;
		} else if (suit.equals("C") || suit.equals("D")) {
			return bid * 20;
		}
		return 0;
	}
	
}