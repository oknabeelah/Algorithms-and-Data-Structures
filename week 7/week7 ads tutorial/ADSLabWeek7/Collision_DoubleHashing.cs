public class Collision_DoubleHashing
{
    public static void insert (int key, string name, string [] myTable)  //inser method uh
	{
		
		int i = 0;
		int index = hashFunction(key, i, myTable);  //method to get the hash funct
		
		while (collision(index, myTable)==true) //when needed double hasing
		{
			i++;//increment the i for the next interation if there is collision
			index = hashFunction(key, i, myTable); //get the first hash with i incremented
            // just repear the outside the wqhile loop
            index += doubleHash (key); //get the second hash and product with the first hash
			//add offset of double hashing
			index %= myTable.Length;  //not sure what this does!!!!
			//Console.WriteLine(i);
			
		}
		myTable[index] = name;
	}
	
	public static int hashFunction (int key, int i, string [] myTable)  //
	{
		int index = (key%myTable.Length)+i; //just the basics hash function
		return index;
	}
	
	public static int doubleHash (int key)  //a bit confusious
	{
		 //int index = 3 - (key%3); //why 3, edit: tutorial specified change to 7
		 int index = 7 - (key%7);
		 return index;
	}
	
	public static bool collision (int index, string [] myTable) //public static Boolean collision (int index, string [] myTable) 
    {
		bool col = false;
		if (myTable[index]!=null)  //just like befor
		{
			col = true;
		}
		return col;
	}
	
	public static void printData (string [] myTable)  //pretty much same
	{
		for (int i = 0; i<myTable.Length; i++) {
			Console.WriteLine(myTable[i]);
			Console.WriteLine();
		}
	}

}