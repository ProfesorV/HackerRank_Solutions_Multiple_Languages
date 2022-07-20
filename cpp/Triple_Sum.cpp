#include <bits/stdc++.h>
using namespace std;

int main(){
    int p,q,r,i,x,y;
    //>> >> >>
    cin>>p>>q>>r;
    //[],[],[]
    int a[p],b[q],c[r];
    //for <
    for(i=0;i<p;++i) {
        //>>[]
        cin>>a[i];
    }
    //for <
    for(i=0;i<q;++i) {
        //>>[]
        cin>>b[i];
    }
    //for <
    for(i=0;i<r;++i) {
        //>> []
        cin>>c[i];
    }
    //sort()
    sort(a,a+p);
    //sort()
    sort(b,b+q);
    //sort()
    sort(c,c+r);
    //[],[],[]
    long distinct_a[p],distinct_b[q],distinct_c[r];
    //<int>
    set<int> s;
    //for condition <
    for(i=0;i<p;++i) {
        //.insert([])
        s.insert(a[i]);
        //[]=.size()
        distinct_a[i]=s.size();
    }
    //.clear()
    s.clear();
    //for <
    for(i=0;i<q;++i) {
        //sort()
        s.insert(b[i]);
        //[]=.size()
        distinct_b[i]=s.size();
    }
    //.clear()
    s.clear();
    //<
    for(i=0;i<r;++i) {
        //insert([])
        s.insert(c[i]);
        //[]=.size()
        distinct_c[i]=s.size();
    }
    //=
    long ans=0;
    //= upper_bound(,+,[])-
    x = upper_bound(a,a+p,b[0])-a;
    //= upper_bound(,+,[])-
    y = upper_bound(c,c+r,b[0])-c;
    //-=, -=
    x-=1,y-=1;
    //if >= && >=
    if(x>=0 && y>=0) {
        //+= []*[]
        ans += distinct_a[x]*distinct_c[y];
    }
    //for <
    for(i=1;i<q;++i) {
        //if []!=[i-1]
        if(b[i]!=b[i-1]) {
            ////= upper_bound(,+,[])-
            x = upper_bound(a,a+p,b[i])-a;
            ////= upper_bound(,+,[])-
            y = upper_bound(c,c+r,b[i])-c;
            //-=, -=
            x-=1,y-=1;
            //>= && >=
            if(x>=0 && y>=0) {
                //+= []*[]
                ans += distinct_a[x]*distinct_c[y];
            }
        }
    }
    //<< <<
    cout<<ans<<endl;
    return 0;
}