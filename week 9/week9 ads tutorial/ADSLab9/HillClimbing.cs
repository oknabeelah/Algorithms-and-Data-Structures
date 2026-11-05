using System.ComponentModel;

public class HillClimbing
{
    public static List<Double> data;
    public HillClimbing(List<Double> d)
    {
        data = new List<double>(d); //dataset is a list of doubles
    }


    // This method should run the experiment for the Scales problem.
    public void runHC(int iter)
    {
        double[,] result = new double[iter, 3];
        List<List<int>> solutions = new List<List<int>>();

        // Create a solution and a new solution, fisrt = random solution?
        Scales currentSolution = new Scales();
       /*currentSolution.printSol();*/
       Scales newSolution = new Scales();
       /*newSolution.printSol();*/

        // copy the existion solution to the new solution
        newSolution.copySolution(currentSolution.solution);

        // Start searching solutions, using the fitness?
        for (int i = 0; i<iter; i++)
        {
            result[i, 0] = i;
            result[i, 1] = currentSolution.fitness;
            result[i, 2] = newSolution.fitness;
            solutions.Add(currentSolution.solution);

            Console.WriteLine("iter: " + i);
            Console.WriteLine("current fitness: " + currentSolution.fitness); //should be random
            // perform a small change toward the new solution
            newSolution = smallChange(newSolution, 3); // the int is assigned by you

            Console.WriteLine("new fitness: " + newSolution.fitness);

            
            // If tne new solution is better than the current solution, we copy the solution from the new one to the current solution
            if (newSolution.fitness < currentSolution.fitness)
            {
                currentSolution.copySolution(newSolution.solution);
            }
        }
            Console.WriteLine("Final solution "+ currentSolution.fitness);

            // Write your results and solutions to csv files.
            ReadWriteFile.writeResults(result, "result.csv");
            ReadWriteFile.writeSolutions(solutions, "solutions.csv");

    }

    // This method should perform a small change to the new solution after we've copied from the solution.
    public Scales smallChange(Scales newSol, int n)
    {
        // Complete your method for small change
        //check nonabs fitness, fix as approriapre#
        
        for (int i = 0; i < n; i++)
        {
            Random rnd = new Random();  //RANDOM index from sol.lenght
            int rndindex = rnd.Next(0, newSol.solution.Count);
            if (newSol.solution[rndindex] == 0)
            {
                newSol.solution[rndindex] = 1;
               // Console.WriteLine(rndindex);
            }
            else
            {
                newSol.solution[rndindex] = 0;
                //Console.WriteLine(rndindex);
            }
        }

        newSol.calculateFitness();
        return newSol;
    }
}