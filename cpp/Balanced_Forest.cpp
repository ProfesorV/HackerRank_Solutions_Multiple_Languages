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
//Physical Equivalents: node internal values, 
//edges and their connections [[1,2][1,3]], number of queries, number of nodes,
//index for each node to see value, 
int q;
map <long long, int> longLongIntMap1, longLongIntMap2;
long long ctot;
int intArrC[110000];
vector <int> intVector[110000];
long long ans;
int n;
long long longLongArrSum[1100000];
//int, int
void dfs1(int x, int f) {
    //set to
	longLongArrSum[x] = intArrC[x];
    //for <
	for (int i = 0; i < (int) intVector[x].size(); i++)
    //if !=
		if (intVector[x][i] != f) {
            //function
			dfs1(intVector[x][i], x);
            //+=
			longLongArrSum[x] += longLongArrSum[intVector[x][i]];
		}
    //+=
	longLongIntMap1[longLongArrSum[x]] += 1;
}
//long long
void test(long long x) {
    //set to
	long long y = ctot - 2 * x;
    //if > && <=
	if (y > 0 && y <= x)
        //set to
		ans = min(ans, x - y);
}
//int, int
void dfs2(int x, int f) {
    //if
	if (longLongIntMap2[2 * longLongArrSum[x]])
        //function
		test(longLongArrSum[x]);
    //if
	if (longLongIntMap2[ctot - longLongArrSum[x]])
        //apply
		test(longLongArrSum[x]);
    //if == &&
	if ((ctot - longLongArrSum[x]) % 2 == 0 && longLongIntMap2[ctot - (ctot - longLongArrSum[x]) / 2])
        //function
		test((ctot - longLongArrSum[x]) / 2);
    //+=
	longLongIntMap2[longLongArrSum[x]] += 1;
    //if >
	if (longLongIntMap1[longLongArrSum[x]] > longLongIntMap2[longLongArrSum[x]])
        //function
		test(longLongArrSum[x]);
    //if >= && >
	if (ctot - 2 * longLongArrSum[x] >= longLongArrSum[x] && longLongIntMap1[ctot - 2 * longLongArrSum[x]] > longLongIntMap2[ctot - 2 * longLongArrSum[x]])
        //function
		test(longLongArrSum[x]);
    //if == && >= && >
	if ((ctot - longLongArrSum[x]) % 2 == 0 && (ctot - longLongArrSum[x]) / 2 >= longLongArrSum[x] && longLongIntMap1[(ctot - longLongArrSum[x]) / 2] > longLongIntMap2[(ctot - longLongArrSum[x]) / 2])
		test((ctot - longLongArrSum[x]) / 2);
    //if ==
	if (longLongArrSum[x] * 2 == ctot)
        //set to
		ans = min(ans, longLongArrSum[x]);
    //for <
	for (int i = 0; i < (int) intVector[x].size(); i++)
        //if !=
		if (intVector[x][i] != f) {
            //function
			dfs2(intVector[x][i], x);
		}
    //-=
	longLongIntMap2[longLongArrSum[x]] -= 1;
}
int main() {
	scanf("%d", &q);
	while (q--) {
		longLongIntMap1.clear();
		longLongIntMap2.clear();
		ans = 1e18;
		scanf("%d", &n);
		ctot = 0;
		for (int i = 1; i <= n; i++) {
			scanf("%d", &c[i]);
			ctot += c[i];
		}
		for (int i = 1; i <= n; i++)
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