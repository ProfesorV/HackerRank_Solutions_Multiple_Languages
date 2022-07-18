#include <iostream>
#include <stdio.h>

using namespace std;

const int MODULO = 1000000007;
const int MAXNUMBER = 1000;

long long MULTIDIMARR_T[MAXNUMBER + 1][MAXNUMBER + 1];
long long ARR_B[MAXNUMBER + 1], ARR_G[MAXNUMBER + 1];

void initiate()
{
    //set to
	MULTIDIMARR_T[1][0] = 1;
    //for <=
	for (int j = 1; j <= MAXNUMBER; j++)
	{
		MULTIDIMARR_T[1][j] = MULTIDIMARR_T[1][j - 1];
        //if >=
		if (j >= 2) MULTIDIMARR_T[1][j] += MULTIDIMARR_T[1][j - 2];
		if (j >= 3) MULTIDIMARR_T[1][j] += MULTIDIMARR_T[1][j - 3];
		if (j >= 4) MULTIDIMARR_T[1][j] += MULTIDIMARR_T[1][j - 4];
        //%=
		MULTIDIMARR_T[1][j] %= MODULO ;
	}
    //for <=
	for (int i = 2; i <= MAXNUMBER; i++)
    //for <
		for (int j = 1; j <= MAXNUMBER; j++) 
		{
            //set to
			MULTIDIMARR_T[i][j] = MULTIDIMARR_T[i - 1][j] * MULTIDIMARR_T[1][j];
            //%=
			MULTIDIMARR_T[i][j] %= MODULO ;
		}
}

int main()
{
	initiate();	
	int cs, n, m;
	cin >> cs ;
    //while 
	while (cs--)
	{
		cin >> n >> m;
        //set to
		ARR_B[1] = 0;
		ARR_G[1] = 1;
        //for <=
		for (int j = 2; j <= m; j++)
		{
            //set to
			ARR_B[j] = 0;
            //for <
			for (int k = 1; k < j; k++)
			{
                //+=
				ARR_B[j] += MULTIDIMARR_T[n][j - k] * ARR_G[k];
                //%=
				ARR_B[j] %= MODULO ;
			}
            //set to
			ARR_G[j] = (MULTIDIMARR_T[n][j] + MODULO - ARR_B[j]) % MODULO ;
		}
		cout << ARR_G[m] << endl;
	}	
}