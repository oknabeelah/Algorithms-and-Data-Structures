using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    class Program
    {
        public static void Main(string[] args)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();
            UnweightedAlg graph = new UnweightedAlg();

            graph.addEdge("Alicia", "Britney");
            graph.addEdge("Britney", "Claire");
            graph.addEdge("Claire", "Diana");
            graph.addEdge("Diana", "Edward");
            graph.addEdge("Diana", "Harry");
            graph.addEdge("Edward", "Harry");
            graph.addEdge("Edward", "Gloria");
            graph.addEdge("Edward", "Fred");
            graph.addEdge("Gloria", "Fred");
            graph.addEdge("Harry", "Gloria");

            Console.WriteLine("Computing ...");

            graph.allInfluenceScores();

            stopwatch.Stop();
            Console.WriteLine($"execution time: {stopwatch.ElapsedMilliseconds} ms");
            /////////////////////////////////////////////////////////////
            stopwatch.Reset();

            WeightedAlg weightedgraph = new WeightedAlg();

            weightedgraph.addEdge("A", "B", 1);
            weightedgraph.addEdge("A", "C", 1);
            weightedgraph.addEdge("A", "E", 5);
            weightedgraph.addEdge("B", "C", 4);
            weightedgraph.addEdge("B", "E", 1);
            weightedgraph.addEdge("B", "G", 1);
            weightedgraph.addEdge("B", "H", 1);
            weightedgraph.addEdge("C", "D", 3);
            weightedgraph.addEdge("C", "E", 1);
            weightedgraph.addEdge("D", "E", 2);
            weightedgraph.addEdge("D", "F", 1);
            weightedgraph.addEdge("D", "G", 5);
            weightedgraph.addEdge("E", "G", 2);
            weightedgraph.addEdge("F", "G", 1);
            weightedgraph.addEdge("G", "H", 2);
            weightedgraph.addEdge("H", "I", 3);
            weightedgraph.addEdge("I", "J", 3);

            weightedgraph.allInfluenceScores();

            ///////////////////////////////////////////////////
            
            stopwatch.Start();
            UnweightedAlg data = new UnweightedAlg();
            data.LoadEuroroadData("C:\\Users\\Admin\\Desktop\\ADS Coursework-33030385\\Problem 3\\Project3\\road-euroroad.edges");
            data.allInfluenceScores();

            stopwatch.Stop();
            Console.WriteLine($"execution time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}