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
        }

         protected void Swap<T>(List<T> s, int i,int j)
        {
                T temp  = s[i];
                s[i]=s[j];
                s[j]=temp;
        }

    }

}