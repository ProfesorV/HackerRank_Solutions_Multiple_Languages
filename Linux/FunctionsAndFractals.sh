#declare a variables
declare -A arr
#function
f() {
    #local variable declaration
    local depthOfTree=$1 lengthOfTree=$2 rowsOfTree=$3 columnsOfTree=$4
    #&&
    [[ $depthOfTree -eq 0 ]] && return
    #for do
    for ((i=lengthOfTree; i; i--)); do
        arr[$((rowsOfTree-i)).$columnsOfTree]=1
    #done
    done
    ((rowsOfTree -= lengthOfTree))
    #for do
    for ((i=lengthOfTree; i; i--)); do
        arr[$((rowsOfTree-i)).$((columnsOfTree-i))]=1
        arr[$((rowsOfTree-i)).$((columnsOfTree+i))]=1
    #done
    done
    f $((depthOfTree-1)) $((lengthOfTree/2)) 
    $((rowsOfTree-lengthOfTree)) $((columnsOfTree-lengthOfTree))
    f $((depthOfTree-1)) $((lengthOfTree/2)) 
    $((rowsOfTree-lengthOfTree)) $((columnsOfTree+lengthOfTree))
}

read n
f $n 16 63 49
#for < do
for ((i=0; i<63; i++)); do
    #for < do
    for ((j=0; j<100; j++)); do
        #if then
        if [[ ${a[$i.$j]} ]]; then
            printf 1
        #else
        else
            printf _
        #if end
        fi
    #done
    done
    echo
#done
done