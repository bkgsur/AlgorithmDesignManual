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

        protected T[]  init_array<T>(int n ,T defaultValue) 
        {
            T[] A = new T[n];
            for(int i=0;i<A.Length;i++)
            {
                A[i]= defaultValue;
            }
            return A;
            
        }
         protected T[][] init_matrix<T>(int m , int n,T defaultValue) 
        {
            T[][] A = new T[m+1][];
            for(int i=0;i<=m;i++)
            {
                A[i]= init_array<T>( n+1 ,defaultValue) ;
            }
            return A;
            
        }
         protected T[][] init_matrix2<T>(int m , int n) where T:class, new()
        {
            T[][] A = new T[m+1][];
            for(int i=0;i<=m;i++)
            {
                A[i]= init_array2<T>( n+1) ;
            }
            return A;
            
        }

         protected T[]  init_array2<T>(int n ) where T:class, new()
        {
            T[] A = new T[n];
            for(int i=0;i<A.Length;i++)
            {
                A[i]= new T();
            }
            return A;
            
        }
    }

}