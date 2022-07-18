#include <bits/stdc++.h>
#define MOD 1000000007LL
using namespace std;
//declare
int n,p1,p2;
vector <int> vecOfAdj[100005];
typedef long long ll;
ll multiDimArr[100005][2][2];
ll filterFunc(int v, int p, int col, int pacol){
    //if >=, return
	if(multiDimArr[v][col][pacol]>=0ll) return multiDimArr[v][col][pacol];
    //set to
	multiDimArr[v][col][pacol]=1ll;
    //for <
	for(int x=0;x<vecOfAdj[v].size();x++){
        //if ==
		if(vecOfAdj[v][x]==p) continue;
        //*=
		multiDimArr[v][col][pacol]*=filterFunc(vecOfAdj[v][x],v,0,col)+filterFunc(vecOfAdj[v][x],v,1,col);
		//%=
        multiDimArr[v][col][pacol]%=MOD;
	}
    //if !=
	if(col!=pacol){
        //set to
		ll temp=1ll;
        //for <
		for(int x=0;x<vecOfAdj[v].size();x++){
            //if ==
			if(vecOfAdj[v][x]==p) continue;
            //*=
			temp*=filterFunc(vecOfAdj[v][x],v,pacol,col);
            //%=
			temp%=MOD;
		}
        //set to
		multiDimArr[v][col][pacol]=(multiDimArr[v][col][pacol]+MOD-temp)%MOD;
	}
	return multiDimArr[v][col][pacol];
}
int main(){
	memset(multiDimArr,-1,sizeof(multiDimArr));
	scanf("%d",&n);
    //for <
	for(int x=0;x<n-1;x++){
		scanf("%d %d",&p1,&p2);
		vecOfAdj[p1].push_back(p2);
		vecOfAdj[p2].push_back(p1);
	}
	printf("%lld\n",(filterFunc(1,0,0,1)+filterFunc(1,0,1,0))%MOD);
	return 0;
}