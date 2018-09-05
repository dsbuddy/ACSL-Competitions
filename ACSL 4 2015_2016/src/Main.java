import java.util.ArrayList;
import java.util.Scanner;

public class Main {

	public static String[] data;
//	public static String[] data = {"aac", "acc", "abc", "ac", "abbc", "abbbc", "abbbbc", "aabc", "accb"};
//	public static String[] data = {"abccdf", "abcdef", "abdg", "abjhi", "abde", "abccccccde", "abcg", "abzhi", "abcccccccde"};
	
	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		
		System.out.println("Enter line 1 below:");
		data = reader.nextLine().toLowerCase().replace(" ", "").split(",");
		
//		System.out.println();
//		for (String string : data) {
//			System.out.println(string);
//		}
//		System.out.println();
//		
//		System.out.println("Enter line 2 below:");
//		System.out.println(f1(reader.next()));
//		
//		System.out.println("Enter line 3 below:");
//		System.out.println(f2(reader.next()));
//		
//		System.out.println("Enter line 4 below:");
//		System.out.println(f3(reader.next()));
//		
//		System.out.println("Enter line 5 below:");
//		System.out.println(f4(reader.next()));
		
		System.out.println("Enter line 6 below:");
		System.out.println(f5(reader.next()));
	}
	
	private static String outputIt(ArrayList<String> listStr) {
		if (listStr.size() != 0) {
			String output = listStr.get(0);
			
			for (int j = 1; j < listStr.size(); j++) {
				output = output + ", " + listStr.get(j);
			}
			
			return output;
		}
		return "";
	}
	
	public static String f1(String string) {
		ArrayList<String> fun1 = new ArrayList<String>();
		
		for (String str : data) {
			if (str.length() == string.length()) {
				if ((str.startsWith(string.substring(0, string.indexOf("."))) == true) && (str.endsWith(string.substring(string.indexOf(".") + 1)) ==  true)) {
					fun1.add(str);
				}
			}
		}
		return outputIt(fun1);
	}

	public static String f2(String string) {
		ArrayList<String> fun2 = new ArrayList<String>();
		
		String[] code = f1(string.substring(0, string.indexOf("[")) + "." + string.substring(string.indexOf("]") + 1)).replace(" ", "").split(",");
	
		for (String possAns : code) {
			String possLet = possAns.substring(string.substring(0, string.indexOf("[")).length(), string.substring(string.indexOf("]")).length());
			if (string.substring(string.indexOf("[") + 1, string.indexOf("]")).contains(possLet)) {
				fun2.add(possAns);
			}
		}
		return outputIt(fun2);
	}
	
	public static String f3(String string) {
		ArrayList<String> fun3 = new ArrayList<String>();
		
		String[] code = f1(string.substring(0, string.indexOf("[^")) + "." + string.substring(string.indexOf("]") + 1)).replace(" ", "").split(",");
		
		for (String possAns : code) {
			String possLet = possAns.substring(string.substring(0, string.indexOf("[^")).length(), string.substring(string.indexOf("]")).length());
			if (string.substring(string.indexOf("[^") + 1, string.indexOf("]")).contains(possLet)) {
				
			} else {
				fun3.add(possAns);
			}
		}
		return outputIt(fun3);
	}
	
	public static String f4(String string) {
		ArrayList<String> fun4 = new ArrayList<String>();
		boolean isSame = false;
		
		for (String str : data) {
			if(str.equals(string.substring(0, string.indexOf("*") - 1) + (string.substring(string.indexOf("*") + 1)))) fun4.add(str);
			if ((str.startsWith(string.substring(0, string.indexOf("*"))) == true) && (str.endsWith(string.substring(string.indexOf("*") + 1)) == true)) {  // if string starts with beg and string ends with end or does not have mid
				String temp = str.substring(string.indexOf("*") - 1, str.lastIndexOf(string.substring(string.indexOf("*") + 1)));
				for (int i = 0; i < temp.length(); i++) {
					if ((temp.substring(i, i + 1).equals(string.substring(string.indexOf("*") - 1 , string.indexOf("*"))))) {  // if all chars in temp = middle of string letter
						isSame = true;
					} else {
						isSame = false;
						break;
					}
				}
				if (isSame == true) fun4.add(str);
			}
		}
		return outputIt(fun4);
	}
	
	public static String f5(String string) {
		ArrayList<String> fun5 = new ArrayList<String>();

		for (String str : data) {
		
			if ((string.substring(string.indexOf("{") + 1, string.indexOf("{") + 2).equals("0")) && ((str.equals(string.substring(0, string.indexOf("{") - 1) + (string.substring(string.indexOf("}") + 1)))))) fun5.add(str);
			if ((str.startsWith(string.substring(0, string.indexOf("{"))) == true) && (str.endsWith(string.substring(string.indexOf("}") + 1)) == true)) {  // if string starts with beg and string ends with end or does not have mid
				String temp = str.substring(string.indexOf("{") - 1, str.lastIndexOf(string.substring(string.indexOf("}") + 1)));
				for (int i = 0; i < temp.length(); i++) {
					if ((temp.substring(i, i + 1).equals(string.substring(string.indexOf("{") - 1 , string.indexOf("{")))) || (str.equals(string.substring(0, string.indexOf("{") - 1) + (string.substring(string.indexOf("}") + 1))))) {  // if all chars in temp = middle of string letter
						if ((temp.length() >= Integer.parseInt(string.substring(string.indexOf("{") + 1, string.indexOf(",")))) && (temp.length() <= Integer.parseInt(string.substring(string.indexOf(",") + 1, string.indexOf("}"))))) {
							fun5.add(str);
							break;
						}
					}
			
				}
			}
		}
		return outputIt(fun5);
	}

}
