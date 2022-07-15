import math
import os
import random
import re
import sys


def plusMinus(pArr):
    #set to
    x,z,y=0,0,0
    #for
    for i in range(0,len(pArr)):
        #if
        if pArr[i]>0:
            #augment
            x = x + 1
        #elif
        elif pArr[i]<0:
            #augment
            y = y + 1
        #else
        else:
            #augment
            z = z + 1
    print(x/len(pArr))
    print(y/len(pArr))
    print(z/len(pArr))

if __name__ == '__main__':
    n = int(input())

    arr = list(map(int, input().rstrip().split()))

    plusMinus(arr)