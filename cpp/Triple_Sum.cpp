#include <bits/stdc++.h>
using namespace std;

int main(){
    int p,q,r,i,x,y;
    cin>>p>>q>>r;

    int a[p],b[q],c[r];
    //for condition
    for(i=0;i<p;++i) {
        //>>
        cin>>a[i];
    }
    //for condition
    for(i=0;i<q;++i) {
        //>>
        cin>>b[i];
    }
    //for condition
    for(i=0;i<r;++i) {
        //>>
        cin>>c[i];
    }
    //apply function
    sort(a,a+p);
    //apply function
    sort(b,b+q);
    //apply function
    sort(c,c+r);
    //long
    long distinct_a[p],distinct_b[q],distinct_c[r];
    //set<int>
    set<int> s;
    //for condition
    for(i=0;i<p;++i) {
        //apply function
        s.insert(a[i]);
        //set to
        distinct_a[i]=s.size();
    }
    //apply function
    s.clear();
    //for condition
    for(i=0;i<q;++i) {
        //apply function
        s.insert(b[i]);
        //set to
        distinct_b[i]=s.size();
    }
    //apply function
    s.clear();
    //for condition
    for(i=0;i<r;++i) {
        //apply function
        s.insert(c[i]);
        //set to
        distinct_c[i]=s.size();
    }
    //set to
    long ans=0;
    //set to apply function
    x = upper_bound(a,a+p,b[0])-a;
    //set to apply function
    y = upper_bound(c,c+r,b[0])-c;
    //subtract by
    x-=1,y-=1;
    //if condition
    if(x>=0 && y>=0) {
        //augment by
        ans += distinct_a[x]*distinct_c[y];
    }
    //for condition
    for(i=1;i<q;++i) {
        //if condition
        if(b[i]!=b[i-1]) {
            //set to apply function
            x = upper_bound(a,a+p,b[i])-a;
            //set to apply function
            y = upper_bound(c,c+r,b[i])-c;
            //subtract by
            x-=1,y-=1;
            //if condition
            if(x>=0 && y>=0) {
                //augment by
                ans += distinct_a[x]*distinct_c[y];
            }
        }
    }
    //<<
    cout<<ans<<endl;
    return 0;
}