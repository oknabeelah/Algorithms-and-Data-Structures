using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizer
{
    internal class Node
    {
        public string studentName;
        public string eventCategory;
        public Node next;
        public Node(string name, string category)
        {

            studentName = name;
            eventCategory = category;
            next = null;
        }
    }
}
