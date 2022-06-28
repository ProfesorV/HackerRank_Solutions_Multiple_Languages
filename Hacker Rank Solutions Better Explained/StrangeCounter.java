import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.StringTokenizer;

public class A {
	public static void main(String[] args) throws Exception {
		Scanner sc = new Scanner(System.in);
        //set to create new StringBuilder
		StringBuilder sb = new StringBuilder();
        //set to create new PrintWriter()
		PrintWriter out = new PrintWriter(System.out);
        //set to apply function .nextLong()
		long t = sc.nextLong();
        //set to
		long cur = 0;
		long nxt = 3;
        //while condition (long < long)
		while (cur < t) {
            //augment by 
			cur += nxt;
            //long <<=1
			nxt <<= 1;
		}
        //set to
		long val = 1;
        //set to long - long
		long dif = cur - t;
        //augment by
		val += dif;
        //apply function .print(long)
		out.print(val);
        //apply function .flush()
		out.flush();
		out.close();
	}
	static class Scanner {
        //declare
		StringTokenizer st;
		BufferedReader br;
		public Scanner(InputStream s) {
            //set to create new BufferedReader(create new InputStreamReader(InputStream))
			br = new BufferedReader(new InputStreamReader(s));
		}
		public String next() throws IOException {
            //while condition (== || !)
			while (st == null || !st.hasMoreTokens())
                //set to create new StringTokenizer(apply function .readLine)
				st = new StringTokenizer(br.readLine());
            //return
			return st.nextToken();
		}
		public int nextInt() throws IOException {
            //return apply function .parseInt(apply function next())
			return Integer.parseInt(next());
		}
		public long nextLong() throws IOException {
             //return apply function .parseLong(apply function next())
			return Long.parseLong(next());
		}
		public String nextLine() throws IOException {
             //return apply function .readLine
			return br.readLine();
		}
		public double nextDouble() throws IOException {
            //set to apply function next()
			String x = next();
            //set to create new StringBuilder("0")
			StringBuilder sb = new StringBuilder("0");
            //set to
			double res = 0, f = 1;
			boolean dec = false, neg = false;
			int start = 0;
            //if condition (apply function .charAt(0) == '')
			if (x.charAt(0) == '-') {
                //set to
				neg = true;
                //increment
				start++;
			}
            //for condition (int < String.length)
			for (int i = start; i < x.length(); i++)
                //if condition (apply function .CharAt(int)=='.')
				if (x.charAt(i) == '.') {
                    //set to apply function .parseLong(apply function toString())
					res = Long.parseLong(sb.toString());
                    //set to new StringBuilder("0")
					sb = new StringBuilder("0");
                    //set to
					dec = true;
				} else {
                    //apply function .append(apply function .charAt(int))
					sb.append(x.charAt(i));
                    //if condition(bool)
					if (dec)
                        //1 *= 10
						f *= 10;
				}
            //augment by apply function .parseLong(apply function .toString())/int
			res += Long.parseLong(sb.toString()) / f;
            //return
			return res * (neg ? -1 : 1);
		}
		public boolean ready() throws IOException {
			return br.ready();
		}
	}
}