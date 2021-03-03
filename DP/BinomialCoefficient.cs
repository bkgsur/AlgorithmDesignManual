using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmDesignManual;


namespace AlgorithmDesignManual.DP
{
    public class BinomialCoefficient : Helper, IRun
    {
        public void Run()
        {
            Print(binomial_coefficient(5,2));
        }

        private  long binomial_coefficient(int n,int k)
       {
           long[][] bc = init_matrix<long>(n,k,0) ;
            for(int i=0;i<=n;i++)
            {
                bc[i][0]=1;
            }
            bc[0][0]=1;
            for(int i=1;i<=n;i++)
            {
                 for(int j=1;j<=k;j++)
                 {
                    bc[i][j]= bc[i-1][j-1] + bc[i-1][j] ;
                 }
                
            }
           return bc[n][k];
       }
    }
}