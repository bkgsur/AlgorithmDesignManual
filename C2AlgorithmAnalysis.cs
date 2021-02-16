using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesignManual
{
    public class C2AlgorithmAnalysis : Helper, IRun
    {
        public void Run()
        {
           // List<int> randomlist = randomnumberslist(10);
            //Print(randomlist);
            //selectionsort(randomlist);
            //Print(randomlist);
            /* List<int> randomlist  = randomnumberslist(10);
            Print(randomlist);
            insertionsort(randomlist);
            Print(randomlist);
            */

            //Print(findmatch("SURESH" , "S"));
            //Print(power(2,50));
            //pyramidalnumbers(10);

            //Print(primaryarithmetic(123,456));
           // Print(primaryarithmetic(555, 555));
            //Print(primaryarithmetic(123,594));

           // multiplicationgame(162);
            //multiplicationgame(17);
            /*Sample Input
            3
            6241
            8191
            0
            Sample Output
            no
            yes
            no */
            //lightmorelight(3);
            //lightmorelight(6241);
            //lightmorelight(8191);

            //pirate(9);
            //pirate(15,100);
            //pirate(25,100);
            //Print(companies(3));
        }

        private void selectionsort(List<int> input)
        {
            int n = input.Count;
            int min=0;
           for (int i=0;i<n;i++)
           {
               min=i;
               for(int j=i+1;j<n;j++)
               {
                   if(input[j]<input[min])
                   {
                       min=j;
                   }
                  
               }
                Swap(input,i,min);
           }
        }

         private void insertionsort(List<int> input)
        {
            int n = input.Count;
            int j=0;
            for (int i=1;i<n;i++)
           {
               j=i;
               while ((j>0) &&(input[j]<input[j-1]))
               {    
                   Swap(input,j,j-1);
                   j=j-1;

               }
           }

        }

        private int findmatch(string t , string s)
        {

            int n = t.Length;
            int m = s.Length;            
            bool found=true;
            int j=0;
            for(int i=0;i<n-m;i++)
            {
                found=true;
                j=0;
                if(t[i] == s[j])//starting character
                {                     
                    for (j=1;j<m;j++)
                    {
                        if(t[i+j] != s[j])
                        {    
                            found =false;                        
                            break;
                        }
                    }     

                    if(found)
                    {
                        return i;
                    }             

                }
                
            }
            return -1;
        }

        private long power(int a, int n)
        {
            if(n==0)
            {
                return 1;
            }
           long x = power(a,n/2);
           //Print(x);

            if(n%2==0)//even
            {
                return (long)Math.Pow(x,2);
            }
            return a* (long)Math.Pow(x,2); //odd
        }


        

        private  bool pyramidalnumbers(int n = 1000000000) //a billiom
        {             
            SortedSet<int> m = new SortedSet<int>();
            //Fill pyramidal numbers
            for(int i=2;i<=n;i++)
            {
                m.Add((int)(Math.Pow(i,3)-i)/6);
            }
            //Sum of 2 pyramidal numbers
            SortedSet<int> s =  two(m);            
            return true;
        }

        private SortedSet<int> two(SortedSet<int> m)
        {
            SortedSet<int> s = new SortedSet<int>();
            int n = m.Count;
            for(int i=0;i<n-1;i++)
            {
                for(int j=i+1;j<n;j++)
                {
                    s.Add(m.ElementAt(i)+ m.ElementAt(j));
                }
            }
            return s;
        }

        private int primaryarithmetic(int m , int n)
        {
            int c=0;
            int cr=0;

            while (m>0 && n>0)
            {
                int mr=  m%10;
                m = m/10;

                int nr = n%10;
                  n=n/10;

                if (cr+ mr+nr>=10)
                {
                    cr=1;
                    c+=1;
                }
                else
                {
                    cr=0;
                }
            }

            return c;
        }

        /*Stan and Ollie play the game of multiplication by multiplying an integer p by one of the numbers 2 to
        9. Stan always starts with p = 1, does his multiplication, then Ollie multiplies the number, then Stan
        and so on. Before a game starts, they draw an integer 1 < n < 4294967295 and the winner is who first
        reaches p ≥ n.*/
        private void multiplicationgame(int n )
        {
            Random r = new Random();
            //int n = r.Next(1,4294967295);
            Print(n);
            int p=1;
            bool isStan=true;
            while(p<n) 
            {                 
                p = p*r.Next(2,9);
                isStan= !isStan;
            }

            if(isStan)
            {
                Print("Stan wins.");
            }
            else
            {
                 Print("Ollie wins.");
            }

        }

        private void lightmorelight(int n)
        {
            int factors=1;//starts switched off
            if(chkprime(n))
            {
                factors+=1;
            }
            else //get factors
            {
                if(n%2==0)//even
                {
                    factors +=n/2;
                }
                else
                { 
                    factors +=n/3;
                }
            }

            if(factors%2==0)//even
            {
                Print("No");
            }
            else
            { 
               Print("Yes");
            }
        }

        private bool chkprime(int num)
        {
            for (int i=2; i < num; i++)
            {
                if (num %i == 0) 
                {
                    return false;
                }
            }
            return true;
        }
        /*
        private void pirate(int n)
        {
            for(int i=1;i<=n;i++)
            {
                pirate(i,100);
            }
        }                
        private void pirate(int n, int s)
        {
            int[] res = new int[n];

            int sum=0;
            bool fill=false;
            for(int i=n-1;i>0;i--)
            {
                if(fill)
                {
                    res[i]=1;    
                    sum +=1;               

                }
                 fill = !fill;
            }
            res[0]= s-sum;

            Print(res.ToList());
        }
        private int companies(int n)
        {
            int s=0;
            for(int i=1;i<=n;i++)
            {
                s += ncr(n,i);
            }
            return s;
        }

        private int ncr(int n, int r)
        {
                return nfactorial(n)/(nfactorial(r)*nfactorial(n-r));
        }

        private int nfactorial(int n)
        {
            if(n==0)
            {
                return 1;
            }
            int r =1;
            for(int i=1;i<=n;i++)
            {
                r*=i;
            }
            return r;
        }
        */


    }
}

