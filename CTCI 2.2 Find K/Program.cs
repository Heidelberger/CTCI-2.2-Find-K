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

            Node head = CreateSinglyLinkedList(1000);

            int next = rnd.Next(1000);
            FindKFromEnd_Iterative(next, head, Stopwatch.StartNew());
            FindKFromEnd_IterativeSpacing(next, head, Stopwatch.StartNew());
            FindKFromEnd_Recursive(next, head, Stopwatch.StartNew());

            next = rnd.Next(1000);
            FindKFromEnd_Iterative(next, head, Stopwatch.StartNew());
            FindKFromEnd_IterativeSpacing(next, head, Stopwatch.StartNew());
            FindKFromEnd_Recursive(next, head, Stopwatch.StartNew());

            next = rnd.Next(1000);
            FindKFromEnd_Iterative(next, head, Stopwatch.StartNew());
            FindKFromEnd_IterativeSpacing(next, head, Stopwatch.StartNew());
            FindKFromEnd_Recursive(next, head, Stopwatch.StartNew());

            next = rnd.Next(1000);
            FindKFromEnd_Iterative(next, head, Stopwatch.StartNew());
            FindKFromEnd_IterativeSpacing(next, head, Stopwatch.StartNew());
            FindKFromEnd_Recursive(next, head, Stopwatch.StartNew());

            next = rnd.Next(1000);
            FindKFromEnd_Iterative(next, head, Stopwatch.StartNew());
            FindKFromEnd_IterativeSpacing(next, head, Stopwatch.StartNew());
            FindKFromEnd_Recursive(next, head, Stopwatch.StartNew());

            next = rnd.Next(1000);
            FindKFromEnd_Iterative(next, head, Stopwatch.StartNew());
            FindKFromEnd_IterativeSpacing(next, head, Stopwatch.StartNew());
            FindKFromEnd_Recursive(next, head, Stopwatch.StartNew());

            Console.ReadLine();
        }

        //////////////////////////////////////////////////////////////
        //        
        // 1. If the current node isn't the last, recurse on next node
        // 2. Once the last node is found, return an incremented value        
        // 3. If the incremented value = k-from-end, print info
        //
        // Note:       "1 from end" is 2nd to last.  "2 from end" is
        //             third.
        //
        // Note:       Recursive solution causes stack overflow for
        //             lists over 1500ish items.  Larger lists should
        //             use iterative solution.
        // 
        // Complexity: Algorithm runs in O(N) time
        //             Every element is checked once to count, then 
        //             again back to the K-element. Worst case O(2N) 
        //             which is O(N) (drop the constant)
        //
        //             Algorithm requires O(N) space
        //             Each node in the list requires a recursive call
        //             which requires a frame on the stack.
        //
        private static int FindKFromEnd_Recursive(int k_from_end, Node passed_node, Stopwatch sw)
        {
            int val = 0;

            // call recursively until end is found
            if (passed_node.next != null)
            {
                val = FindKFromEnd_Recursive(k_from_end, passed_node.next, sw);
            }

            // return value unspools the stack of recursive calls until k_from_end is found
            if (val == k_from_end)
            {
                sw.Stop();

                Console.WriteLine("Recursive:         The " + k_from_end + " node from the end has data: " + passed_node.Data + " (" + sw.ElapsedTicks + " ticks)");
                Console.WriteLine();
            }

            return ++val;
        }

        //////////////////////////////////////////////////////////////
        //        
        // 1. Run through the linked list, counting nodes
        // 2. Run through the linked list, X nodes 
        //    (where x is K-From-End minus total nodes)
        // 3. Display result
        //
        // Note:       "1 from end" is 2nd to last.  "2 from end" is 
        //             third.
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
        private static void FindKFromEnd_Iterative(int k_from_end, Node passed_head, Stopwatch sw)
        {               
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

            sw.Stop();
                        
            Console.WriteLine("Iterative 2-pass:  The " + k_from_end + " node from the end has data: " + runner.Data + " (" + sw.ElapsedTicks + " ticks)");
        }

        //////////////////////////////////////////////////////////////
        //        
        // 1. Run through the linked list using runner_fast, counting 
        //    nodes up to k-from-end
        // 2. Continue, incrementing both runner_fast and runner_slow
        //    until runner_fast is at the last node in the list        
        // 3. runner_slow is now k-from-end nodes from the end. 
        //    Display result
        //
        // Note:       "1 from end" is 2nd to last.  "2 from end" is 
        //             third.
        // 
        // Complexity: Algorithm runs in O(N) time
        //             Every element is checked once
        //
        //             Algorithm requires O(1) space
        //             Memory requirements are constant regardless
        //             of input.
        //
        private static void FindKFromEnd_IterativeSpacing(int k_from_end, Node passed_head, Stopwatch sw)
        {
            Node runner_slow = passed_head;
            Node runner_fast = passed_head;

            for (int i = 0; i < k_from_end; ++i)
            {
                if (runner_fast.next == null)
                    throw new Exception("K-from-end is greater than the number of nodes in list.");

                runner_fast = runner_fast.next;
            }
            
            // runner_slow is now k_from_end nodes behind runner_fast
            // continue through list until end is found

            while (runner_fast != null)
            {            
                runner_fast = runner_fast.next;
                runner_slow = runner_slow.next;
            }           

            // runner_slow is now k_from_end nodes from the end of the list

            sw.Stop();
            
            Console.WriteLine("Iterative Spacing: The " + k_from_end + " node from the end has data: " + runner_slow.Data + " (" + sw.ElapsedTicks + " ticks)");
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
