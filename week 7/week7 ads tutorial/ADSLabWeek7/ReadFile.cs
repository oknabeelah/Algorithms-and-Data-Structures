public class ReadFile 
{

    public static string [,] readCSV ()
    {
        string filename = "C:\\Users\\c3030385\\OneDrive - Sheffield Hallam University\\week7 ads tutorial\\ADSLabWeek7\\iso-country-codes.csv"; //C:\Users\c3030385\OneDrive - Sheffield Hallam University\week7 ads tutorial\ADSLabWeek7\iso-country-codes.csv

        StreamReader sr = null;
        string [,] data = null;
        //array of size 242

        if (File.Exists(filename)) //returning false, edit now trueee
        {
            sr = new StreamReader(File.OpenRead(filename));
            string line = null;
            int row = 0, col = 0;  //row = 242 ?? edit, goes back to 0 after 243 5

            //since we use array data structure, we need to know the size for row and col.
            while (!sr.EndOfStream)  //returning false
            {
                row++;
                line = sr.ReadLine();
                var val = line.Split(',');
                col = val.Length;
            }
           
           data = new string[row-1,col];  //to exclude header file

           sr = new StreamReader(File.OpenRead(filename));
           int i = 0;  //counter?? edit passing as 242, then 0 after stepping over
           while(!sr.EndOfStream)
           {
                var ln = sr.ReadLine();
                var val = ln.Split(','); ///reads header here first
                
                for (int j=0; j<val.Length; j++) //(int j=0; j<val.Length; j++), change to start after the heding
                {
                    //if (i > 0) //not going into if loop
                    //{
                    //exclude the heading
                    if (i > 0) //i > 1 removes 1, but since it reads backward its removing a record not the header, how to read prperlyy
                        data[i-1, j] = val[j]; //TO RESTORE FIRST INDEX AS 0 AFTER REMOVING   HEADER
                    
                    //}
                }
                i++;
            }
            return data;
        }
       return data;
    }


    public static void printArray (string [,] data)
    {
       for(int i=0; i<data.GetLength(0); i++)
       {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write(data[i,j]);
                Console.Write(" ");
            }
            Console.WriteLine();
       } 
    }



}