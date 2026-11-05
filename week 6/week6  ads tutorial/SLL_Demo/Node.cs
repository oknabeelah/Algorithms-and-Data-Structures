using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLL_Demo
{
    internal class Node
    {
        public int data;
        public Node next;
        public Node(int item) 
        { 
            data = item;
            next = null;
        }
    }
}
