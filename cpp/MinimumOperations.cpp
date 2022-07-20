#include <cstdio> 
#include <cstdlib> 
#include <cstring> 
#include <algorithm> 
#include <vector> 
#include <cmath> 
#include <iostream> 
#include <map> 
using namespace std; 
//[][<<]
int multiDimIntArr[110][1<<3];
//< >, < >, < >
int min_operations(vector <int> intVectorRed, 
vector <int> intVectorGreen, vector <int> intVectorBlue) {
    //= (int) .size()
    int n = (int)intVectorRed.size(), i, j;
    //for <=
    for (i = 0; i <= n; i++) {
        //for <=
        for (j = 0; j <= 7; j++) {
            //[][] = <<
            multiDimIntArr[i][j] = 1<<30;
        }
    }
    //[][] =
    multiDimIntArr[0][0] = 0;
    //for <
    for (i = 0; i < n; i++){
        //for <=
        for (j = 0; j <= 7; j++){
            //[+][|] = min([+][|],[][]+[]+[])
            multiDimIntArr[i + 1][j | 1] = min(multiDimIntArr[i + 1][j | 1], 
            multiDimIntArr[i][j] + intVectorGreen[i] + intVectorBlue[i]);
            //[+][|] = min([+][|],[][]+[]+[])
            multiDimIntArr[i + 1][j | 2] = min(multiDimIntArr[i + 1][j | 2], 
            multiDimIntArr[i][j] + intVectorRed[i] + intVectorBlue[i]);
            //[+][|] = min([+][|],[][]+[]+[])
            multiDimIntArr[i + 1][j | 4] = min(multiDimIntArr[i + 1][j | 4], 
            multiDimIntArr[i][j] + intVectorRed[i] + intVectorGreen[i]);
        }
    }
    //=
    j = 0;
    //for <
    for (i = 0; i < n; i++){
        //if [] |=
        if (intVectorRed[i]) j |= 1;
        //if [] |=
        if (intVectorGreen[i]) j |= 2;
        //if [] |=
        if (intVectorBlue[i]) j |= 4;
    }
    //if [][] >= (1<<30)
    if (multiDimIntArr[n][j] >= (1<<30))
    //[][] =-
        multiDimIntArr[n][j] = -1;
    //return [][]
    return multiDimIntArr[n][j];
}

int main() {
    //declare
    int n, red, green, blue;
    cin >> n;
    vector<int> intVectorRed, intVectorBlue, intVectorGreen;
    //for <
    for(int i = 0; i < n; i++){
        //cin
        cin >> red >> green >> blue;
        intVectorRed.push_back(red);
        intVectorGreen.push_back(green);
        intVectorBlue.push_back(blue);
    }
    cout << min_operations(intVectorRed, intVectorGreen, intVectorBlue) << "\n";
    return 0;
}