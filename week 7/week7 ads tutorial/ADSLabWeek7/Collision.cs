public class Collision
{
    public static void insert (int key, String name, DoublyLinkedList [] myTable) 
	{
		
		int index = hashFunction (key, myTable);
		DoublyLinkedList dll = new DoublyLinkedList();
		//DoublyLinkedList.Node n = new DoublyLinkedList.Node(key, name);
		Node n = new Node(key, name);
		
		if (!collision(index, myTable))  //if  no collision do this
		{
			dll.setHead(n);
			myTable [index] = dll;
		}
		else 
		{
			dll = myTable[index];
			dll.insert(n);
		}
	}
	
	public static int hashFunction (int key, DoublyLinkedList [] myTable) 
	{
		int index = key%myTable.Length;
		return index;
	}
	
	public static bool collision (int index, DoublyLinkedList [] myTable) 
	{
		bool coll = false;
		if (myTable[index]!=null) 
		{
			coll = true;
		}
		return coll;
	} 

	public static void printData (DoublyLinkedList [] myTable) 
	{
		for (int i = 0; i<myTable.Length; i++) 
		{
			Console.WriteLine("Index "+i+" : ");
			if (myTable[i]!=null) 
			{
				Console.WriteLine("There are "+myTable[i].length+ " record/s");
				DoublyLinkedList.printNodes(myTable[i]);
			}
			else 
			{
				Console.Write("No record here!");
			}
			
			Console.WriteLine("\n");
		}
	}
	
	public static bool findNode(int key, DoublyLinkedList [] myTable) 
	{
		
		int index = hashFunction(key, myTable);
		bool found = false;
		
		DoublyLinkedList n = myTable[index]; //the element in the table is of this class.
		
		if (n!=null) 
		{

			Node head = n.head; //get the node
			if (head.key == key)
			{
				found = true;
			}
			else
			{
				while (head.key != key && head.next !=null) 
				{
					head = head.next;
					if(head.key == key) {
						found = true;
						break;
					}	
				}
			}
		}
		return found;
	}

}