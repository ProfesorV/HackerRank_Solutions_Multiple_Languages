import sys
from collections import deque
#set to
N, Q = map(int,input().strip().split(' '))
#set to, for
s = [i for i in range(N+1)]
#set to + for
count = [0]+[1 for i in range(N)]
#for 
for i in range(Q):
    #set to .,.
    inpt = input().strip().split(' ')
    #set to
    query = inpt[0]
    #set to lambda : pass on
    a = sorted(map(lambda x: int(x),inpt[1:]))
    #set to
    i0 = a[0]
    #if == and !=
    if query == 'M' and s[i0] != s[a[1]]:
        #set to
        i1 = a[1]
        temporary = deque()
        #while !=
        while i0 != s[i0]:
            #.
            temporary.append(i0)
            #set to
            i0 = s[i0]
        #while !=
        while i1 != s[i1]:
            #.
            temporary.append(i1)
            #set to
            i1 = s[i1]
        #if !=
        if s[i0] != s[i1]:
            #+=
            count[s[i0]] += count[s[i1]]
            #.
            temporary.append(i1)
            #for
            for ix in temporary:
                #set to
                s[ix] = s[i0]
    #elif ==
    elif query == 'Q':
        #set to
        temporary = deque()
        #while !=
        while i0 != s[i0]:
            #.
            temporary.append(i0)
            #set to
            i0 = s[i0]
        #for 
        for ix in temporary:
            #set to
            s[ix] = s[i0]
        print(count[i0])