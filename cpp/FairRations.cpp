#include <map>
#include <set>
#include <list>
#include <cmath>
#include <ctime>
#include <deque>
#include <queue>
#include <stack>
#include <string>
#include <bitset>
#include <cstdio>
#include <limits>
#include <vector>
#include <climits>
#include <cstring>
#include <cstdlib>
#include <fstream>
#include <numeric>
#include <sstream>
#include <iostream>
#include <algorithm>
#include <unordered_map>

using namespace std;


int main(){
    //declare
    int N;
    //>>
    cin >> N;
    //<int>
    vector<int> intVector(N);
    //for <
    for(int intVectori = 0;intVectori < N;intVectori++){
        // >> []
       cin >> intVector[intVectori];
       // [] %= 2
       intVector[intVectori] %= 2;
    }
    // = 0
    int ans = 0;
    //for <
    for (int i = 0; i < N - 1; ++i) {
        //if([]==)
        if (intVector[i] == 1) {
            //+=2
            ans += 2;
            //[]--
            intVector[i]--;
            //[+]=([+]+)%2
            intVector[i + 1] = (intVector[i + 1] + 1) % 2;
        }
    }
    //if [-]== << <<
    if (intVector[N - 1] == 1) cout << "NO" << endl;
    //<< <<
    else cout << ans << endl;
    //return
    return 0;
}