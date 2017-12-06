using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_2._2_Find_K
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeaderMsg(2, 2, "Find Kth From Last");

            Random rnd = new Random();

            Node head = CreateSinglyLinkedList(1000000);
            
            long ticks = FindKFromEnd(rnd.Next(1000000), head);
            Console.WriteLine("ticks " + ticks);
            Console.WriteLine();

            ticks = FindKFromEnd(rnd.Next(1000000), head);
            Console.WriteLine("ticks " + ticks);
            Console.WriteLine();

            ticks = FindKFromEnd(rnd.Next(1000000), head);
            Console.WriteLine("ticks " + ticks);
            Console.WriteLine();

            Console.ReadLine();
        }

        //////////////////////////////////////////////////////////////
        //        
        // 1. Run through the linked list, counting nodes
        // 2. Run through the linked list, X nodes 
        //    (where x is K-From-End minus total nodes)
        // 3. Display result
        //
        // Note: "1 from end" is 2nd to last.  "2 from end" is third.
        // 
        // Complexity: Algorithm runs in O(N) time
        //             Every element is checked once to count, then 
        //             again to find the K-element. Worst case O(2N) 
        //             which is O(N) (drop the constant)
        //
        //             Algorithm requires O(1) space
        //             Memory requirements are constant regardless
        //             of input.
        //
        private static long FindKFromEnd(int k_from_end, Node passed_head)
        {
            Stopwatch sw = Stopwatch.StartNew();
                        
            Node runner = passed_head;

            int count_of_nodes = 0;
            while (runner != null)
            {
                ++count_of_nodes;
                runner = runner.next;
            }

            runner = passed_head;

            for (int i = 0; i < (count_of_nodes - k_from_end - 1); ++i)
            {
                runner = runner.next;
            }

            Console.WriteLine("Node Found!");
            Console.WriteLine("The " + k_from_end + " node from the end has data: " + runner.Data);

            sw.Stop();
            return sw.ElapsedTicks;
        }

        private static Node CreateSinglyLinkedList(int count)
        {
            if (count < 1)
                return null;

            Random rnd = new Random();

            Node head = new Node(rnd.Next(0, 1000));

            Node n = head;

            for (int i = 0; i < count - 1; ++i)
            {
                n.next = new Node(rnd.Next(0, 1000));
                n = n.next;
            }

            return head;
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }

    class Node
    {
        public Node next = null;

        public int Data;

        public Node(int d) => Data = d;
    }
}
