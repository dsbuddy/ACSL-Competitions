package acsl1_danielSchwartz;

import java.util.Arrays;
import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		
		boolean again = true;
		while (again) {
			Scanner reader = new Scanner(System.in); 

			System.out.println("Please enter the input one line at a time and then click Enter");
			String line = reader.nextLine();
			
			String[] input = line.split(",");
			for (int i = 0; i < input.length; i++) {
				input[i] = input[i].replaceAll("\\s+","");
			}
			
			check(input);
			
		}
		again = false;
				
	}
	
	public static void check(String[] input) {		
		if (input[0].length() == 1) { 															 //octal input
			String octBin = "", octPerm = "", octPrint = "";
			
			octBin = toBin(input);
			octPerm = toPerm(toBin(input));
			octPrint = octBin + " and " + octPerm;
			System.out.println(octPrint);
		} else if (input[0].charAt(0) == "1".charAt(0) || input[0].charAt(0) == "0".charAt(0)) { //binary input
			String binOct = "", binPerm = "", binPrint = "", tempBin = "";
			
			tempBin = input[0] + " " + input[1] + " " + input[2];
			
			binOct = toOct(input);
			binPerm = toPerm(tempBin);
			binPrint = binOct + " and " + binPerm;
			System.out.println(binPrint);
		} else if (input[0].charAt(0) == "r".charAt(0) || input[0].charAt(0) == "-".charAt(0)) { //permission input
			String permBin = "", permOct = "", permPrint = "", tempPerm = "";

			tempPerm = input[0] + " " + input[1] + " " + input[2];
			
			
			permBin = permToBin(tempPerm);
			
			String[] tempPermBin = {permBin.substring(0, 3), permBin.substring(4, 7), permBin.substring(8, 11)};
			
			permOct = toOct(tempPermBin);
			permPrint = permOct + " and " + permBin;
			System.out.println(permPrint);

		}
			
		
	}
	
	public static String toBin(String[] input) {
		String resultConv = "";
		
		for (int i = 0; i < 3; i++) {
			resultConv += String.format("%3s", (Integer.toBinaryString(Integer.parseInt(input[i])))).replace(' ', '0') + " ";
		}
		
		return resultConv;	
	}
	
	public static String toOct(String[] input) {
		String resultConv = "";
		
		for (int i = 0; i < 3; i++) {
			resultConv += Integer.toOctalString(Integer.parseInt(input[i], 2));
		}
		
		return resultConv;
	}

	public static String toPerm(String bin) {
		char[] template = {'r', 'w', 'x', ' ', 'r', 'w', 'x', ' ', 'r', 'w', 'x', ' '};
			
		for (int i = 0; i < bin.length(); i++) {
			if (bin.charAt(i) == '0') template[i] = '-';
		}
		
		String result = new String(template);
		
		return result;
	}
	
	public static String permToBin(String perm) {
		char[] binTemplate = {'1', '1', '1', ' ', '1', '1', '1', ' ', '1', '1', '1', ' '};
		
		for (int i = 0; i < perm.length(); i++) {
			if (perm.charAt(i) == '-') binTemplate[i] = '0';
		}
		
		String binResult = new String(binTemplate);
		
		return binResult;
	}

}
