﻿using System;

namespace AlgorithmDesignManual
{
    public class Program
    {
        static void Main(string[] args)
        {
           IRun run ;
           //run= new C1Intro();
           //run= new C2AlgorithmAnalysis();
          // run= new C3DataStructures();
           //run= new C4SortSearch();
           run = new DP.C8DynamicProgramming();
           run.Run();
        }
    }
}
