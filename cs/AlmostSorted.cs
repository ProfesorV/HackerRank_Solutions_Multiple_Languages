using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            //set to
            int n = int.Parse(Console.ReadLine());
            //set to create new
            int[] intArr = new int[n];
            //set to
            string[] stringArrSplit = Console.ReadLine().Split(' ');
            //for <
            for (int i = 0; i < n; i++)
            {
                //set to
                intArr[i] = int.Parse(stringArrSplit[i]);
            }
            //set to
            int s = 1;
            //while < && >=
            while (s < n && intArr[s] >= intArr[s - 1])
            {
                s++;
            }
            //if ==
            if (s == n)
            {
                Console.WriteLine("yes");
                return;
            }
            //set to
            int e = n - 2;
            //while >= && <=
            while (e >= 0 && intArr[e] <= intArr[e + 1])
            {
                //--
                e--;
            }
            //--
            s--;
            //++
            e++;
            //set to
            int swapVar = intArr[s];
            intArr[s] = intArr[e];
            intArr[e] = swapVar;
            //if > && <
            if (s > 0 && intArr[s] < intArr[s - 1])
            {
                Console.WriteLine("no");
                return;
            }
            //if < && >
            if (e < n - 1 && intArr[e] > intArr[e + 1])
            {
                Console.WriteLine("no");
                return;
            }
            //set to
            bool ascendingCheck = true;
            //for <=
            for (int i = s + 1; i <= e; i++)
            {
                //if <
                if (intArr[i] < intArr[i - 1])
                {
                    //set to
                    ascendingCheck = false;
                    break;
                }
            }
            //if
            if (ascendingCheck)
            {
                Console.WriteLine("yes");
                Console.WriteLine("swap {0} {1}", s+1, e+1);
                return;
            }
            //set to
            swapVar = intArr[s];
            intArr[s] = intArr[e];
            intArr[e] = swapVar;
            ascendingCheck = true;
            //for >=
            for (int i = e - 1; i >= s; i--)
            {
                //if <
                if (intArr[i] < intArr[i + 1])
                {
                    //set to
                    ascendingCheck = false;
                    break;
                }
            }
            //if
            if (ascendingCheck)
            {
                Console.WriteLine("yes");
                Console.WriteLine("reverse {0} {1}", s + 1, e + 1);
                return;
            }
            Console.WriteLine("no");
        }
    }
}