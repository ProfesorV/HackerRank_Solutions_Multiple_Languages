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
    int n;
    int m;
    cin >> n >> m;
    //< >
    vector<int> a(n);
    //for <
    for(int arrOnei = 0;arrOnei < n;arrOnei++){
        //>> []
       cin >> a[arrOnei];
    }
    //< >
    vector<int> b(m);
    //for <
    for(int arrTwoi = 0;arrTwoi < m;arrTwoi++){
        //>> []
       cin >> b[arrTwoi];
    }
    //=
    int answer=0;
    //for <=
    for(int x=1;x<=100;x++){
        //= true
        bool validNumber=true;
        //for < if %[]!=
        for(int i=0;i<n;i++) if(x%a[i]!=0) validNumber=false;
        //for < if []% !=
        for(int i=0;i<m;i++) if(b[i]%x!=0) validNumber=false; 
        //if
        if(validNumber) answer++;
    }
    //<< <<
    cout<<answer<<endl;
    return 0;
}


