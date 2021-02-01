using System;
using System.Collections.Generic;

namespace AlgorithmDesignManual
{
    public class C1Intro : Helper, IRun
    {
        public void Run()
        {
            Print(InsertionSort(new List<int>(){5,4,3,2,1}));
        }

        private List<int> InsertionSort(List<int> input)
        {                    
            for(int i=1;i<input.Count;i++)
            {
                int j=i;
                while ((j>0) && (input[j]<input[j-1]))
                {
                    Swap<int>(input,j,j-1);
                    j--;
                }
            }

            return input;
        }
    }
}