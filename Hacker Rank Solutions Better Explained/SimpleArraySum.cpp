#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;


int main() {
    //declare
    unsigned long long int N, Sum = 0, i, Num;
    //cin
    cin>>N;
    //for <=
    for (i = 1 ; i <= N ; i++)
        {
        //cin
        cin>> Num;
        //augment by
        Sum += Num;
    }
    //cout
    cout<<Sum<<endl;
       
    return 0;
}
