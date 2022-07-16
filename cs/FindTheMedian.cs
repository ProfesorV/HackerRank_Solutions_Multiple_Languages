using System;

class Solution
{
    //
    static int MedianFunction(int[] pIntArr, int pLeft, int pRight, int pIndex)
    {
        //set to
        int index = SegmentArray(pIntArr, pLeft, pRight);
        //if ==
        if (index - pLeft == pIndex)
            //return
            return pIntArr[index];
        // if >
        if (index - pLeft > pIndex - 1)
            //return function
            return MedianFunction(pIntArr, pLeft, index - 1, pIndex);
        //return function
        return MedianFunction(pIntArr, index + 1, pRight, pIndex - index + pLeft - 1);
    }

    static void Main(String[] args)
    {
        //No need to capture the size of array. We can use array's length property instead.
        Console.ReadLine();
        var mainArr = Console.ReadLine().Split(' ');
        var IntArr = Array.ConvertAll(mainArr, int.Parse);
        var k = IntArr.Length / 2;
        var result = MedianFunction(IntArr, 0, IntArr.Length - 1, k++);
        Console.WriteLine(result);
    }

    static int SegmentArray(int[] pIntArr, int pLeft, int pRight)
    {
        //set to
        var pivot = pIntArr[pRight];
        var indexOfPivot = pLeft;
        //for <=
        for (var j = pLeft; j <= pRight - 1; j++)
        {
            //if <=
            if (pIntArr[j] <= pivot)
            {
                Exchange(pIntArr, indexOfPivot, j);
                //++
                indexOfPivot++;
            }
        }
        Exchange(pIntArr, indexOfPivot, pRight);
        return indexOfPivot;
    }

    static void Exchange(int[] pIntArr, int index1, int index2)
    {
        var placeHolder = pIntArr[index1];
        pIntArr[index1] = pIntArr[index2];
        pIntArr[index2] = placeHolder;
    }
}