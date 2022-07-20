#include <cstdio>
#include <iostream>
#include <cstring>
#include <algorithm>
#include <cmath>
#include <vector>
#include <map>
#include <set>
#include <string>
#include <cstdlib>
#include <ctime>
#include <deque>
#include <unordered_set>
using namespace std;
//declare
int q;
//<,>
map <long long, int> longLongIntMap1, longLongIntMap2;
long long ctot;
//[]
int intArrC[110000];
//< > []
vector <int> intVector[110000];
long long ans;
int n;
//[]
long long longLongArrSum[1100000];
//int, int
void dfs1(int x, int f) {
    //[] = []
	longLongArrSum[x] = intArrC[x];
    //for < (int) [].size()
	for (int i = 0; i < (int) intVector[x].size(); i++)
    //if [][]!=
		if (intVector[x][i] != f) {
            //dfs1([][],)
			dfs1(intVector[x][i], x);
            //[] += [[][]]
			longLongArrSum[x] += longLongArrSum[intVector[x][i]];
		}
    //[[]]+=
	longLongIntMap1[longLongArrSum[x]] += 1;
}
//long long
void test(long long x) {
    //==
	long long y = ctot - 2 * x;
    //if > && <=
	if (y > 0 && y <= x)
        //= min()
		ans = min(ans, x - y);
}
//int, int
void dfs2(int x, int f) {
    //if [2*[]]
	if (longLongIntMap2[2 * longLongArrSum[x]])
        //test([])
		test(longLongArrSum[x]);
    //if [-[]]
	if (longLongIntMap2[ctot - longLongArrSum[x]])
        //test([])
		test(longLongArrSum[x]);
    //if (-[])% == && [-(-[])/2]
	if ((ctot - longLongArrSum[x]) % 2 == 0 && longLongIntMap2[ctot - (ctot - longLongArrSum[x]) / 2])
        //test(-[]/)
		test((ctot - longLongArrSum[x]) / 2);
    //[[]] += 1
	longLongIntMap2[longLongArrSum[x]] += 1;
    //if [[]] > [[]]
	if (longLongIntMap1[longLongArrSum[x]] > longLongIntMap2[longLongArrSum[x]])
        ////test([])
		test(longLongArrSum[x]);
    //if - * [] >= [] && [- * []] > [- * []]
	if (ctot - 2 * longLongArrSum[x] >= longLongArrSum[x] && longLongIntMap1[ctot - 2 * longLongArrSum[x]] > longLongIntMap2[ctot - 2 * longLongArrSum[x]])
        //test([])
		test(longLongArrSum[x]);
    //if - [] % == && (-[])/2 >[] && [(-[])/2] > [-[]/2])
	if ((ctot - longLongArrSum[x]) % 2 == 0 && (ctot - longLongArrSum[x]) / 2 >= longLongArrSum[x] && longLongIntMap1[(ctot - longLongArrSum[x]) / 2] > longLongIntMap2[(ctot - longLongArrSum[x]) / 2])
		//test([])
		test((ctot - longLongArrSum[x]) / 2);
    //if [] * 2 ==
	if (longLongArrSum[x] * 2 == ctot)
        //= min(,[])
		ans = min(ans, longLongArrSum[x]);
    //for < (int)[].size()
	for (int i = 0; i < (int) intVector[x].size(); i++)
        //if [][] != 
		if (intVector[x][i] != f) {
            //dfs2([][],)
			dfs2(intVector[x][i], x);
		}
    //[[]]-= 1
	longLongIntMap2[longLongArrSum[x]] -= 1;
}
int main() {
	scanf("%d", &q);
	//--
	while (q--) {
		//.clear()
		longLongIntMap1.clear();
		longLongIntMap2.clear();
		ans = 1e18;
		scanf("%d", &n);
		ctot = 0;
		for (int i = 1; i <= n; i++) {
			//&[]
			scanf("%d", &c[i]);
			//+=[]
			ctot += c[i];
		}
		for (int i = 1; i <= n; i++)
		//[].clear()
			intVector[i].clear();
		for (int i = 1; i < n; i++) {
			int x, y;
			scanf("%d%d", &x, &y);
			intVector[x].push_back(y);
			intVector[y].push_back(x);
		}
		dfs1(1, 0);
		dfs2(1, 0);
		if (ans == 1e18)
			printf("-1\n");
		else
			printf("%lld\n", ans);
	}
}