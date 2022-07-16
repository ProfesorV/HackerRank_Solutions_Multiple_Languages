import heapq

def minWait(allOrders) :
    #set to
    totalWaitTime = 0
    #set to
    numOrders = len(allOrders)
    #if
    if numOrders == 0 :
        return 0
    #declare
    listPendingOrders = []
    #set to
    currentTime = allOrders[0][0]
    loop = True
    #while
    while loop :
        #while != and <=
        while len(allOrders) != 0 and allOrders[0][0] <= currentTime :
            #set to
            order = heapq.heappop(allOrders)   
            #.heappush
            heapq.heappush(listPendingOrders, (order[1], order[0]))
        #if !=
        if len(listPendingOrders) != 0 :
            #set to
            minWaitOrder = heapq.heappop(listPendingOrders)
            #set to calculate
            waitTime = currentTime - minWaitOrder[1] + minWaitOrder[0]
            #add to
            totalWaitTime += waitTime
            #add to
            currentTime += minWaitOrder[0]
        #else
        else :
            #add to
            currentTime += 1
        #if == and ==
        if len(listPendingOrders) == 0 and len(allOrders) == 0 :
            #set to
            loop = False
    #calculate
    return totalWaitTime/numOrders

n = int(input())
allOrders = []
for i in range(n) :
    line = input().split()
    l, t = int(line[0]), int(line[1])
    heapq.heappush(allOrders, (l, t))
print (int(minWait(allOrders)))