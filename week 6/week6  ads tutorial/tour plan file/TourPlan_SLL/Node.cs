using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TourPlan_SLL
{
    internal class Node
    {
        public string data;
        public Node next;
        public Node(string item)
        {

            data = item;
            next = null;
        }
    }
}
