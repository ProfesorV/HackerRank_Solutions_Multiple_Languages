#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;


int main() {
    int n,m;
    //>>
    cin>>n;
    //while >> >>
    while (cin>>n>>m)
    {
      //<< (int)(sqrt()+) - (int)(sqrt(-)+) <<
        cout<<(int)(sqrt(m)+0.0000001)-(int)(sqrt(n-1)+0.0000001)<<endl;
    }
    //return
  return 0;
}