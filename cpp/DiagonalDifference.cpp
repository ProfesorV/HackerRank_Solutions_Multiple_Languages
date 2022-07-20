#include <iostream>
using namespace std;
int main() 
{
    //, =, =
  int N, LeftDiagonal = 0, RightDiagonal = 0;
  //>>
  cin >> N;
  //[][]
  int multiDimArr[N][N];
  //for <
  for (int i = 0; i < N; i++) 
  {
    //for <
    for (int j = 0; j < N; j++) 
    {
        //>> [][]
      cin >> multiDimArr[i][j];
      //==
      if (i == j) 
   {
    //= + [][]
        LeftDiagonal = LeftDiagonal + multiDimArr[i][j];
      }
    }
  }
  //for <
  for (int i = 0; i < N; i++) 
  {
    //for >=
    for (int j = N - 1 - i; j >= 0;) 
    {
        //= + [][]
      RightDiagonal = RightDiagonal + multiDimArr[i][j];
      break;
    }
  }
  // << abs()<<
  cout << abs(LeftDiagonal - RightDiagonal) << endl;
  return 0;
}