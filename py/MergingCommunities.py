import sys
from collections import deque
#set to
intN, intQ = map(int,input().strip().split(' '))
#set to, for
listIntS = [i for i in range(intN+1)]
#set to + for
listIntCount = [0]+[1 for i in range(intN)]
#for 
for i in range(intQ):
    #set to .,.
    listStringInput = input().strip().split(' ')
    #set to
    StringQuery = listStringInput[0]
    #set to lambda : pass on
    listIntA = sorted(map(lambda x: int(x),listStringInput[1:]))
    #set to
    i0 = listIntA[0]
    #if == and !=
    if StringQuery == 'M' and listIntS[i0] != listIntS[listIntA[1]]:
        #set to
        i1 = listIntA[1]
        temporary = deque()
        #while !=
        while i0 != listIntS[i0]:
            #.
            temporary.append(i0)
            #set to
            i0 = listIntS[i0]
        #while !=
        while i1 != listIntS[i1]:
            #.
            temporary.append(i1)
            #set to
            i1 = listIntS[i1]
        #if !=
        if listIntS[i0] != listIntS[i1]:
            #+=
            listIntCount[listIntS[i0]] += listIntCount[listIntS[i1]]
            #.
            temporary.append(i1)
            #for
            for ix in temporary:
                #set to
                listIntS[ix] = listIntS[i0]
    #elif ==
    elif StringQuery == 'Q':
        #set to
        temporary = deque()
        #while !=
        while i0 != listIntS[i0]:
            #.
            temporary.append(i0)
            #set to
            i0 = listIntS[i0]
        #for 
        for ix in temporary:
            #set to
            listIntS[ix] = listIntS[i0]
        print(listIntCount[i0])