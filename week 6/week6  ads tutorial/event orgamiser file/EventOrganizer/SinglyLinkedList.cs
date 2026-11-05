using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizer
{
    internal class SinglyLinkedList
    {
        public Node head;
        public SinglyLinkedList()
        {
            head = null;
        }
        public void insertLast(string name, string category)
        {
            // Write your code here to insert a node with the student name and category as eventCategory at the endof the list.[
            Node newNode = new Node(name, category);
            Node pointer = head;
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                while (pointer.next != null)
                {
                    pointer = pointer.next;
                }
                pointer.next = newNode;
            }
        }

        public void removeNode(string name) 
        {
            // Write your code to removes the node with the studentName as given name in the parameter
        }

        public void changePerformance(string name, string newPerformance) 
        {
            // Write your code to change the eventCategory of the student in the list to newPerformance

        }

        public void swapPerformance() 
        {
            // Write your code to swap the second performance with last
        }

        public void display()
        {
            Node pointer = head;
            if (pointer == null)
            {
                Console.WriteLine("List empty \n");
                return;
            }

            while (pointer != null)
            {
                Console.Write(pointer.studentName + "-" + pointer.eventCategory + "---->");
                pointer = pointer.next;
            }
            Console.WriteLine("Null\n");
        }

        public int howMany()
        {
            Node pointer = head;
            int cnt = 0;           

            while (pointer != null)
            {
                cnt++;
                pointer = pointer.next;
            }
            return cnt;
        }
    }
}
