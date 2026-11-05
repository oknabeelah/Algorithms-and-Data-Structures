using System.Collections;
using System.Collections.Generic;
using TourPlan_SLL;

internal class Program
{
    private static void Main(string[] args)
    {
        SinglyLinkedList tour = new SinglyLinkedList();
        
        tour.insertLast("London");
        tour.insertLast("Oxford");
        tour.insertLast("Birmingham");
        tour.insertLast("Manchester");        
        tour.display();

        tour.removeCity("Birmingham");
        tour.display();        
        tour.insertLast("York");
        tour.display();


    }
}