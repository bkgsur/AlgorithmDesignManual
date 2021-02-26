    using System;
using System.Collections.Generic;
using System.Linq;


namespace AlgorithmDesignManual
{

    public class priority_queue
    {
        public int QueueSize { get;set;}

        public int n { set; get;}// index of last element

        public int[] q { get;set;}

        public priority_queue(int size)
        {
            QueueSize = size;
            q = new int[QueueSize];
            n=0;
        }

    }

public class MinHeap:Helper 
{
        priority_queue pq;
        public MinHeap()
        {
            pq = new priority_queue(10);
        }
        private int pq_parent(int n)
        {
            if(n==0)
            {
                return -1;
            }
            return n/2; //floor value
        }

        private int pq_young_child(int n) //left child
        {
            return (2*n + 1);
        }

        private void pq_insert(priority_queue q, int x)
        {
            if(q.n>=q.QueueSize)
            {
                throw new Exception("Filled !!!");
            }            
            q.q[q.n]=x;           
            bubble_up(q,q.n);
            q.n+=1;
        }
        private void bubble_up(priority_queue q, int p)
        {
               if(pq_parent(p)==-1)
               {
                   return;
               }                
               if(q.q[pq_parent(p)]> q.q[p]) //parent is larger than child
               {
                   Swap<int>(q.q,p,pq_parent(p));
                   bubble_up( q,  pq_parent(p));
               }
        }

        public void make_heap(priority_queue q, int[] s)
        {
            int n = s.Length-1;

            for(int i=0;i<=n;i++)
            {
                pq_insert(q, s[i]);
            }
        }
    }


}