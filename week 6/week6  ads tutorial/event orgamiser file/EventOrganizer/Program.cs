using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace EventOrganizer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SinglyLinkedList eventList = new SinglyLinkedList();

            //Insert three nodes into the list. Display the event list with then name and event category registered by the student.
            eventList.insertLast("Jaya", "Song");
            // insert two more nodes
            eventList.display();

            //Now add five students, each wish to perform a different event category.
            
            //eventList.display();

            //Read the name of a student from console and remove the performance registered by that student.
            //eventList.removeNode(" "); //GIve a name of your interest
            
            //eventList.display();

            //Read the name of a student who had registered for a song. Modify thatstudent's song performance to a dance performance.
            //eventList.changePerformance("Jaya", "Dance");
            //eventList.display();

            //Exchange the second performance in the list with the last performance.
            //eventList.swapPerformance();
            //eventList.display();

            //Display the complete event list after these modifications.
            //Console.WriteLine("Complete event list is:");
            //eventList.display();

            //Display the count of the number of song performances, dance performances, and stand-up comedy performances.
            //Console.WriteLine(eventList.howMany());

        }
    }
}