public class DoublyLinkedList 
{
    public Node head;
	public Node tail;
	public int length=0;
	
    
	
	public void setHead (Node n) 
	{
		head = n;
		tail = n;
		length++;
		
	}
	
	
	public void insert (Node n) 
	{
		tail.next = n;
		n.previous = tail;
		tail = n; //move the tail node to the newly added node
		length++; //increament lenght
		
	}
	
	public void insertAfter (Node n, Node after) 
	{
		Node next = after.next; //get the existing next node before inserting the new node
		after.next = n; //linking the after node to n as next
		n.previous = after; //linking the n node to after as previous
		n.next = next; //linking the n node to the existing next as next
		next.previous = n; //linking the next node to n as previous
		length++;
	}
	
	public void insertBefore (Node n, Node before) 
	{
		Node previous = before.previous; //get the existing previous node before inserting the new node
		before.previous = n; //linking the before node to n as previous
		n.next = before; //linking the n node to before as next
		previous.next = n; //linking the previous node to n as next
		n.previous = previous; //linking the n node to existing previous node as previous
		length++;
	}
	
	
	public void remove (Node n) 
	{
		//if the head to be deleted
		if (head.data == n.data) 
		{
			head = head.next; //get the next of the head or the n becomes as head
			head.previous = null;
			length--;
		}
		else if (tail.data == n.data) 
		{
			tail = tail.previous;
			tail.next = null;
			length--;
		}

		else {
			Node current = head.next;
			Node previous = head;
			
			while (current!=null)
			{ 
				if(current.data == n.data) 
				{
					Node newCurrent = current.next; 
					previous.next = newCurrent; 
					newCurrent.previous = previous;
					length--;
				}
				previous = current;
				current = current.next;
			}
		}
	}
	
	public bool findNode (String x) 
	{
		bool res = false;
		Node current = head;

		if (current.data == x) 
		{
			res = true;
		}
		else 
		{
			for (int i=0; i<length-1; i++) 
			{
				current = current.next;
				
				if (current.data==x) 
				{
					res = true;
					break;
				}
			}
		}
		
		return res;
	}
	

	public static void printNodes (DoublyLinkedList nodes) 
	{
		
		Node current = nodes.head;
		Console.WriteLine("LinkedList: ");
		
		while(current!=null) {
			Console.WriteLine(current.data);
			if (current.next!=null && current.previous!=null) 
			{
				Console.Write("<=>");
			}
			
			else if(current.next!=null) 
			{
				Console.Write("=>");
			}
			current = current.next;
		}
		
	}

}
public class Node 
{
		public int key;
		public string data;
		public Node next;
		public Node previous;
		
	    public Node (int k, String d)
		{
			key = k;
			data = d;
			next = null;
			previous = null;
		}
}