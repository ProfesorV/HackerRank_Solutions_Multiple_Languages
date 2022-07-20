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
            //= .Parse(.ReadLine())
            int n = int.Parse(Console.ReadLine());
            //new int[]
            int[] intArr = new int[n];
            //= .ReadLine().Split('')
            string[] stringArrSplit = Console.ReadLine().Split(' ');
            //for <
            for (int i = 0; i < n; i++)
            {
                //[] = .Parse([])
                intArr[i] = int.Parse(stringArrSplit[i]);
            }
            //=
            int s = 1;
            //while < && [] >= [-]
            while (s < n && intArr[s] >= intArr[s - 1])
            {
                //__
                s++;
            }
            //if ==
            if (s == n)
            {
                Console.WriteLine("yes");
                return;
            }
            //==
            int e = n - 2;
            //while >= && [] <= [+]
            while (e >= 0 && intArr[e] <= intArr[e + 1])
            {
                //--
                e--;
            }
            //--
            s--;
            //++
            e++;
            //= []
            int swapVar = intArr[s];
            //[]=[]
            intArr[s] = intArr[e];
            //[] = 
            intArr[e] = swapVar;
            //if > && [] < [-]
            if (s > 0 && intArr[s] < intArr[s - 1])
            {
                Console.WriteLine("no");
                return;
            }
            //if < - && [] > [+]
            if (e < n - 1 && intArr[e] > intArr[e + 1])
            {
                Console.WriteLine("no");
                return;
            }
            //=
            bool ascendingCheck = true;
            //for <=
            for (int i = s + 1; i <= e; i++)
            {
                //if []<[-]
                if (intArr[i] < intArr[i - 1])
                {
                    //=
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
            //= []
            swapVar = intArr[s];
            //[] = []
            intArr[s] = intArr[e];
            //[] = []
            intArr[e] = swapVar;
            //=
            ascendingCheck = true;
            //for >=
            for (int i = e - 1; i >= s; i--)
            {
                //if [] < [+]
                if (intArr[i] < intArr[i + 1])
                {
                    //=
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