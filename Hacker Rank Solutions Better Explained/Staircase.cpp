#include <map>
#include <set>
#include <list>
#include <cmath>
#include <ctime>
#include <deque>
#include <queue>
#include <stack>
#include <string>
#include <bitset>
#include <cstdio>
#include <limits>
#include <vector>
#include <climits>
#include <cstring>
#include <cstdlib>
#include <fstream>
#include <numeric>
#include <sstream>
#include <iostream>
#include <algorithm>
#include <unordered_map>

using namespace std;


int main(){
    //declare
      int n;
      //cin
      cin>>n;
      //for
      for(int i=0;i<n;i++)
      {
        //for
         for(int j=n-i; j>1;j--)
         { 
            //cout
          cout<<' ';
         }
         //for
          for(int j=i; j>=0;j--)
          {
            //cout
          cout<<"#";
          }
          //cout
          cout<<endl;
          
      }
      

    
    return 0;
}