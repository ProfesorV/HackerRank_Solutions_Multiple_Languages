#include <cstdio>
#include <iostream>
#include <vector>

using namespace std;
using std::vector;

void solve(){
    //declare
	int hour, minute, second;
	char AmPmC1, AmPmC2;
    //"%:%:%%%"
	scanf("%d:%d:%d%c%c", &hour, &minute, &second, &AmPmC1, &AmPmC2);
    //= %
	hour = hour % 12;
    //if ==
	if (AmPmC1 == 'P'){
        //= +
		hour = hour + 12;
	}
    //"%:%:\"
	printf("%02d:%02d:%02d\n", hour, minute, second);
	return;
}

int main(){
	solve();
    return 0;
}