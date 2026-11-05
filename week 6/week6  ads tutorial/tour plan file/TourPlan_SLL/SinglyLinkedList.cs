using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TourPlan_SLL;

namespace TourPlan_SLL
{
    internal class SinglyLinkedList
    {
        public Node head;
        public SinglyLinkedList() //constructor without parameter 
        {
            head = null;
        }        
        public void insertLast(string city) 
        {
            // Write Your code here to insert the city (given in parameter) at the end of the list
            Node newNode = new Node(city);
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
       

        public void removeCity(string city)
        {
            // Write your code here to remove the city given in parameter
            Node pointer = head;
            Node prevPointer = head;
            if (head == null)
                Console.WriteLine("City doesnt exists");
            else
            {
                while (pointer != null && pointer.data != city)
                {
                    prevPointer = pointer;
                    pointer = pointer.next;
                }
                if (pointer == null)
                    Console.WriteLine(city + " does't exist in the list");
                else
                {
                    prevPointer.next = pointer.next;
                    pointer = null;
                }

            }
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
                Console.Write(pointer.data + "----> ");
                pointer = pointer.next;
            }
            Console.WriteLine("Null\n");
        }
    }
}
