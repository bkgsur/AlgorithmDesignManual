using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmDesignManual
{
    public  class C3DataStructures : Helper, IRun
    {
        public void Run()
        {
            /* #region Linked List*/
             /*SingleLinkedList l = buildll();
             ReveresLL( l );
             Display( l);
             Node m  = middlell(l);
             Print(m.data);
             l.Print( searchllR( l.head,  8));
             Delete ( l, 9);
             Display( l);             
            Print(checkloopll());*/
            /* #endregion*/

            /* #region Stack and Queue */
            /*Print(checkparanthesis("((())())()"));
            Print(checkparanthesis(")()("));
            Print(checkparanthesis("())"));
            Print(checkparanthesis(")"));
            Print(reverseline("my name is jill"));*/
              /* #endregion */
            /* #region BST*/
            BinaryTree tree = new BinaryTree();
            //tree.root = sortedArrayToBST(new int[] {1,2,3});
            //DisplayInOrder(tree.root);

            tree.root = InsertBSTNodes(new int[] {1,2,3,4,5,6}) ;
            DisplayInOrder(tree.root);
           // Print(SearchBST(tree.root,1).data);
            /* #endregion*/
        }

    /*  #region BST */
        
        private BinaryTreeNode SearchBST(BinaryTreeNode node, int x)
        {
                if(node == null)
                {
                    return null;
                }
                if(node.data==x)
                {
                    return node;
                }

                if(x<node.data)
                {
                    return (SearchBST(node.left, x));
                }
                else
                {
                     return (SearchBST(node.right, x));
                }
        }

       private BinaryTreeNode InsertBSTNodes( int[] arr)       
       {
           BinaryTreeNode root =null;
           root = InsertBSTNode(root, arr[0]);
           for(int i=1;i<arr.Length;i++)
           {
               InsertBSTNode(root, arr[i]);
           }
           return root;

       }

       private BinaryTreeNode InsertBSTNode(BinaryTreeNode root,int a)       
       {
           BinaryTreeNode x= root;
           BinaryTreeNode y = null; //Record parent

           while (x!=null)
           {
               y = x;
               if(a<y.data)
               {
                   x= x.left;
               }
               else
               {
                   x= x.right;
               }

           }
           BinaryTreeNode n = new BinaryTreeNode(a);

           if(y==null)//empty root node
           {
               y= n;
           }
           else if(a<y.data)
           {
               y.left=n;
           }
           else
           {
               y.right = n;
           }
           return y;
           
       }

        private  BinaryTreeNode sortedArrayToBST(int[] arr, int? start=null, int? end=null) 
        { 
            if(!start.HasValue)
            {
                start=0;
            }

            if(!end.HasValue)
            {
                end = arr.Length-1;
            }          

            if(start>end)
            {
                return null;
            }
            
            int mid = start.Value + (end.Value-start.Value)/2;
            BinaryTreeNode t = new BinaryTreeNode(arr[mid]);

            //left node;
            t.left = sortedArrayToBST(arr,start,mid-1);
            t.right = sortedArrayToBST(arr,mid+1,end);

            return t;

        }
        internal void DisplayInOrder(BinaryTreeNode node)
        {
            
            if (node!=null)
            {
                DisplayInOrder(node.left);
                Console.Write(node.data);
                DisplayInOrder(node.right);
            }
        }



    /*  #endregion  */

       /*  #region Stack */
        private string reverseline(string s)
        {
            StringBuilder current = new StringBuilder();
            Stack<String> st = new Stack<string>();
            foreach (char c in s)
            {
                if (!string.IsNullOrWhiteSpace(c.ToString()))
                {
                    current.Append(c.ToString());
                }
                else
                {
                    st.Push(current.ToString());
                    current.Clear();
                }
            }
            if (current.Length > 0)
            {
                st.Push(current.ToString());
            }
            return string.Join(" ", st);
        }
        private bool checkparanthesis(String s)
        {
            Stack<char> c = new Stack<char>();
            foreach (char i in s)
            {
                if (i == '(')
                {
                    c.Push(i);
                }
                else
                {
                    if (c.Count > 0)
                    {
                        c.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (c.Count > 0)
            {
                return false;

            }
            return true;
        }
        /*  #endregion  */

        /* #region Linked List*/  

        private bool checkloopll()
        {
            SingleLinkedList l = new SingleLinkedList();
            l = InsertLast(new int[] { 1, 2, 3, 4, 5 });
            Display(l);

            Node fast = l.head;
            Node slow = l.head;

            while (slow != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast != null && slow.data == fast.data)
                {
                    return true;
                }
            }
            return false;

        }
        private SingleLinkedList buildll()
        {
            SingleLinkedList l = InsertLast(2);
            l = InsertFirst(1, l);
            l = InsertLast(3, l);

            l = InsertLast(4, l);
            l = InsertFirst(0, l);
            l = InsertLast(new int[] { 5, 6, 7, 8 }, l);
            return l;
        }



        private Node searchll(SingleLinkedList l, int i)
        {

            Node temp = l.head;
            while (temp != null)
            {
                if (temp.data == i)
                {
                    return temp;
                }
                temp = temp.next;
            }

            return null;
        }
        private Node searchllR(Node n, int i)
        {

            if (n == null)
            {
                return null;
            }
            if (n.data == i)
            {
                return n;
            }
            else
            {
                return searchllR(n.next, i);
            }
        }

        private Node predecessor(Node n, int i)
        {
            if (n == null || n.next == null)
            {
                return null;
            }
            if (n.next.data == i)
            {
                return n;
            }
            else
            {
                return predecessor(n.next, i);
            }
        }

        private void Delete(SingleLinkedList l, int i)
        {
            //Check node exists
            var n = searchll(l, i);
            if (n != null)
            {
                var p = predecessor(l.head, i);
                if (p == null)
                {
                    l.head = n.next;
                }
                else
                {
                    p.next = n.next;
                }

            }

        }

        private SingleLinkedList InsertFirst(int i, SingleLinkedList l = null)
        {
            Node newNode = new Node(i);
            if (l == null)
            {
                l = new SingleLinkedList();
            }

            Node temp = l.head;
            l.head = newNode;
            l.head.next = temp;
            return l;


        }
        private SingleLinkedList InsertLast(int[] ii, SingleLinkedList l = null)
        {
            if (l == null)
            {
                l = new SingleLinkedList();
            }
            foreach (int i in ii)
            {
                l = InsertLast(i, l);
            }
            return l;
        }
        private SingleLinkedList InsertLast(int i, SingleLinkedList l = null)
        {
            Node newNode = new Node(i);
            if (l == null)
            {
                l = new SingleLinkedList();
            }

            Node temp = l.head;
            if (temp == null)
            {
                l.head = newNode;
            }
            else
            {
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
            }



            return l;
        }

        private void ReveresLL(SingleLinkedList l)
        {
            Node prev = null;
            Node next = null;
            Node curr = l.head;
            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            l.head = prev;
        }

        private Node middlell(SingleLinkedList l)
        {
            Node fast = l.head;
            Node slow = l.head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        private void Display(SingleLinkedList l) 
        {
            Node h = l.head;
            while (h != null)
            {
                Console.Write(h.data + " - ");
                h = h.next;

            }
            Console.WriteLine();

            Console.WriteLine("=================");
        } 
        
        /* #endregion */

    }


    internal class BinaryTree:Helper
    {
        internal BinaryTreeNode root;
        
    }
    internal class BinaryTreeNode
    {   
        internal int data;
        internal BinaryTreeNode parent;
        internal BinaryTreeNode right;
        internal BinaryTreeNode left;

        public  BinaryTreeNode()
        {
        }
        public  BinaryTreeNode(int data)
        {
            this.data= data;
        }


    }

    internal class SingleLinkedList
    {
        internal Node head;

        internal void Print(Node n)
        {
            if (n == null)
            {
                Console.WriteLine("No node!!");
            }
            else
            {
                Console.WriteLine(n.data);
            }
        }


    }
    internal class Node
    {
        internal int data;
        internal Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }


}