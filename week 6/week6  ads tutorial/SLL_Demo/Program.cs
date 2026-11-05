namespace SLL_Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SinglyLinkedList myList = new SinglyLinkedList();
            Console.WriteLine(myList.isEmpty());

            myList.insertFront(6);
            myList.insertFront(4);

            myList.display();
            myList.insertLast(8);
            myList.insertLast(5);
            myList.insertLast(3);
            myList.display();

            myList.insertAfter(16, 17);
            myList.display();

            myList.removeFront();
            myList.display();

            myList.removeItem(5);
            myList.display();

            myList.removeItem(15);
            myList.display();


        }
    }
}