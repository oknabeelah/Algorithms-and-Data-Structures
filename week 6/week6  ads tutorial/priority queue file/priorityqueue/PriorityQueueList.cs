using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace priorityqueue
{
    internal class PriorityQueueList
    {
        //inseertion
        //removsl
        //displaj
        public Node head;
        public PriorityQueueList()
        {
            head = null;
        }
        public void insertItem(string name, int priority) 
        {
            //check priorit with head, if > check next until < then add before the item index
            //if > than head, make new head
            Node newNode = new Node(name, priority);
            Node pointer = head;
            if (head == null) 
            { 
                head = newNode;
                //check prioritty value
                //while temp.priority is > n2priority and temp = node.next 
                // use whilo loop because we dont know the size
            }
            else 
            {
                Node next = pointer.next;
                if (pointer.priority>newNode.priority && next.priority < newNode.priority)
                {
                    pointer.next = newNode;
                    newNode.next = next;
                }
                else
                {

                }
                
            }
           
        }
        public int checkItemPriority(string name) 
        {
            Node pointer = head;
            int priority = 0;
            
            while (head != null) 
            {
                priority++;
                pointer = pointer.next;
            }
            return priority; 
        }
        public void removeItem(string name) 
        {
           
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
                Console.Write(pointer.Job + "-" + pointer.priority + "---->\n");
                pointer = pointer.next;
            }
            Console.WriteLine("Null\n");
        }
    }
}
