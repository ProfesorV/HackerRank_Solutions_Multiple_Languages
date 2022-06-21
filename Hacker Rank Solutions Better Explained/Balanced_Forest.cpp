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

int q;
map <long long, int> Map1, Map2;
long long ctot;
int c[110000];
vector <int> ve[110000];
long long ans;
int n;
long long sum[1100000];
//int, int
void dfs1(int x, int f) {
    //set to
	sum[x] = c[x];
    //for condition
	for (int i = 0; i < (int) ve[x].size(); i++)
    //if condition
		if (ve[x][i] != f) {
            //apply function
			dfs1(ve[x][i], x);
            //augment by
			sum[x] += sum[ve[x][i]];
		}
    //augment by
	Map1[sum[x]] += 1;
}
//long long
void test(long long x) {
    //set to calculate
	long long y = ctot - 2 * x;
    //if condition
	if (y > 0 && y <= x)
        //set to apply function
		ans = min(ans, x - y);
}
//int, int
void dfs2(int x, int f) {
    //if condition
	if (Map2[2 * sum[x]])
        //apply function
		test(sum[x]);
    //if condition
	if (Map2[ctot - sum[x]])
        //apply function
		test(sum[x]);
    //if condition &&
	if ((ctot - sum[x]) % 2 == 0 && Map2[ctot - (ctot - sum[x]) / 2])
        //apply function
		test((ctot - sum[x]) / 2);
    //augment by
	Map2[sum[x]] += 1;
    //if condition
	if (Map1[sum[x]] > Map2[sum[x]])
        //apply function
		test(sum[x]);
    //if condition &&
	if (ctot - 2 * sum[x] >= sum[x] && Map1[ctot - 2 * sum[x]] > Map2[ctot - 2 * sum[x]])
        //apply function
		test(sum[x]);
    //if condition &&
	if ((ctot - sum[x]) % 2 == 0 && (ctot - sum[x]) / 2 >= sum[x] && Map1[(ctot - sum[x]) / 2] > Map2[(ctot - sum[x]) / 2])
		test((ctot - sum[x]) / 2);
    //if condition ==
	if (sum[x] * 2 == ctot)
        //set to
		ans = min(ans, sum[x]);
    //for condition
	for (int i = 0; i < (int) ve[x].size(); i++)
        //if condition
		if (ve[x][i] != f) {
            //apply function
			dfs2(ve[x][i], x);
		}
    //subtract by
	Map2[sum[x]] -= 1;
}
int main() {
	scanf("%d", &q);
	while (q--) {
		Map1.clear();
		Map2.clear();
		ans = 1e18;
		scanf("%d", &n);
		ctot = 0;
		for (int i = 1; i <= n; i++) {
			scanf("%d", &c[i]);
			ctot += c[i];
		}
		for (int i = 1; i <= n; i++)
			ve[i].clear();
		for (int i = 1; i < n; i++) {
			int x, y;
			scanf("%d%d", &x, &y);
			ve[x].push_back(y);
			ve[y].push_back(x);
		}
		dfs1(1, 0);
		dfs2(1, 0);
		if (ans == 1e18)
			printf("-1\n");
		else
			printf("%lld\n", ans);
	}
}