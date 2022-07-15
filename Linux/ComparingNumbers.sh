read X
read Y
#if >
if (( $X > $Y ))
#then
then
    echo "X is greater than Y"
#if end
fi

#if ==
if (( $X == $Y))
#then
then
    echo "X is equal to Y"
#if end
fi

#if <
if (( $X < $Y))
#then
then
    echo "X is less than Y"
#if end
fi