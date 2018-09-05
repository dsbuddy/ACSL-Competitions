package acsl_dSchwartz;

import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
	
		Scanner reader = new Scanner(System.in); 
		 
		System.out.println("Type and click enter 'norm' for the normal or 'rand' for random:");
		 
		String choice = reader.nextLine();
		
		if (choice.equals("rand")) {
			int c = 1;
			while (c < 6) {
				Random rand = new Random();
				String word = getTextFile();
				int rVal = rand.nextInt(word.length());
				char chr = word.charAt(rand.nextInt(word.length()));
				String b = Character.toString((char) (rand.nextInt(94) + 33));
				
				if (c == 1) {
					System.out.println(word + ", " + (rVal % 2 + 1) + ", " + b);
					System.out.println(char_split(word, (rVal % 2 + 1), b.charAt(0)));
					c++;
					System.out.println("");
				} else if (c == 2) {
					System.out.println(word + ", " + word.substring(rVal));
					System.out.println(strrem(word, word.substring(rVal)));
					c++;
					System.out.println("");
				} else if (c == 3) {
					System.out.println(word + ", " + chr);
					System.out.println(strchr(word, String.valueOf(chr)));
					c++;
					System.out.println("");
				} else if (c == 4) {
					System.out.println(word + ", " + chr);
					System.out.println(strtok(word, String.valueOf(chr)));
					c++;
					System.out.println("");
				} else if (c == 5) {
					System.out.println(word + ", " + (rVal % 2 + 1) + ", " + chr);
					System.out.println(wordwrap(word, (rVal % 2 + 1), String.valueOf(chr)));
					c++;
					System.out.println("");
				}
			}
		} else if (choice.equals("norm")) {
			int c = 1;
			while (c < 6) {
			System.out.println("Please enter the input one line at a time and then click Enter");
			String line = reader.nextLine();
			 
			String[] input = line.split(",");
			for (int i = 0; i < input.length; i++) {
			input[i] = input[i].replaceAll("\\s+","");
			}
			 
			if (c == 1) {
				System.out.println(char_split(input[0], Integer.parseInt(input[1]), input[2].charAt(0)));
			} else if (c == 2) {
				System.out.println(strrem(input[0], input[1]));
			} else if (c == 3) {
				System.out.println(strchr(input[0], input[1]));
			} else if (c == 4) {
				System.out.println(strtok(input[0], input[1]));
			} else if (c == 5) {
				System.out.println(wordwrap(input[0], Integer.parseInt(input[1]), input[2]));
			}
			c++;
			}
		} else {
			System.exit(0);
		}
	}
	 
	public static String char_split(String a, int n, char chr) {
		String res = "";
		for (int i = 0; i < a.length(); i += n) {
			if ((a.length() - i) < n) {
				res+=(a.substring(a.length()-n+1));
			} else {
				res+=(a.substring(i, i + n) + chr);
			}
		}
		return res;
	}
	 
	public static String strrem(String a, String b) {
		return (a.replaceAll(b, ""));
	}
	 
	public static String strchr(String a, String b) {
		return (a.substring(0, a.indexOf(b)));
	}
	 
	public static String strtok(String a, String b) {
		String res = "";
		for (int i = 0; i < a.length(); i++) {
		if (a.charAt(i) == b.charAt(0)) {
			res += " " + b;
		} else {
			res += String.valueOf(a.charAt(i));
		}
		}
		return res;
	}
	 
	public static String wordwrap(String a, int n, String chr) {
		String res = strtok(a, chr);
		int c = 0;
		 
		for (int i = 0; i < res.length(); i++) {
			if (c == n && res.charAt(i) != ' ') {
				res = res.substring(0, i) + " " + res.substring(i);
			}
		 
			if (res.charAt(i) == ' ') {
				c = 0;
			} else {
				c++;
			}
		}
		return res;
	}
	 
	public static String getTextFile() {
		try {
			Random rand = new Random();
			String strLine = "";
			
			FileInputStream fstream = new FileInputStream(System.getProperty("user.dir") + "\\words.txt");
			ArrayList<String> list = new ArrayList<String>();        
			DataInputStream in = new DataInputStream(fstream);
			BufferedReader br = new BufferedReader(new InputStreamReader(in));
			 
			//Reads file line by line
			while ((strLine = br.readLine()) != null)   {
				list.add(strLine);
			}
			//Closes input stream
			in.close();
			 
			return (list.get(rand.nextInt(list.size() + 1)));
		 
			//Catches Exceptions
		   } catch (Exception e) { 
		           System.err.println("Error: " + e.getMessage());
		   }
		return "";
	}
}