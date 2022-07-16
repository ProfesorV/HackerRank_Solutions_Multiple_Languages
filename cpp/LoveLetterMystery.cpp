#include <iostream>
#include <string>
#include <algorithm>
using namespace std;
int main(){
    int t;
    cin >> t;
    //while --
    while(t--){
        string textString;
        cin >> textString;
        int i = 0;
        int j = textString.length()-1;
        int solution = 0;
        while(i<j){
            solution += abs(textString[i]-textString[j]);
            ++i;
            --j;
        }
        cout<<solution<<"\n";
    }
    return 0;
}