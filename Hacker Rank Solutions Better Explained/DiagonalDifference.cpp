#include <iostream>
using namespace std;
int main() 
{
    //declare, set to
  int N, LeftDiagonal = 0, RightDiagonal = 0;
  //cin
  cin >> N;
  //declare
  int a[N][N];
  //for
  for (int i = 0; i < N; i++) 
  {
    //for
    for (int j = 0; j < N; j++) 
    {
        //cin
      cin >> a[i][j];
      //if
      if (i == j) 
   {
    //set to augment by
        LeftDiagonal = LeftDiagonal + a[i][j];
      }
    }
  }
  //for
  for (int i = 0; i < N; i++) 
  {
    //for
    for (int j = N - 1 - i; j >= 0;) 
    {
        //set to augment by
      RightDiagonal = RightDiagonal + a[i][j];
      break;
    }
  }
  //cout
  cout << abs(LeftDiagonal - RightDiagonal) << endl;
  return 0;
}