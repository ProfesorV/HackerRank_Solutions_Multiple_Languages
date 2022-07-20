#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include<cstring>
using namespace std;

//= +
const int MAXNUMBER = 200 + 4;
//declare
int n, m, t, 
//[][]
multiDimArr[MAXNUMBER][MAXNUMBER], 
multiDimArrB[MAXNUMBER][MAXNUMBER];
//[]
string stringS[MAXNUMBER];
//(,){return <= && < && <= && <}
bool doesitFit(int x, int y){return 0 <= x && x < n && 0 <= y && y < m;};

void forTest(int z){
    //memcpy(,,sizeOf())
    memcpy(multiDimArrB, multiDimArr, sizeof(multiDimArr));
    //for <
    for (int i = 0; i < n; i++)
    //for <
        for (int j = 0; j < m; j++)
        //for <
            for (int ii = -1; ii <= 1; ii++)
            //for <
                for (int jj = -1; jj <= 1; jj++)
                //if abs()+abs()<= && doesitFit() && [+][+] == -
                    if (abs(ii) + abs(jj) <= 1 && doesitFit(i + ii, j + jj) 
                    && multiDimArr[i + ii][j + jj] == z - 3)
                    //[][]= 
                        multiDimArrB[i][j] = -1;
    //memcpy(,,sizeof())
    memcpy(multiDimArr, multiDimArrB, sizeof(multiDimArrB));
}

int main() {
    cin.tie(0);
    cin >> n >> m >> t;
    //for <
    for (int i = 0; i < n; i++){
        //>>
        cin >> stringS[i];
        //for <
        for (int j = 0; j < m; j++)
        //if [][] ==
            if (stringS[i][j] == 'O')
                //[][]=
                multiDimArr[i][j] = 0;
            else
                //[][]=
                multiDimArr[i][j] = -1;
    }
    //--
    t--;
    //%=
    t %= 24;
    //for <=
    for (int i = 2; i <= t+1; i++){
        //if % ==
        if (i % 2 == 0){
            //for <
            for (int ii = 0; ii < n; ii++)
            //for <
                for (int jj = 0; jj < m; jj++)
                //if [][]==
                    if (multiDimArr[ii][jj] == -1)  
                        //[][]=  
                        multiDimArr[ii][jj] = i;
        }
        else{
            forTest(i);
        }
    }
    for (int i = 0; i < n; i++){
        for (int j = 0; j < m; j++)
        //if ([][]!=)
            if (multiDimArr[i][j] != -1)
            //<< 
                cout << 'O';
            else
            //<<
                cout << '.';
        cout << "\n";
    }
    return 0;
}