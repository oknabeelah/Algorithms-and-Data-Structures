using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace priorityqueue
{
    internal class Node
    {
        public int priority;
        public string Job;
        public Node next;
        public Node(string jobname, int item)
        {
            priority = item;
            Job = jobname;
            next = null;
        }
        
    }
}
