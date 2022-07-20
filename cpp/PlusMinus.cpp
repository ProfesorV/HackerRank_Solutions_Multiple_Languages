#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;


int main() {
    //declare
    int N, n, total;
    //= , =, =
    float positive = 0., negative = 0., zero = 0.;
    //>>
    cin >> N;
    // =
    total = N;
    // while(--)
    while (N--) {
        //>>
        cin >> n;
        //if > ++
        if (n > 0) positive++;
        //if < ++
        else if (n < 0) negative++;
        //else ++
        else zero++;
    }
    //<< / <<
    cout << positive / total << endl;
    cout << negative / total << endl;
    cout << zero / total << endl;   
    return 0;
}