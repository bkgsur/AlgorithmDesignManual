using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmDesignManual;


namespace AlgorithmDesignManual.DP
{
    public class ApproxStringMatching : Helper, IRun
    {
        const int MATCH = 0;
        const int INSERT = 1;
        const int DELETE = 2;

        const int MAXLEN = 5;

        Cell[][] m;
        public ApproxStringMatching()
        {
            m = init_matrix2<Cell>(MAXLEN, MAXLEN); //adds MAXLEN+1 dimension
        }


        public void Run()
        {
            var s = new char[] { 'a', 'b', 'c', 'd' };
            var t = new char[] { 'a', 'b', 'c' };
            Print(string_compare_dp(s, t));
        }

        private int string_compare(char[] s, char[] t, int i, int j)
        {
            int k;
            int[] opt = new int[3];
            int lower_cost;

            if (i == 0)
            {
                return j * indel('/');
            }
            if (j == 0)
            {
                return i * indel('/');
            }

            opt[MATCH] = string_compare(s, t, i - 1, j - 1) + match(s[i], t[j]);
            opt[INSERT] = string_compare(s, t, i, j - 1) + indel(t[j]);
            opt[DELETE] = string_compare(s, t, i - 1, j) + indel(s[j]);

            lower_cost = opt[MATCH];

            for (k = INSERT; k <= DELETE; k++)
            {
                if (opt[k] < lower_cost)
                {
                    lower_cost = opt[k];
                }
            }

            return lower_cost;
        }



        public int string_compare_dp(char[] s, char[] t)
        {
            int i, j, k;
            int[] opt = new int[3];

            for (i = 0; i < MAXLEN; i++)
            {
                row_init(i);
                column_init(i);
            }
            for (i = 1; i <= s.Length; i++)
            {
                for (j = 1; j <= t.Length; j++)
                {
                    opt[MATCH] = m[i - 1][j - 1].cost + match(s[i - 1], t[j - 1]);
                    opt[INSERT] = m[i][j - 1].cost + indel(t[j - 1]);
                    opt[DELETE] = m[i - 1][j].cost + indel(s[i - 1]);

                    m[i][j].cost = opt[MATCH];
                    m[i][j].parent = MATCH;

                    for (k = INSERT; k <= DELETE; k++)
                    {
                        if (opt[k] < m[i][j].cost)
                        {
                            m[i][j].cost = opt[k];
                            m[i][j].parent = k;
                        }
                    }
                }
            }
            var gc = goal_cell(s, t);
            reconstruct_path(m, s, t, gc.Item1, gc.Item2);
            return m[gc.Item1][gc.Item2].cost;
        }

        private void reconstruct_path(Cell[][] m, char[] s, char[] t, int i, int j)
        {
            if (m[i][j].parent == -1) return;
            if (m[i][j].parent == MATCH)
            {
                reconstruct_path(m, s, t, i - 1, j - 1);
                match_out(s, t, i, j);
                return;

            }
            if (m[i][j].parent == INSERT)
            {
                reconstruct_path(m, s, t, i, j - 1);
                insert_out(t, j);
                return;

            }
            if (m[i][j].parent == DELETE)
            {
                reconstruct_path(m, s, t, i - 1, j);
                delete_out(s, i);
                return;

            }
        }
        private void row_init(int i)
        {
            m[0][i].cost = i; //first row of matrix;
            if (i > 0)
            {
                m[0][i].parent = INSERT; //insert new characters to make up for empty source 

            }
            else
            {
                m[0][i].parent = -1;
            }

        }

        private void column_init(int i)
        {
            m[i][0].cost = i;

            if (i > 0)
            {
                m[i][0].parent = DELETE;
            }
            else
            {
                m[i][0].parent = -1;
            }
        }

        private int match(char c, char d)
        {
            if (c == d) return (0);
            else return (1);
        }

        private int indel(char c)
        {
            return 1;
        }

        private Tuple<int, int> goal_cell(char[] s, char[] t)
        {
            return new Tuple<int, int>(s.Length, t.Length);
        }

        private void match_out(char[] s, char[] t, int i, int j)
        {
            if (s[i - 1] == t[j - 1])
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
        private void delete_out(char[] s, int i)
        {
            Print("D");
        }



        private class Cell
        {
            public int cost { get; set; }
            public int parent { get; set; }

        }
    }


}