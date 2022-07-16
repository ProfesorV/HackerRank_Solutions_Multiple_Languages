#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;


int main() {
    int N, n, total;
    float positive = 0., negative = 0., zero = 0.;
    
    cin >> N;
    
    total = N;
    
    while (N--) {
        cin >> n;
        if (n > 0) positive++;
        else if (n < 0) negative++;
        else zero++;
    }
    
    cout << positive / total << endl;
    cout << negative / total << endl;
    cout << zero / total << endl;
    
    return 0;
}