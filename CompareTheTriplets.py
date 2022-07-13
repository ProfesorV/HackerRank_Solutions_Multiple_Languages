import math
import os
import random
import re
import sys

#a, b
def compareTriplets(a, b):
    #declare
    arr = []
    #set to
    x=0
    #set to
    y=0
    #for
    for i in range(0,len(a)):
        #if
        if a[i]>b[i]:
            #augment
            x=x+1
        #elif
        elif b[i]>a[i]:
            #augment
            y=y+1
        else:
            continue
    #.
    arr.append(x)
    #.
    arr.append(y)
    #return
    return arr

    

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    a = list(map(int, input().rstrip().split()))

    b = list(map(int, input().rstrip().split()))

    result = compareTriplets(a, b)

    fptr.write(' '.join(map(str, result)))
    fptr.write('\n')

    fptr.close()