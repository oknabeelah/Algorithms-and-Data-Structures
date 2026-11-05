using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//List<Double> data = ReadWrite.readData("C:\\Users\\Admin\\Desktop\\ADS Coursework-33030385\\Problem 4\\BinPackingProblem\\BINpACKingProblem\\BINpACKingProblem\\testdata.csv");
List<Double> data = ReadWrite.readData("C:\\Users\\Admin\\Desktop\\ADS Coursework-33030385\\Problem 4\\BinPackingProblem\\BINpACKingProblem\\BINpACKingProblem\\dataset.csv");

//CalcFitness();

HillClimbing hc = new HillClimbing(data);
hc.runHC(3000);


/* w alpha = 5
50 iter = 16 bins | 8 25 26 5 12 4 25 4 12 1 29 25 26 11 27 17 24 22 25 20 4 5 8 27 20 16 13 17 12 20
50 iter = 15 bins | 24 27 1 3 0 1 13 24 26 18 3 3 12 18 18 0 9 25 9 13 16 1 18 26 2 25 3 8 29 2
100 iter = 15 bins | 16 9 0 7 7 17 10 17 17 6 8 11 24 15 29 24 1 8 13 10 17 17 17 24 15 29 7 21 1 1
300 iter = 15 bins | 8 28 18 9 4 17 18 7 3 17 3 26 25 11 23 18 23 26 9 24 8 8 8 24 18 28 19 6 8 11
500 iter = 15 bins | 27 12 18 10 26 0 9 5 19 5 3 18 9 5 26 2 28 25 26 13 26 12 19 27 13 16 19 16 27 3
1000 iter = 14 bins | 1 26 20 5 27 16 27 11 27 5 28 5 3 8 29 11 12 17 26 29 17 26 15 28 20 8 16 8 1 17
3000 iter = 14 bins | 18 28 18 0 23 9 8 7 13 22 22 9 6 7 23 14 8 20 18 10 28 28 9 10 18 23 20 8 29 14
5000 iter = 13 bins | 15 15 28 21 2 28 21 2 7 29 9 29 29 9 7 15 5 22 23 21 17 9 27 11 27 2 2 17 17 15
 */
/*
 w alpha 3, 5 and 10,--> 10 is best
 */


/* w alpha = 1
 50 iter = 16 bins | 7 4 2 4 16 4 15 17 12 20 14 1 19 29 14 15 7 14 26 16 12 12 1 18 2 17 20 5 17 25
100 iter = 19 bins | 8 19 17 12 22 23 14 27 21 6 23 5 21 11 29 17 8 19 13 11 25 11 5 4 26 26 15 9 8 13
300 iter = 15 bins | 4 19 0 18 11 6 10 25 2 27 19 10 13 18 20 7 6 7 8 25 4 19 7 4 6 10 11 20 8 3
500 iter = 15 bins | 14 6 15 9 13 24 28 19 0 22 19 0 1 24 28 1 25 10 15 10 6 20 8 10 8 8 14 15 19 0
1000 iter = 15 bins | 24 10 8 13 27 25 9 28 23 24 25 7 8 4 13 24 7 12 7 11 4 21 12 7 21 13 13 28 20 28

 */

/*
 no β
 50 iter = 5 bins
100 iter = 5 bins
300 iter = 4 bins
500 iter = 3 bins (fitness is a negative value)

β weight = 0.1
 50 iter = 4 bins
100 iter = 4 bins
300 iter = 4 bins
500 iter = 4 bins

β weight = 1
 50 iter = 4 bins
100 iter = 4 bins
300 iter = 4 bins
500 iter = 3 bins (fitness is a negative value) 
 */

void CalcFitness()
{
    // testing fitness
    //change data to testdata and fill in appropraite values from excel table to test 
    List<int> testSolution = new List<int> { 1, 1, 1, 0, 2, 3, 4, 4, 5, 5 };
    BinPacking testBinPacking = new BinPacking();
    testBinPacking.solution = testSolution;
    testBinPacking.calculateFitness();
    double expectedFitness = 3274.264;
    double tolerance = 0.01; // Allow for minor floating-point differences
    if (Math.Abs(testBinPacking.fitness - expectedFitness) <= tolerance)
    {
        Console.WriteLine("Fitness calculation test PASSED.");
    }
    else
    {
        Console.WriteLine($"Fitness calculation test FAILED. Expected: {expectedFitness}, Got: {testBinPacking.fitness}");
    }
}