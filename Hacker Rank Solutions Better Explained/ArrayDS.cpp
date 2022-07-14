#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;
int a[100000];


int main() {
    //declare
    int n, i;
    scanf ("%d", &n);
    //for <
    for (i = 0;i < n; i ++)
        scanf ("%d", &a[i]);
    //for >=
    for (i = n - 1; i >= 0; i --)
        printf ("%d ", a[i]);
    return 0;
}