using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq; //finding extreme nodes
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class UnweightedAlg
    {
        private Dictionary<string, List<string>> adjacencyList;
        public UnweightedAlg()
        {
            adjacencyList = new Dictionary<string, List<string>>();
        }

        public void addEdge(string node1, string node2)
        {
            if (!adjacencyList.ContainsKey(node1)) //check node1 already exsts , if not add to dictionary
            {
                adjacencyList[node1] = new List<string>();
            }
            if (!adjacencyList.ContainsKey(node2))
            {
                adjacencyList[node2] = new List<string>();
            }
            adjacencyList[node1].Add(node2); //add and establis connection
            adjacencyList[node2].Add(node1); //bothways 
            /*
             This method builds the adjacency list representation of the graph.
             Bidirectional Relationship: Since the graph is undirected, both node1 and node2 point to each other in the list.
              Dynamic Addition: If a node does not already exist in the graph, it's added with an empty list to hold its neighbors.
             */
        }

        public double calculateInfluenceScore(string node)
        {
            int n = adjacencyList.Count;
            Dictionary<string, int> distances = BFS(node);
            double score = 0; 

            foreach (var distance in distances.Values)
            {
                score += distance; // sum of d(u,v) 
            }

            return (n - 1) / score; //influence formula for unweighted 
        }

        private Dictionary<string, int> BFS(string startnode)
        {
            var distances = new Dictionary<string, int>(); // track distance from start node to each visited node 
            var queue = new Queue<string>(); //initalise queue to store nodes to be explored 
            var visited = new HashSet<string>(); //keep track of visited nodes 

            queue.Enqueue(startnode); 
            distances[startnode] = 0; 
            visited.Add(startnode); 

            while (queue.Count > 0) //while not empty
            {
                string currentnode = queue.Dequeue(); //remove current node and explore its neighbors

                foreach (var neighbor in adjacencyList[currentnode]) //foreach unvisited neighbor, 
                {
                    if (!visited.Contains(neighbor)) //if its not visited/ double checking? 
                    {
                        distances[neighbor] = distances[currentnode] + 1; //set the dist to be from the current node + 1
                        queue.Enqueue(neighbor); // add this neighbor to the quen to explore later 
                        visited.Add(neighbor); //mark as visited 
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
                double score  = calculateInfluenceScore(node);
                influencescores[node] = score;
            }

            var Highestinfluence = influencescores.OrderByDescending(keyvalue => keyvalue.Value).First();
            var Lowestinfluence = influencescores.OrderBy(keyvalue => keyvalue.Value).First();

            Console.WriteLine($"the node with the highest influence score of {Highestinfluence.Value} is {Highestinfluence.Key}");
            Console.WriteLine($"the node with the lowest influence score of {Lowestinfluence.Value} is {Lowestinfluence.Key}");
        }
        public void LoadEuroroadData(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("%")) continue; // skip lines starting with % ie metadata

                    var bits = line.Split(' ');
                    if (bits.Length == 2)
                    {
                        string node1 = bits[0];
                        string node2 = bits[1];

                        addEdge(node1, node2);
                    }
                }
            }
        }
    }
}
