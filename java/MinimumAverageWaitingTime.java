import java.io.*;
import java.util.*;
import java.util.Map.Entry;

public class Solution {
    private static long computeMinAvg(NavigableMap<Long, 
    List<CustomClassCustomer>> pLongListCustomerMap) {
        //set to create new
        PriorityQueue<CustomClassCustomer> priorityQueueCustomers = new PriorityQueue<>();
        //set to
        long currTime = 0;
        long totalWaitTime = 0;
        //while ! . || !.
        while (!pLongListCustomerMap.isEmpty() 
        || !priorityQueueCustomers.isEmpty()) {
            //if .
            if (priorityQueueCustomers.isEmpty()) {
                //set to
                Entry<Long, List<CustomClassCustomer>> LongListCustomerEntry = 
                pLongListCustomerMap.pollFirstEntry();
                .,.
                priorityQueueCustomers.addAll(LongListCustomerEntry.getValue());
                //set to
                currTime = LongListCustomerEntry.getKey();
            //else
            } else {
                //set to
                CustomClassCustomer CustomerNextCook = priorityQueueCustomers.poll();
                //+=
                currTime += CustomerNextCook.cookTime;
                totalWaitTime += currTime - CustomerNextCook.arrivalTime;
                //set to
                NavigableMap<Long, List<CustomClassCustomer>> LongListCustomerMapArrivals = 
                pLongListCustomerMap.headMap(currTime, true);
                LongListCustomerMapArrivals.values()
                        .stream()
                        .forEach(priorityQueueCustomers::addAll);
                LongListCustomerMapArrivals.clear();
            }
        }
        return totalWaitTime;
    }

    private static class CustomClassCustomer implements Comparable<CustomClassCustomer> {
        final long arrivalTime;
        final Long cookTime;

        CustomClassCustomer(long arrivalTime, long cookTime) {
            this.arrivalTime = arrivalTime;
            this.cookTime = cookTime;
        }

        @Override
        public int compareTo(CustomClassCustomer o) {
            return cookTime.compareTo(o.cookTime);
        }
    }

    public static void main(String[] args) {
        try (Scanner in = new Scanner(System.in)) {
            int n = in.nextInt();

            NavigableMap<Long, List<CustomClassCustomer>> pLongListCustomerMap = new TreeMap<>();
            for (int i = 0; i < n; i++) {
                CustomClassCustomer customer = new CustomClassCustomer(in.nextInt(), in.nextInt());
                pLongListCustomerMap.computeIfAbsent(customer.arrivalTime,
                                             a -> new ArrayList<>())
                            .add(customer);
            }
            System.out.println(computeMinAvg(pLongListCustomerMap) / n);
        }
    }
}