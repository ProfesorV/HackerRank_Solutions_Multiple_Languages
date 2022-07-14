import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

import static java.lang.System.out;

class WeightCount {
    //declare
    private int weight;
    private long count;
    //Constructor
    public WeightCount(int weight, long count) {
    this.weight = weight;
    this.count = count;
    }

    public int getWeight() {
    //return
    return weight;
    }
    public long getCount() {
    //return
    return count;
    }
    
    public void setWeight(int weight) {
    //set to
    this.weight = weight;
    }
    public void setCount(long count) {
    //set to
    this.count = count;
    }
    //WeightCount[],int, int
    public static int lower(WeightCount[] array, int size, int key) {
    //if == || <
    if (array == null || size < 0)
        //return
        return -1;
    //if ==
    if (size == 0)
        //return
        return 0;
    //set to
    int l = 0;
    int r = size - 1;
    //declare
    int mid, weight;    
    //while >
    while ((r - l) > 1) {
        //set to + >>
        mid = l + ((r - l) >> 1);
        //set to .
        weight = array[mid].getWeight();
        //if >
        if (weight > key)
        //set to
        r = mid - 1;
        //else if
        else if (weight < key)
        //set to
        l = mid;
        //else
        else
        //set to
        r = mid;         
    }
    //if . >
    if (array[l].getWeight() > key)
        //return
        return l - 1;
    //if == . || . >
    if (key == array[l].getWeight() ||
        array[r].getWeight() > key)
        //return
        return l;
    //return
    return r;
    }
}

class Edge implements Comparable<Edge> {
    //declare
    private int u;
    private int v;
    private int w;
    //int, int, int
    public Edge(int u, int v, int w) {
    //set to
    this.u = u;
    this.v = v;
    this.w = w;
    }
    public int getU() {
    //return
    return u;    
    }
    public int getV() {
    //return
    return v;    
    }
    public int getW() {
    //return
    return w;    
    }
    //int
    public void setU(int u) {
    //set to
    this.u = u;
    }
    //int
    public void setV(int v) {
    //set to
    this.v = v;
    }
    //int
    public void setW(int w) {
    //set to
    this.w = w;
    }
    //Edge
    public int compareTo(Edge e) {
    //if !=
    if (e != null) {
        //set to .
        int tmp = e.getW();
        //if <
        if (w < tmp)
        //return
        return -1;
        //if >
        if (w > tmp)
        //return
        return 1;        
    }
    //return
    return 0;
    }
}

class DisjointSet {
    //set to
    private static final int DEFAULT_SIZE = 31;
    //declare
    private int[] idx;
    private int[] size;
    private int n;
    private int components;
    //int
    public DisjointSet(int n) {
    //if <
    if (n < 1)
        //set to
        n = DEFAULT_SIZE;
    //set to create new
    idx = new int[n + 1];
    size = new int[n + 1];
    //set to
    this.n = n;
    components = n;
    //for >
    for (int i = n; i > 0; i--) {
        //set to
        idx[i] = i;
        size[i] = 1;
    }
    }

    public DisjointSet() {
    this(DEFAULT_SIZE);
    }
    //int
    private int root(int i) {
    //if < || >
    if (i < 1 || i > n)
        //return
        return 0;
    //set to
    int p = i;
    //while !=
    while (idx[p] != p)
        //set to
        p = idx[p];
    //declare
    int tmp;
    //while !=
    while (idx[i] != p) {
        //set to
        tmp = idx[i];
        //set to
        idx[i] = p;
        //set to
        i = tmp;
    }
    //return
    return p;
    }
    //int, int
    public long join(int p, int q) {
    //set to
    int rootP = root(p);
    int rootQ = root(q);
    //if !=
    if (rootP != rootQ) {
        //set to *
        long result = (long) size[rootP] * size[rootQ];
        //if <
        if (size[rootP] < size[rootQ]) {
        //set to
        idx[rootP] = rootQ;
        //+=
        size[rootQ] += size[rootP];
        //else
        } else {
        //set to
        idx[rootQ] = rootP;
        //+=
        size[rootP] += size[rootQ];
        }
        //--
        components--;
        //return
        return result;
    }
    return 0;
    }
    //int, int
    public boolean isConnected(int p, int q) {
    //set to
    return (root(p) == root(q));
    }
}

public class MaximumCostQueries {
    //set to
    private static final int MAX_N = 100000;
    private static final int MAX_Q = 100000;

    public static void main(String[] args) {
    Scanner sc = new Scanner(System.in);
    //set to
    int n = sc.nextInt();
    int q = sc.nextInt();
    //if < || > || < || >
    if (n < 1 || n > MAX_N ||
        q < 1 || q > MAX_Q)
        //return
        return;
    //set to create new
    Edge[] edges = new Edge[n - 1];
    //declare
    int i, u, v, w;  
    //for = >=  
    for (i = n - 2; i >= 0; i--) {
        //set to .
        u = sc.nextInt();
        v = sc.nextInt();
        w = sc.nextInt();
        //set to create new
        edges[i] = new Edge(u, v, w);
    }
    //.
    Arrays.sort(edges);
    //set to create new
    DisjointSet ds = new DisjointSet(n);
    WeightCount[] wc = new WeightCount[n];
    //declare
    int j, k, limit;
    long result;
    //set to
    limit = edges.length;
    //for <
    for (k = i = 0; i < limit; i = j) {
        //set to
        result = 0;
        //set to
        w = edges[i].getW();
        j = i;

        do {
        //+= .
        result += ds.join(edges[j].getU(), edges[j].getV());
        //++
        j++;
        //while < && . ==
        } while (j < limit && edges[j].getW() == w);
        //set to
        wc[k++] = new WeightCount(w, result);
    }
    //for <
    for (i = 1; i < k; i++)
        //., . + .
        wc[i].setCount(wc[i - 1].getCount() + wc[i].getCount());
    //while >
    while (q-- > 0) {
        //set to
        i = sc.nextInt();
        j = sc.nextInt();
        u = WeightCount.lower(wc, k, i - 1);
        v = WeightCount.lower(wc, k, j);
        //set to . - < ? : .
        result = wc[v].getCount() - ((u < 0) ? 0 : wc[u].getCount());
        out.println(result);
    }
    sc.close();
    }
}