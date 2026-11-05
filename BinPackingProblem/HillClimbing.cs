public class HillClimbing //does this inherit from binpacking or the other way artound
{
    public static List<Double> data;
    public HillClimbing(List<Double> d)
    {
        data = new List<double>(d);
    }
    public void runHC(int iter)
    {
        double[,] result = new double[iter, 3];
        List<List<int>> solutions = new List<List<int>>();

        
        BinPacking Sol = new BinPacking(); // Create a new solution
        BinPacking newSol = new BinPacking();
        
        newSol.copySolution(Sol.solution); // copy the existion solution to the new solution
       
        for (int i = 0; i < iter; i++) // Start searching solutions
        {
            result[i, 0] = i; //iter num
            result[i, 1] = Sol.fitness; //current fitness
            result[i, 2] = newSol.fitness; //new fitness (before small change tho  //HEREEE

            solutions.Add(Sol.solution); //save current soln
            //solutions.Add(new List<int>(Sol.solution)); //whats the diff

            // perform a small change toward the new solution
            newSol = smallChange(newSol);

            newSol.calculateFitness();
            result[i, 2] = newSol.fitness; //update recalculated fitness

            Console.WriteLine("Iteration: " + (i + 1));
            Sol.printSol();
            Console.WriteLine("Solution Fitness " + Sol.fitness);
            newSol.printSol();
            Console.WriteLine("New Solution Fitness " + newSol.fitness);


            // if new soln is better than curnt soln, copy soln from new to current soln
            if (newSol.fitness < Sol.fitness)
            {
                Sol.copySolution(newSol.solution);
            }
        }
        Console.WriteLine("Final solution (fitness)" + Sol.fitness);
        Sol.printSol(); Sol.printCount();
        ReadWrite.writeResults(result, "result.csv");
        ReadWrite.writeSolutions(solutions, "solutions.csv");
    }
    public BinPacking smallChange(BinPacking newSol) //randomly pick a non empty bin and reassign a block from it to another bin
    {
        Random r = new Random();

        int blockIndex = r.Next(newSol.solution.Count); // pick a random block and reassign it to another bin
        int currentBin = newSol.solution[blockIndex];
        int newBin;
        do
        {
            //newBin = r.Next(10);
            newBin = r.Next(30); // Assuming 30 bins //10 for test
        } while (newBin == currentBin);
        newSol.solution[blockIndex] = newBin;

        newSol.calculateFitness(); //recalc fitness
        return newSol;
    }
}


