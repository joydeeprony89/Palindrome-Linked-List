using System;

namespace Palindrome_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode root = new ListNode(1);
            root.next = new ListNode(2);
            root.next.next = new ListNode(2);
            root.next.next.next = new ListNode(1);
            Solution s = new Solution();
            var answer = s.IsPalindrome(root);
            Console.WriteLine(answer);
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null) return true;
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // when no of nodes are odd
            // e.g - 1,2,3,2,1
            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow = Reverse(slow);

            fast = head;
            while (slow != null)
            {
                if (slow.val != fast.val) return false;
                slow = slow.next;
                fast = fast.next;
            }

            return true;
        }

        private ListNode Reverse(ListNode node)
        {
            ListNode prev = null;
            while (node != null)
            {
                var next = node.next;
                node.next = prev;
                prev = node;
                node = next;
            }
            return prev;
        }
    }
}
