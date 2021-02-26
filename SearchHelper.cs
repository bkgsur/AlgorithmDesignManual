using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesignManual
{
    public class SearchHelper:Helper
    {
        public int BinarySearch<T>(T[] sortedarray, T target) where T : IComparable
        {
            
            int l=0; 
            int h = sortedarray.Length-1;
            while (l<h)
            {
                int m = l + (h-l)/2;

                int compare = sortedarray[m].CompareTo(target);

                if (compare==0)
                {
                    return m;
                }
                else if(compare<0)
                {
                    l= m+1;
                }
                else
                {
                    m=h-1;
                }
            }

            return -1;
        }
         
    }
}