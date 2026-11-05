public class Collision_LinearProbing
{
    public static int hashFunction (int key, string [] myTable) //maybe pass the lenght instead
	{ 
		int index = -1; //initialise with value it cant be 
		index = key % myTable.Length;	//formule	
		return index;
	}
	//refactoring code: reoorganising, rewriting program without changing/affecting the output

	public static void insert (int key, String name, string [] myTable) //method to add an item to the hash list (item is name and key pair)
	{
		//get the index to store the name using hash function
		int index = hashFunction(key, myTable);
		int i = 1;
		while (collision(index, myTable)==true)  //calling collision bool method below, to make sure index is empty, if not do while
		{
			index = probLinear (key, i, myTable); //rewrite the hashing function to account for collision via linear probing formulae
			i++;
		}
		myTable [index] = name;  //insert rhe name to the index
	}
	
	public static int probLinear (int key, int i, string [] myTable)  //to devise index using linear probing, adding to the key by ... before hashing
	{
		int index = (key+i) % myTable.Length; // i? 
		return index; //...(repeat if this index is filled until you get one that isnt) determines i
    }
	
	public static bool collision (int index, string [] myTable) //public static Boolean collision (int index, string [] myTable) 
    {
		bool col = false; //ddefaulty
		if (myTable[index]!=null) //if the index called in question is not empty
		{
			col = true;
		}
		return col;
	}
	
	public static void printData (string [] myTable) //display the hash table
	{
		for (int i = 0; i<myTable.Length; i++)  //iterate through table lenght
		{
			Console.WriteLine(myTable[i]); //why not \n 
			Console.WriteLine();
		}
	}
}