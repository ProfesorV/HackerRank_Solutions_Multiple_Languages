#include <cstdio>
#include <iostream>
#include <ctime>
#include <string>
#include <vector>
#include <cmath>
#include <algorithm>
#include <cstring>
#include <set>
#include <cstdlib>
#include <ctime>
#include <cassert>
#include <bitset>
#include <fstream>
#include <deque>
#include <stack>
#include <climits>
#include <string>
#include <queue>
#include <memory.h>
#include <map>
#include <unordered_map>

#define ll long long
#define ld double
#define pii pair <ll, ll>
#define mp make_pair

using namespace std;

int main() {
    //set to
	int n;
	cin >> n;
    //set to
	int a = (int)1e9;
	int b = -1000;
	int s = 0, r = 0;
    //for <
	for (int i = 0; i < n; i++) {
        //set to
		int x;
		scanf("%d", &x);
        //if <
		if (x < a) {
            //++
			r++;
            //set to
			a = x;
		}
        //if >
		if (x > b) {
            //++
			s++;
            //set to
			b = x;
		}
	}
1	cout << s - 1 << ' ' << r - 1 << endl;
	return 0;
}