#include <stdio.h>
#include <stdlib.h>
//define
#define MAXNUMBER 500000
int getIValue(long long*a,long long num,int size);
long long med(long long*a,int size);
long long multiDimArr[30][MAXNUMBER],arrSum[MAXNUMBER],binaryArr[30];
unsigned long long decimalArr[30];

int main(){
    //declar
  int T,i,j,k;
  long long x,y,z;
  unsigned long long answer;
  //for <
  for(i=binaryArr[0]=decimalArr[0]=1;i<30;i++){
    //set to
    binaryArr[i]=binaryArr[i-1]*2;
    decimalArr[i]=decimalArr[i-1]*10;
  }
  //for <
  for(i=0,multiDimArr[0][0]=1;i<MAXNUMBER;i++)
  //for <
    for(j=1;j<30;j++)
    //for <
      for(k=0;k<10;k++)
      //if <=
        if(k*binaryArr[j-1]<=i)
        //+=
          multiDimArr[j][i]+=multiDimArr[j-1][i-k*binaryArr[j-1]];
//for <
  for(i=0;i<MAXNUMBER;i++)
  //if
    if(i)
    //set to
      arrSum[i]=arrSum[i-1]+multiDimArr[29][i];
      //else
    else
    //set to
      arrSum[i]=multiDimArr[29][i];
  scanf("%d",&T);
  //while
  while(T--){
    scanf("%lld",&x);
    //set to
    i=getIValue(arrSum,x,MAXNUMBER);
    //if
    if(i)
    //set to
      y=x-arrSum[i-1];
    else
    //set to
      y=x;
    //for >=
    for(j=29,answer=0;j>=0;j--)
    //if
      if(j)
      //for <
        for(k=z=0;k<10;k++){
            //+=
          z+=multiDimArr[j][i-k*binaryArr[j]];
          //if >=
          if(z>=y){
            //-=
            y-=z-multiDimArr[j][i-k*binaryArr[j]];
            i-=k*binaryArr[j];
            //+=
            answer+=k*decimalArr[j];
            break;
          }
        }
        //else
      else
      //+=
        answer+=i;
    printf("%llu\n",answer);
  }
  return 0;
}
int getIValue(long long*a,long long num,int size){
    //if ==
  if(size==0)
  //return
    return 0;
    //if >
  if(num>med(a,size))
  //return
    return getIValue(&a[(size+1)>>1],num,size>>1)+((size+1)>>1);
    //else
  else
  //return
    return getIValue(a,num,(size-1)>>1);
}
long long med(long long*a,int size){
    //shift itself by 1
  return a[(size-1)>>1];
}