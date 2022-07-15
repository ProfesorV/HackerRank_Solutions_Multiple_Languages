read n
#%.3 decimals, cat is concatinate, tr change parameters, bc is bash calculator
printf " f" $(echo "("$(cat)")/$n" | tr ' ' '+' | bc -l)