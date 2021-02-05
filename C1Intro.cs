using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AlgorithmDesignManual
{
    public class C1Intro : Helper, IRun
    {
        public void Run()
        {
            //Print(InsertionSort(new List<int>(){5,4,3,2,1}));
            //nearestneighbor(3);
            //TSP();
            /*
            Print(maxthreenplusone(10,1));
            Print(maxthreenplusone(200,100));
            Print(maxthreenplusone(210,201));
            Print(maxthreenplusone(1000,900));
            */
           // Print(thetrip(new double[] {15.00,15.01,3.00,3.01} )) ;
           australianVoting();
        }

    //“The 3n + 1 Problem” – Programming Challenges 110101, UVA Judge 100.
    /*
        Consider the following algorithm:

        1. input n
        2. print n
        3. if n = 1 then STOP
        4. if n is odd then n ←− 3n + 1
        5. else n ←− n/2
        6. GOTO 2

        Given an input n, it is possible to determine the number of numbers printed before and including the 1 is printed. For a given n this is called the cycle-length of n.
         22 11 34 17 52 26 13 40 20 10 5 16 8 4 2 1
         In the example above, the cycle length of 22 is 16.
        For any two numbers i and j you are to determine the maximum cycle length over all numbers between and including both i and j.
    */
    
    private int maxthreenplusone(int i,int j)
    {
      
        int max=0;
        for (int k=j;k<=i;k++)
        {
            int cmax= threenplusone(k);
           
            if(cmax>max)
            {
                max=cmax;
            }
        }
        return max;
    }

    private int threenplusone(int i, int count=0)
    {
        
        if(i==1)
        {
            
            return count + 1;
        }
        
        count+=1;
         if(i%2==0)
         {             
            return  threenplusone(i/2, count);
         }
         else
         {
             return threenplusone(3 * i +1, count);

         }
          
    }


    private double thetrip(double[] costs ) 
    {
        
       int  nCosts = costs.Count();
       
        if (nCosts == 0) { 
            return 0.00;
        }
         
        int c = 0;
        for (c = 0; c < nCosts; c++) 
        {            
            costs[c] = costs[c] * 100;            
        }
        
        double sumCents = costs.Sum();
        double avgCents = ((double) sumCents) / nCosts;
        double taken = 0;
        double given = 0;
        
        int i;
        for (i = 0; i < nCosts; i++) {
            double deltaCents = costs[i] - avgCents;
            if (deltaCents < 0) {
                taken += -((int) deltaCents) / 100.0;
            } else {
                given += ((int) deltaCents) / 100.0;
            }
        }
        
        return taken > given ? taken : given;
    }

        /*
        Candidates - 
            John Doe
            Jane Smith
            Sirhan Sirhan
        Voters - 5
        Votes:
            1 2 3
            2 1 3
            2 3 1
            1 2 3
            3 1 2
        Winner - John Doe 
        */

    private void  australianVoting()
    {
        List<int[]> votesList = new List<int[]>();
        Dictionary<int,String> candidates = new Dictionary<int,String>();
        candidates.Add(1,"John Doe");
        candidates.Add(2,"Jane Smith");
        candidates.Add(3,"Sirhan Sirhan");        
        
        votesList.Add(new int[]{1, 2 ,3});
        votesList.Add(new int[]{2, 1 ,3});
        votesList.Add(new int[]{2 ,3, 1});
        votesList.Add(new int[]{1 ,2 ,3});
        votesList.Add(new int[]{3, 1 ,2});

        //candidates.Add(4,"Allan Border");
       // votesList.Add(new int[]{4, 2 ,2});
    
 
        int[] wIndex=anyWinner(votesList, candidates);
            
        foreach(int w in wIndex)
        {
            Print( candidates[w] );
        }
        
    }       
         


    private int[] anyWinner(List<int[]> votesList,Dictionary<int,String> candidates,Dictionary<int,int> firstVotesCount=null)
    {       
        int candidatesCount = candidates.Count();       
        int voters = votesList.Count;
        //Keep track of a candidate's first choice vote count
        if(firstVotesCount==null)
        {
             firstVotesCount= new Dictionary<int,int>();  
             foreach(var candidate in candidates)
             {
                 firstVotesCount.Add(candidate.Key,0);
             }
             //read first choice votes for all candidates
            foreach (var votes in votesList)
            {        
                int candidateId= votes[0]; //First choice candidates index
                firstVotesCount[candidateId]++;   
              
                              
            }   
        } 
        
         //If only 2 candidates are left and  get exactly the same amount of votes - the it is a tie and return both

        int count =0;
        foreach (var firstVoteCount in firstVotesCount.Where(fvc =>fvc.Value!=-1))
        { 
            if((double)firstVoteCount.Value/(double)voters== 0.5)
            {
                    count++;
            }
              //if any candidates first choice vote count is more than 50% then return as winner
            if((double)firstVoteCount.Value/(double)voters >0.5)        
            {                  
                return new int[]{firstVoteCount.Key};
            } 
            
        }
        if(count==2 && candidatesCount==2)
        {
            return  new int[]{candidates.ElementAt(0).Key,candidates.ElementAt(1).Key};
        }
    
        
        //Now remove the candidates who get the least first choice votes 
        //Move the second choice selection of voters who voted for this candiadate to the remaining candidates
        int minFirstVotes = firstVotesCount.Values.Min() ;
        
        foreach (var firstVoteCount in firstVotesCount.Where(fvc =>fvc.Value==minFirstVotes))
        {  

                int  minfirstVoteCandidateId = firstVoteCount.Key;
                //Remove this candidate from the candidate's list
                candidates.Remove(minfirstVoteCandidateId);
                for (int k=0;k<votesList.Count();k++)
                {
                    //Voters who voted for the  min first Vote Candidate first choice
                    if((votesList[k]!=null) && (votesList[k][0]==minfirstVoteCandidateId))
                    {
                        //next available candidate preference
                        for(int m=1;m<votesList[k].Count();m++)
                        {
                            //if any of the next preference candidates are still in the list
                            if(candidates.ContainsKey(votesList[k][m]))
                            {
                                firstVotesCount[votesList[k][m]]++;
                                //the voter's choice matter no more
                                //as the first choice candidate has been removed
                                votesList[k] =null; 
                                break;

                            }
                            
                        }
                         
                    }
                }
                //first vote count for Candidates who got min votes
                firstVotesCount[firstVoteCount.Key]=-1;              
        }
        return anyWinner(votesList, candidates, firstVotesCount);                
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
/*NearestNeighbor(P)
    Pick and visit an initial point p0 from P
    p = p0
    i = 0
        While there are still unvisited points
            i = i + 1
            Select pi to be the closest unvisited point to pi−1
            Visit pi
    Return to p0 from pn−1
*/
        private void nearestneighbor(int n=10, int r=5)
        {
            double totaldistance =0;
            List<Point> visted = new  List<Point>();

            List<Point> p = ramdompointsongrid(n,r);    
            Print (p);
            Point start= p[0];        
            Point current=  start;
            p.Remove(current);            
            visted.Add(current);
            while (p.Count>0)
            {              
                              
                Tuple<Point,double> cp = closestpoint(current,p);
                totaldistance += cp.Item2;
                current = cp.Item1;
                visted.Add(current);
                p.Remove(current);

            }
            visted.Add(start);
            totaldistance += euclediandistance(start,current);
            Print(visted);
            Print(totaldistance);
        }

        private Tuple<Point,double> closestpoint(Point s, List<Point> u)
        {
             double d = double.MaxValue;
             Point selected= new Point();
             double dselected=0.0;
             foreach(Point p in u)
             {
                 double dist = euclediandistance(s, p);
                 if(dist<d)
                 {
                        selected = p;
                        dselected = dist;
                 }
             }
             return new Tuple<Point, double>(selected,dselected);
        }

        private void TSP()
        {
               int[] p = new int[] {0,1,2}; 
               List<int[]> lst = new List<int[]>();
               permutations(p,0,p.Count()-1,lst);
        }

        private void  permutations(int[] list, int k, int m ,List<int[]> permuatation)
        {
            if(permuatation==null)
            {
                permuatation = new List<int[]>();
            }
                int i;
                if (k == m)
                { 

                    for (i = 0; i <= m; i++)
                    {
                        Console.Write ("{0}",list [i]);
                        Console.Write (" ");
                    }


                    permuatation.Add(list);                     
                }
                else
                    for (i = k; i <= m; i++)
                    {
                        swapTwoNumber (ref list[k], ref list[i]);
                        permutations (list, k+1, m,permuatation);
                        swapTwoNumber (ref list[k], ref list[i]);
                    }
        }

        public void swapTwoNumber (ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private double euclediandistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X-b.X,2) + Math.Pow(a.Y-b.Y,2));
        }

        private List<Point> ramdompointsongrid(int n=10, int r=5)
        {
            List<Point>  p = new List<Point>();
            Random rand = new Random(); // creates a new random number generator with a time-based seed
            int X, Y;
            for(int i = 0; i < n; i++)
            {
                X = rand.Next(-r,r); 
                Y = rand.Next(-r,r); 
                p.Add(new Point(X,Y)); 
            }
            return p.Distinct().ToList();;
        }
    }
}