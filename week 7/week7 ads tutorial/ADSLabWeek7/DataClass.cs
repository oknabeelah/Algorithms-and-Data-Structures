public class DataClass
{
    public static List<int> genNumbers (int n)
    {
        Random rd = new Random ();
        List<int> numbers = Enumerable.Range(0, n).OrderBy(b=>rd.Next()).ToList();
        return numbers;
    }

    public static List<int> genRandomNumbers (int n)
    {
        List<int> res = new List<int>(n);
        Random r = new Random();

        for (int i = 0; i<n; i++)
        {
            int number = r.Next(5, 30);
            if (!res.Contains(number))
                res.Add(number);
        }

        return res;
    }

    public static void printList(List<int> list){
        
        foreach (int i in list)
        {
            Console.WriteLine(i);
        }
    }

    public static void writeFile(List<int> list){
        string fileName = "data.txt";
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (int i in list)
            {
                sw.WriteLine(i);
            }
        }

    }

    public static List<int> readFile(string fileName){
        List<int> res = new List<int>();
        // string readText = File.ReadAllText(fileName);
        var x = System.IO.File.ReadLines(fileName).ToList();
        res = x.Select(int.Parse).ToList();
        return res;
    }

    public static void writeResults(List<int> data)
    {
        string fileName = "result.txt";
        using(StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (int i in data)
            {
                sw.Write(i);
                sw.Write(",");
            }
        }
    }
}