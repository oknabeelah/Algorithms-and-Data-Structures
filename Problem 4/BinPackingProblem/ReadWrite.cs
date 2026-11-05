public class ReadWrite
{
    public static void writeFile<T>(List<T> data, string filename) //template lsit?
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            for (int i = 0; i < data.Count; i++)
            {
                sw.Write(data[i]);
                if (i < data.Count - 1)
                    sw.Write(",");
            }
        }
    }

    public static List<Double> readData(string filename)
    {
        List<Double> res = new List<double>();

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            var raw = line.Split(',');

            foreach (var item in raw)
            {
                if (double.TryParse(item.Trim(), out double value))
                {
                    res.Add(value);
                }
                else
                {
                    Console.WriteLine($"Invalid data: {item}"); // Debug invalid data
                }
            }
        }
        return res;
    }

    public static void printList<T>(List<T> list)
    {

        foreach (T i in list)
        {
            Console.WriteLine(i);
        }
    }

    public static void writeResults<T>(T[,] results, string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.Write("iter,current_fitness,new_fitness");
            sw.WriteLine();
            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    // Console.WriteLine(results[i,j]);
                    sw.Write(results[i, j]);
                    if (j < results.GetLength(1) - 1)
                        sw.Write(",");
                }
                sw.Write("\n");
            }
        }
    }

    public static void writeSolutions(List<List<int>> solutions, string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.Write("iter,solution");
            sw.WriteLine();
            for (int i = 0; i < solutions.Count; i++)
            {
                sw.Write(i + ",");
                sw.Write(string.Join(" ", solutions[i]));
                sw.WriteLine();
               /* for (int j = 0; j < solutions[i].Count; j++)
                {
                    sw.Write(solutions[i][j]);
                    sw.Write(" ");
                }
                sw.WriteLine();*/
            }
        }
    }

}

//method to read write
