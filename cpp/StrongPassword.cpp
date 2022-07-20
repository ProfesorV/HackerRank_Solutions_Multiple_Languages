#include <bits/stdc++.h>

using namespace std;
//declaration
int n, a, b, c, d;
string testString;

int main() {
    //cin >> variables
    cin >> n >> s;
    //for <
    for (int i = 0; i < n; i++) {
        //if >= && <=
        if (testString[i] >= '0' && testString[i] <= '9') a = 1;
        else if (testString[i] >= 'a' && testString[i] <= 'z') b = 1;
        else if (testString[i] >= 'A' && testString[i] <= 'Z') c = 1;
        else d = 1;
    }
    //max()
    cout << max(6 - n, 4 - a - b - c - d);
    //return
    return 0;
}