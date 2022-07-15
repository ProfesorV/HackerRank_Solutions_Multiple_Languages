read x
read y
read z
#if (((==)&&(==)))
if ((($x == $y) && ($y == $z)))
    #then
	then
    #function
	echo "EQUILATERAL"
#elif == || == || ==
elif ((($x == $y) || ($x == $z) || ($y == $z)))
    #then
	then
	echo "ISOSCELES"
#else
else
	echo "SCALENE"
#if end
fi 