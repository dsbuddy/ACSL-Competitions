import java.util.ArrayList;
import java.util.Scanner;
	
public class Main {

	public static String[] board = new String[36];
	public static String[] board2 = new String[16];
	public static String[][] grid = new String[4][4];
	
	public static void main(String[] args) {
		
		boolean again = true;
		while (again) {
			for (int i = 0; i < board.length; i++) {
				board[i] = "0";
			}
		 
			System.out.println("Please enter your line below and click enter:");
			Scanner scan = new Scanner(System.in);
			String line = scan.nextLine();
	//		String line = "9, 17, 22, 26, 4, A, 7, C, 18, C, 19, C, 32, 14";
	//		String line = "26, 27, 28, 11, 4, A, 33, C, 32, C, 34, C, 25, 14";
	//		String line = "11, 16, 20, 27, 4, A, 7, B, 19, A, 24, B, 30, 22";
	//		String line = "9, 14, 23, 28, 3, B, 7, A, 19, A, 30, 10";
	//		String line = "8, 15, 23, 28, 4, A, 7, C, 24, C, 33, A, 30, 20";
//			String line = "9, 16, 23, 26, 4, A, 7, B, 19, B, 25, B, 18, 15";
			
			line = line.replace(" ", "");
			String[] input = line.split(",");
			 
			// Places Xs
			for (int i = 0; i < 4; i++) {
				board[Integer.parseInt(input[i]) - 1] = "X";
			}
			 
			// Places found letters
			for (int i = 6; i < input.length - 1; i+=2) {
				board[Integer.parseInt(input[i]) - 1] = input[i-1];
			}
			
			finishBoard();
			newBoard();
			checkBoard();
			checkTime();
			convertBack();
			checkBoard();
			convertIt();
			checkTime();
			convertBack();
			checkBoard();
			convertIt();
			checkTime();
			convertBack();
			checkBoard();
			convertIt();
			checkTime();
			convertBack();
			checkBoard();
			convertIt();
			checkTime();
			convertBack();
			checkBoard();
			convertIt();
			finalConvert();
			System.out.println("OUTPUT: " + answer(Integer.parseInt(input[input.length-1])));
			System.out.println("GRID #3: ");
			drawConvertIt();
			System.out.println();
			System.out.println();
			System.out.println();
			
		}
		again = false;
		
		
			
	}
	
	public static String answer(int num) {
		return board[num];
	}
	
	public static void finalConvert() {
		board[8] = grid[0][0];
		board[9] = grid[0][1];
		board[10] = grid[0][2];
		board[11] = grid[0][3];
		board[14] = grid[1][0];
		board[15] = grid[1][1];
		board[16] = grid[1][2];
		board[17] = grid[1][3];
		board[20] = grid[2][0];
		board[21] = grid[2][1];
		board[22] = grid[2][2];
		board[23] = grid[2][3];
		board[26] = grid[3][0];
		board[27] = grid[3][1];
		board[28] = grid[3][2];
		board[29] = grid[3][3];
	}
	
