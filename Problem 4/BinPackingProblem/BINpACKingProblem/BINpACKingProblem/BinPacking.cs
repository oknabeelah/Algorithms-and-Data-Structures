public class BinPacking : HillClimbing 
{

    public List<int> solution = new List<int>();
    int solSize = 0;
    public double fitness = 0.00;

    private const double alpha = 10; // weight for BinCount
    private const double beta = 0.1;  // weight for MaxHeight - MinHeight
    private const double gamma = 10; // weight for WastedSpace 
    private const double binCapacity = 130; // max bin capacity

    public BinPacking() : base(data)  
    {
        solSize = data.Count; 
        solution = genRandomSol(); 
        calculateFitness();
    }

    public void copySolution(List<int> sol)
    {
        solution = new List<int>(sol);
        calculateFitness();
    }

    public void calculateFitness()  
    {
        // calc bin heights
        var binHeights = new Dictionary<int, double>();
        for (int i = 0; i < solSize; i++)
        {
            int bin = solution[i];
            if (!binHeights.ContainsKey(bin))
            {
                binHeights[bin] = 0;
            }
            binHeights[bin] += data[i];
        }

        int binCount = binHeights.Count; //num of non empty bins

        double wastedSpace = binHeights.Values.Sum(h => binCapacity - h); //calc wasted space

        double maxHeight = binHeights.Values.Max();
        double minHeight = binHeights.Values.Min();
        double heightDifference = maxHeight - minHeight; //β

        //fitness = (alpha * binCount) + (gamma * wastedSpace);
        fitness = (alpha * binCount) + (beta * heightDifference) + (gamma * wastedSpace);
    }

    public List<int> genRandomSol()
    {
        List<int> res = new List<int>();

        Random r = new Random();

        for (int i = 0; i < solSize; i++) //solSize is data.count
        {
            res.Add(r.Next(30)); //should be 30 but we start w 10
        }
        return res;
    }

    public void printSol()
    {
        foreach (int i in solution)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
    public void printCount()
    {
        int uniqueBinCount = solution.Distinct().Count();
        Console.WriteLine($"number of bins = {uniqueBinCount}");
    }
}

