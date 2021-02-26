using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesignManual
{
    public class Helper
    {
        protected void Print<T>(T s )
        {
            Console.WriteLine(s);
            Console.WriteLine("====================");
        }

         protected void Print<T>(T[] s )
        {
             Print(s.ToList());
        }

        protected void Print<T>(List<T> s)
        {
            if(s==null || s.Count==0)
            {
                Console.WriteLine("No Result");
            }
            else
            {
            Console.WriteLine(String.Join(",",s));
            }
            Console.WriteLine("====================");
        }

         protected void Swap<T>(List<T> s, int i,int j)
        {
                T temp  = s[i];
                s[i]=s[j];
                s[j]=temp;
        }
        protected void Swap<T>(T[] s, int i,int j)
        {
                T temp  = s[i];
                s[i]=s[j];
                s[j]=temp;
        }

        protected IEnumerable<int> randomnumberslistUnSorted(int n, int start=0)
        {
            var rand = new Random();
            return Enumerable.Range(start,n).OrderBy(e=>rand.Next());
             
        }      
    }

}