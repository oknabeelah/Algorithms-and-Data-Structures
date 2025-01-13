using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class WeightedAlg
    {
        private Dictionary<string, List<(string, double)>> adjacencyList;
        public WeightedAlg() 
        {
            adjacencyList = new Dictionary<string, List<(string, double)>>();
        }

        public void addEdge(string node1, string node2, double weight)
        {
            if (!adjacencyList.ContainsKey(node1))
            {
                adjacencyList[node1] = new List<(string, double)>();
            }
            if (!adjacencyList.ContainsKey(node2))
            {
                adjacencyList[node2] = new List<(string, double)>();
            }

            adjacencyList[node1].Add((node2, weight));
            adjacencyList[node2].Add((node1, weight));
        }

        public double calculateInfluenceScore(string node)
        {
            int n = adjacencyList.Count; 
            var distances = Djikstra(node);
            double score = distances.Values.Sum(); //why not the same as unweighted 

            return (n - 1) / score; //formule
        }

        private Dictionary<string, double> Djikstra(string startnode) //finding the shortest path
        {
            var distances = adjacencyList.Keys.ToDictionary(node => node, node => double.PositiveInfinity); // initially unreachable distance
            distances[startnode] = 0;

            var PQ = new PriorityQueue<string, double>(); //creates a priority queu, store smallest distance with the highest priority
            PQ.Enqueue(startnode, 0); 

            while (PQ.Count > 0) //until empty
            {
                var currentnode = PQ.Dequeue();

                foreach (var (neigbhor, weight) in adjacencyList[currentnode])
                {
                    double newdistance = distances[currentnode] + weight;

                    if (newdistance < distances[neigbhor]) //update if a new shorter path is found
                    {
                        distances[neigbhor] = newdistance;
                        PQ.Enqueue(neigbhor, newdistance);
                    }
                }
            }
            return distances;
        }

        public void allInfluenceScores()
        {
            var influencescores = new Dictionary<string, double>();

            foreach (var node in adjacencyList.Keys)
            {
                double score = calculateInfluenceScore(node);
                influencescores[node] = score;
            }

            var Highestinfluence = influencescores.OrderByDescending(keyvalue => keyvalue.Value).First();
            var Lowestinfluence = influencescores.OrderBy(keyvalue => keyvalue.Value).First();

            Console.WriteLine($"the node with the highest influence score of {Highestinfluence.Value} is {Highestinfluence.Key}");
            Console.WriteLine($"the node with the lowest influence score of {Lowestinfluence.Value} is {Lowestinfluence.Key}");
        }
    }
}
