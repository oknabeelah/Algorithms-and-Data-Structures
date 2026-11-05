using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLL_Demo
{
    internal class SinglyLinkedList
    {
        public Node head;
        public SinglyLinkedList() {
            head = null;
        }
        public Boolean isEmpty()
        { 
            return head == null; 
        }
        public void insertFront(int item)
        {
            Node newNode = new Node(item);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }
        public void insertLast(int item)
        {
            Node newNode = new Node(item);
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
        public void insertAfter(int element, int item) 
        {
            Node pointer = head;
            Node prevPointer = head;
            Node newNode = new Node(item);
            if (head == null)
                Console.WriteLine("List is empty");
            else
            {
                while (pointer!=null && pointer.data != item)
                {
                    pointer = pointer.next;
                }
                if (pointer == null)
                    Console.WriteLine(element + "does't exists, cant insert " + item);
                else
                {
                    newNode.next = pointer.next;
                    pointer.next = newNode;
                    pointer = null;
                }
            }
        }

        public void removeItem(int item)
        {
            Node pointer = head;
            Node prevPointer = head;
            if (head == null)
                Console.WriteLine("City doesnt exists");
            else
            {
                while (pointer != null && pointer.data != item)
                {
                    prevPointer = pointer;
                    pointer = pointer.next;
                }
                if (pointer == null)
                    Console.WriteLine(item+ " does't exist in the list");
                else
                {
                        prevPointer.next = pointer.next;
                        pointer = null;
                }
                
            }
        }
        public int removeFront()
        {
            int item = head.data;
            Node temp = head;
            head = head.next;
            temp = null;
            return (item);
        }

        public void display()
        {
            Node pointer = head;
            if (pointer == null)
                Console.WriteLine("The list is empty");
            else
                while (pointer != null)
                {
                    Console.Write(pointer.data+"  ---> ");
                    pointer = pointer.next;
                }
            Console.WriteLine("Null");
        }

    }
}