	public static void checkTime() {
		String temp = "";
		for (int i = 0; i < board2.length; i++) {
			checkBoard();
		}
		convertIt();
//		System.out.println();
//		drawConvertIt();
		
		for (int i = 1; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				if (grid[i][j].equals("0")) {
					temp = change(i, j);
					if (temp.length() == 1) grid[i][j] = temp;
				}
			}
		}
	}
	
	public static void convertBack() {
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				board2[(i * 4) + j] = grid[i][j];
			}
		}
	}
	
	public static String change(int rowNum, int colNum) {
		String temp = "ABCX";
		for (int i = 0; i < 4; i++) {
			temp = temp.replace(grid[rowNum][i], "");
			temp = temp.replace(grid[i][colNum], "");
		}
		return temp;
	}
	
	public static void convertIt() {
		int temp = 0;
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				if (board2[(i * 4) + j].length() > 1) {
//					if (j == 3) {
//						grid[i][j-1] = board2[(i * 4) + j].substring(0, 1);
//						grid[i][j] = board2[(i * 4) + j].substring(1);
//					} else if (j < 4) {
//						temp = j;
//						System.out.println();
//						System.out.println("String: " + board2[(i * 4) + j]);
//						grid[i][3] = String.valueOf("yo man");
//						grid[i][2] = grid[i][3];
////						grid[i][j] = board2[(i * 4) + j].substring(0, 1);
////						grid[i][j+1] = board2[(i * 4) + j].substring(1);
//					}
				} else {
					grid[i][j] = board2[(i * 4) + j];
				}
			}
		}
	}
	
	public static void drawConvertIt() {
//		for (int i = 0; i < 4; i++) {
//			System.out.println();
//			for (int j = 0; j < 4; j++) {
//				System.out.println("Loc: " + i + ", " + j + " = " + grid[i][j] + " ");
//			}
//		}
	
		
		
		for (int i = 0; i < 4; i++) {
			System.out.println();
			for (int j = 0; j < 4; j++) {
				System.out.print(grid[i][j] + " ");
			}
		}
	}
	
	private static int checkZero(int var) {
		int c = 0;
		for (int i = 0; i < board2.length; i++) {
			if (var == 1) {								// column 1
				if (i % 4 == 0 && board2[i] != "0") {
					c++;
				}
			} else if (var == 2) {						// column 2
				if (i % 4 == 1 && board2[i] != "0") {
					c++;
				}
			} else if (var == 3) {						// column 3
				if (i % 4 == 2 && board2[i] != "0") {
					c++;
				}
			} else if (var == 4) {						// column 4
				if (i % 4 == 3 && board2[i] != "0") {
					c++;
				}
			} else if (var == 5) {						// row 1
				if (i >= 0 && i < 4 && board2[i] != "0") {
					c++;
				}
			} else if (var == 6) {						// row 2
				if (i >= 4 && i < 8 && board2[i] != "0") {
					c++;
				}
			} else if (var == 7) {						// row 3
				if (i >= 8 && i < 12 && board2[i] != "0") {
					c++;
				}
			} else if (var == 8) {						// row 4
				if (i >= 12 && i < 16 && board2[i] != "0") {
					c++;
				}
			}
		}
		return c;
	}

	private static void checkBoard() {
		int r1 = 0, r2 = 0, r3 = 0, r4 = 0, c1 = 0, c2 = 0, c3 = 0, c4 = 0;
		for (int i = 0; i < board2.length; i++) {
			if (i % 4 == 0) {
				String temp = "ABCX";
				if (board2[i] != "0") {
					c1++;
					if (c1 == 3) {
						for (int j = 0; j < 4; j++) {
							temp = temp.replace(board2[j * 4], "");
						}
						for (int j = 0; j < 4; j++) {
							if (board2[j * 4] == "0") board2[j * 4] = temp;
						}
					}
				}
			}
			if (i % 4 == 1) {
				String temp = "ABCX";
				if (board2[i] != "0") {
					c2++;
					if (c2 == 3) {
						for (int j = 0; j < 4; j++) {
							temp = temp.replace(board2[(j * 4) + 1], "");
						}
						for (int j = 0; j < 4; j++) {
							if (board2[(j * 4) + 1] == "0") board2[(j * 4) + 1] = temp;
						}
					}
				}
			}
			if (i % 4 == 2) {
				String temp = "ABCX";
				if (board2[i] != "0") {
					c3++;
					if (c3 == 3) {
						for (int j = 0; j < 4; j++) {
							temp = temp.replace(board2[(j * 4) + 2], "");
						}
						for (int j = 0; j < 4; j++) {
							if (board2[(j * 4) + 2] == "0") board2[(j * 4) + 2] = temp;
						}
					}
				}
			}
			if (i % 4 == 3) {
				String temp = "ABCX";
				if (board2[i] != "0") {
					c4++;
					if (c4 == 3) {
						for (int j = 0; j < 4; j++) {
							temp = temp.replace(board2[(j * 4) + 3], "");
						}
						for (int j = 0; j < 4; j++) {
							if (board2[(j * 4) + 3] == "0") board2[(j * 4) + 3] = temp;
						}
					}
				}
			}
			if (i >= 0 && i < 4) {
				String temp = "ABCX";
				if (board2[i] != "0") {
					r1++;
					if (r1 == 3) {
						for (int j = 0; j < 4; j++) {
							temp = temp.replace(board2[j], "");
						}
						for (int j = 0; j < 4; j++) {
							if (board2[j] == "0") board2[j] = temp;
						}
					}
				}
			}
			if (i >= 4 && i < 8) {
				String temp = "ABCX";
				if (board2[i] != "0") {
					r2++;
					if (r2 == 3) {
						for (int j = 4; j < 8; j++) {
							temp = temp.replace(board2[j], "");
						}
						for (int j = 4; j < 8; j++) {
							if (board2[j] == "0") board2[j] = temp;
						}
					}
				}
			}
			if (i >= 8 && i < 12) {
				String temp = "ABCX";
				if (board2[i] != "0") {
					r3++;
					if (r3 == 3) {
						for (int j = 8; j < 12; j++) {
							temp = temp.replace(board2[j], "");
						}
						for (int j = 8; j < 12; j++) {
							if (board2[j] == "0") board2[j] = temp;
						}
					}
				}
			}
			if (i >= 12 && i < 16) {
				String temp = "ABCX";
				if (board2[i] != "0") {
					r4++;
					if (r4 == 3) {
						for (int j = 12; j < 16; j++) {
							temp = temp.replace(board2[j], "");
						}
						for (int j = 12; j < 16; j++) {
							if (board2[j] == "0") board2[j] = temp;
						}
					}
				}
			}
		}
	}

	private static void newBoard() {
		for (int i = 0; i < board2.length; i++) {
			if (i >= 0 && i < 4) board2[i] = board[i+7];
			if (i >= 4 && i < 8) board2[i] = board[i+9];
			if (i >= 8 && i < 12) board2[i] = board[i+11];
			if (i >= 12 && i < 16) board2[i] = board[i+13];
		}
	}
	
	public static void drawBoard2() {
		for (int i = 0; i < board2.length; i++) {
			if (i % 4 == 0 && i != 0) {
				System.out.println("");
			}
			System.out.print(board2[i] + " ");
		}
	}

	public static void drawBoard() {
		System.out.println("");
		for (int i = 0; i < board.length; i++) {
			if (i % 6 == 0 && i != 0) {
				System.out.println("");
			}
			System.out.print(board[i] + " ");
		}
	}
		 
	public static void finishBoard() {
		for (int i = 0; i < board.length; i++) {
			
			if (i % 6 == 0 && board[i] != "0" && board[i] != "X") {
				for (int j = 1; j <	5; j++) {
					if (board[i+j] != "X") {
						board[i+j] = board[i];
						j=6;
					}	
				}
			}
			
			if (i % 6 == 5 && board[i] != "0" && board[i] != "X") {
				for (int k = 1; k <	5; k++) {
					if (board[i-k] != "X") {
						board[i-k] = board[i];
						k=6;
					}
				}
			}
			
			if (i - 6 < 0 && board[i] != "0" && board[i] != "X") {
				for (int l = 6; l <= 30; l+=6) {
					if (board[i+l] != "X") {
						board[i+l] = board[i];
						l=40;
					}
				}
			}
			
			if (i - 6 > 23 && board[i] != "0" && board[i] != "X") {
				for (int m = 6; m <= 30; m+=6) {
					if (board[i-m] != "X") {
						board[i-m] = board[i];
						m=40;
					}
				}
			}
		}
	}
	
}