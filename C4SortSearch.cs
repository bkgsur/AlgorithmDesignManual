using System;
using System.Collections.Generic;
using System.Linq;


namespace AlgorithmDesignManual
{
    public class C4SortSearch : SearchHelper, IRun
    {

        public void Run()
        {
           //Print(isdisjoint());
          MinHeapRun();

           
        }

        /*  #region BST */
        /* Stop and Think: Finding the Intersection
            Problem: Give an efficient algorithm to determine whether two sets (of size m and
            n, respectively) are disjoint. Analyze the worst-case complexity in terms of m and
            n, considering the case where m is substantially smaller than n.*/


            public bool isdisjoint()
            {                         
                //small set

                //int[] smallset = randomnumberslistUnSorted(10).ToArray();

                int[] smallset = new int[]{1,2,3};
 
                int m = smallset.Count();
                Print(smallset);

                //int[] largeset = randomnumberslistUnSorted(10).ToArray();

                int[] largeset = new int[]{4,5,6};
                int n = largeset.Count();
                Print(largeset);
                //1. Sort large and (binary) search for  each item  of small array in the sorted large array

                //A. Sort large = O(nlogn)
                 Array.Sort(largeset);

                //B. (binary) search for each item  of small array in the sorted large array

                //O(m * logn)
                /* foreach (int target in smallset) //O(m)
                 {
                    if(BinarySearch(largeset,target)>0) //O(log n)
                    {
                        return false;
                    }
                    
                 }*/
                 //Total = O(nlogn) + O(m * logn) = O(m+n)log n


                 //2. Sort small and (binary) search for  each item  of large array in the sorted small array
                 // O(m+n)logm

                 //3. sort both and compare first items of each array. If not eqal remove smallest of the two and compare the rest
                 // m logm + n log n + m + n

                  Array.Sort(smallset);
                //Both arrays have entries
                while (m>0 && n>0)
                {
                    //get first of each array
                    int firstsmall = smallset[0];
                    int firstbig = largeset[0];

                    if(firstsmall ==firstbig)
                    {
                        Print(firstsmall);
                        return false;
                    }
                    else if(firstsmall < firstbig)
                    {
                            m-=1;                    
                    }
                    else  
                    {
                            n-=1;                    
                    }
                }



                return true;;
                
            }

            public void MinHeapRun()
            {
                var q = new priority_queue(10);
                new MinHeap().make_heap(q, Enumerable.Range(1,10).ToArray());
                Print(q.q);
                Print(q.n);
            }



        /*  #endregion  */
    }
}