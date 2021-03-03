using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmDesignManual;


namespace AlgorithmDesignManual.DP
{
    public class Fibonacci : Helper, IRun
    {
        public void Run()
        {

            int n_fib =25;
            Print(n_fib);
            //Print(fib_c_driver(n_fib));
            //Print(fib_dp(n_fib));
            //Print(fib_ultimate(n_fib));
        }

        //F0 = 0,1,1, F3 = 2,3, 5, 8, 13, 21, 34, 55, 89, 144,.   
        private int fib_r(int n)
        {
            if(n<=0)
            {
                return 0;
            } 
            if(n==1)
            {
                return 1;
            }

            return fib_r(n-1) +  fib_r(n-2);
        }
        long fib_c(long[] f, int n)
        {
            if(f[n]==-1)
            {
                  f[n] = fib_c(f, n-1) + fib_c(f, n-2);
            }

            return f[n];

        }
        long fib_c_driver(int n)
        {
            if(n<0)
            {
                return 0;
            } 
             
            long[] f =init_array<long>(n+1, -1); 
            f[0]= 0;
            f[1]= 1;            

            return fib_c(f,n);            
        }


        
        long fib_dp(int n)
        {
            if(n<0)
            {
                return 0;
            } 
             
            long[] f =init_array<long>(n+1, -1); 
            decimal[] r =init_array<decimal>(n+1, 1); 
            f[0]= 0;
            f[1]=1;   

            for(int i=2;i<=n;i++)
            {
                f[i] = f[i-1] + f[i-2];
            }         
            Print(f);
            for(int i=1;i<n;i++)
            {
                r[i] = (decimal)f[i+1]/f[i];
            }
            Print(r);
            Print(r.Sum()/n);
            return f[n];            
        }

        long fib_ultimate(int n)
        {

            if(n<=0)
            {
                return 0;
            } 
            if(n==1)
            {
                return 1;
            }
            long item_minus_2=0;
            long item_minus_1=1;
            long sum=0;
            for(int i=2;i<=n;i++)
            {
                sum = item_minus_2 + item_minus_1;               
                item_minus_2 = item_minus_1;
                item_minus_1 = sum;
            }
            return sum;
        }

    }
}