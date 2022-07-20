#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;
int intArr[100000];
//Physical Equivalents: Number of Integers, Index Of, Container
int main() {
    //declare
    int n, i;
    scanf ("%d", &n);
    //for <
    for (i = 0;i < n; i ++)
        //& []
        scanf ("%d", &intArr[i]);
    //for >=
    for (i = n - 1; i >= 0; i --)
        //[]
        printf ("%d ", intArr[i]);
    return 0;
}