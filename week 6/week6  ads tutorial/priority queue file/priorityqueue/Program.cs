using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace priorityqueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            PriorityQueueList priorityList = new PriorityQueueList();

            priorityList.insertItem("job1", 2);
            priorityList.insertItem("job2", 1);
            priorityList.insertItem("job3", 3);
            priorityList.insertItem("job4", 3);
            priorityList.insertItem("job5", 4);
            priorityList.insertItem("job6", 3);
            priorityList.insertItem("job7", 6);

            priorityList.display();
        }
    }
}
