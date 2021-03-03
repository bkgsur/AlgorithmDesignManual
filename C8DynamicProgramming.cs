using System;
using System.Collections.Generic;
using System.Linq;


namespace AlgorithmDesignManual
{
    public class C8DynamicProgramming : Helper, IRun
    {

        public void Run()
        {
            //int n_fib =25;
            //Print(n_fib);
            //Print(fib_c_driver(n_fib));
            //Print(fib_dp(n_fib));
           //Print(fib_ultimate(n_fib));
           // Print(binomial_coefficient(5,2));
           var s = new char[] {'a','b','c','d'};
           var t =  new char[] {'a','b','c'};
           Print(string_compare(s,t, 3,2));
           Print(string_compare(s,t));
           
        }
        /*  #region Fib */
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

        /*  #endregion  */

       public long binomial_coefficient(int n,int k)
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

       int MATCH =0;
       int INSERT =1;
       int DELETE=2;
       int SUBSTITUTE=3;

       public class Cell
       {
           public int score {get;set;}
           public int parent {get;set;} 
           public bool ismatch {get;set;}
       }

       public int string_compare(char[] s, char[] t, int i, int j)
       {
            int k;
            int[] opt = new int[3];
            int lower_cost;

            if(i==0)
            {
                return j * indel('/');
            }
            if(j==0)
            {
                return i * indel('/');
            }

            opt[MATCH] =  string_compare(s, t,  i-1,  j-1) +  match (s[i], t[j]);
            opt[INSERT] =  string_compare(s, t,  i,  j-1) +  indel (t[j]);
            opt[DELETE] =  string_compare(s, t,  i-1,  j) +  indel (s[j]);

            lower_cost = opt[MATCH];

            for(k= INSERT;k<=DELETE;k++)
            {
                if(opt[k]<lower_cost)
                {
                    lower_cost = opt[k];
                }
            }

            return lower_cost;
       }

        public int string_compare(char[] s, char[] t)
       {

            
           int n = s.Length;
           int k = t.Length;
           Cell[][] bc = init_matrix2<Cell>(n,k);

           //index zero of both axis is for empty string representation

           //initial conditions
            bc[0][0].score=0;
            bc[0][0].parent=-1;

           //t length is zero - so the cost of transforming s to a zero t is len(s)
            // Print(bc);
           for(int i=1;i<=n;i++)
           {
               bc[i][0].score = i;
              bc[i][0].parent = DELETE;
           }
              // Print(bc);
           //s length is zero - so the cost of transforming t to a zero s is len(t)

           for(int i=1;i<=k;i++)
           {
               bc[0][i].score= i;
               bc[0][i].parent=INSERT;
           }
              // Print(bc);
           for(int i=1;i<=n;i++)
           {
               for(int j=1;j<=k;j++)
               {
                SetCell(bc,bc[i][j] ,i,j,s,t);
               }
             
           }
           reconstruct_path(bc,s, t,n, k);
           return bc[n][k].score;
       }

        private void SetCell(Cell[][] bc,Cell c, int i, int j, char[] s, char[] t)
        {
            int m = match(s[i-1], t[j-1]);
            int parent=-1;
            int score =0;
            
            if(m==0)//match
            {
                c.ismatch=true;
            }
             
             int sScore=bc[i-1][j-1].score;
             int iScore = bc[i][j-1].score;
             int dScore = bc[i-1][j].score;
            
            if(sScore<iScore) //from top left - subs
            {
                parent= SUBSTITUTE;
                score = sScore;
            }
            else //from left =insert
            {
                parent= INSERT;
                score = iScore;
            }
            //from top - delete
            if(dScore<score)
            {
                parent= DELETE;
                score = dScore;
            }            
             
            c.score = score+m;
            c.parent= parent;
        }

    public void Print(Cell[][] matrix)
    {
        Cell t;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                t = matrix[i][j];
                Console.Write(String.Format("|{0} - {1}, P: {2} - {3}", "(" + i +"," + j +")", t.score,t.parent,t.ismatch) + "|");
                 //Console.Write(String.Format("|{1}", "(" + i +"," + j +")", t.score,t.parent) + "|");
            }
            Console.WriteLine();
            
        }
         Console.WriteLine("==========================================");
        Console.WriteLine();
    }
      private  int match(char c, char d)
        {
        if (c == d) return(0); 
        else return(1); 
        }

       private int indel(char c)
       {
           return 1;
       }
        private void reconstruct_path(Cell[][] m,char[] s, char[] t,int i, int j)
        {
            if (m[i][j].parent == -1) return;
            if (m[i][j].parent == MATCH) 
            {
                reconstruct_path(m,s,t,i-1,j-1);
                match_out(s, t, i, j);
                
            }
                if (m[i][j].parent == INSERT) {
                reconstruct_path(m,s,t,i,j-1);
                insert_out(t,j);
                
            }
                if (m[i][j].parent == DELETE) {
                reconstruct_path(m,s,t,i-1,j);
                delete_out(s,i);
               
            }
        }

        private void match_out(char[] s, char[] t,int i, int j)
        {
            if (s[i]==t[j])
            { 
                Print("M");
            }
            else 
            {
                Print("S");
            }
        }

        private void insert_out(char[] t, int j)
        {
            Print("I");
        }
        private void delete_out(char[]s, int i)
        {
            Print("D");
        }

    }
}
