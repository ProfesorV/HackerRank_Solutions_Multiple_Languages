#include <bits/stdc++.h>
using namespace std;
//predefined methods
#define REP(i,a,b) for (int i = (a); i <= (b); ++i)
#define REPD(i,a,b) for (int i = (a); i >= (b); --i)
#define FORI(i,n) REP(i,1,n)
#define FORSTATEMENT(i,n) REP(i,0,int(n)-1)
#define mp make_pair
#define pb push_back
#define pii pair<int,int>
#define vi vector<int>
#define ll long long
#define SZ(x) int((x).size())
#define DBG(v) cerr << #v << " = " << (v) << endl;
#define FOREACH(i,t) for (typeof(t.begin()) i=t.begin(); i!=t.end(); i++)
#define fi first
#define se second


int main(){
    //declare
    int s;
    int n;
    int m;
    cin >> s >> n >> m;
    vector<int> intVectorKeyboards(n);
    //for <
    for(int keyboardi = 0;keyboardi < n;keyboardi++){
       cin >> intVectorKeyboards[keyboardi];
    }
    vector<int> intVectorDrives(m);
    for(int drivei = 0;drivei < m;drivei++){
       cin >> intVectorDrives[drivei];
    }
    int res=-1;
    FORSTATEMENT(i,n) FORSTATEMENT(j,m) 
    if (intVectorKeyboards[i]+intVectorDrives[j] <= s) 
    res = max(res, intVectorKeyboards[i]+intVectorDrives[j]);
        cout << res << "\n";
    return 0;
}