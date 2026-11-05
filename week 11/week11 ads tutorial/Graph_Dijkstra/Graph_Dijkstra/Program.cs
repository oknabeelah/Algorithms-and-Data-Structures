using System;
using System.Collections.Generic;
class Graph
{
    LinkedList<Tuple<int, int>>[] adjacencyList;

    // Constructor - creates an empty Adjacency List
    public Graph(int vertices)
    {
        adjacencyList = new LinkedList<Tuple<int, int>>[vertices];
        for (int i = 0; i < adjacencyList.Length; ++i)
        {
            adjacencyList[i] = new LinkedList<Tuple<int, int>>();
        }
    }

    // Appends a new Edge to the linked list
    public void addEdge(int srcVertex, int destVertex, int weight)
    {
        adjacencyList[srcVertex].AddLast(new Tuple<int, int>(destVertex, weight));
    }

    public int getNumberOfNodes()
    {
        return adjacencyList.Length;
    }

    public void printGraph()
    {
        int i = 0;
        foreach (LinkedList<Tuple<int, int>> list in adjacencyList)
        {
            Console.Write("adjacencyList[" + i + "] -> ");
            foreach (Tuple<int, int> edge in list)
                Console.Write(edge.Item1 + "(" + edge.Item2 + ") -> ");
            ++i;
            Console.WriteLine("Null");
        }
    }
    //Returns distance vector constaining he shprtest distances from source vertex to all other vertices. 
    public int[] dijkstra(int src)
    {
        int n = getNumberOfNodes();
        int[] distance = new int[n];
        // Write your code here
        return distance;
    }
}

public class graphMain
{
    public static void Main()
    {
        Console.WriteLine("Enter the number of vertices");
        int vertices = Convert.ToInt32(Console.ReadLine());

        Graph graph = new Graph(vertices);

        int s, d, w;
        string fileName = "C:\\Users\\jt3951\\Desktop\\edge_list2.txt";
        if (File.Exists(fileName))
        {
            StreamReader sr = new StreamReader(File.OpenRead(fileName));
            while (!sr.EndOfStream)
            {
                string[] edge = sr.ReadLine().Split(' ');
                s = Convert.ToInt32(edge[0]);
                d = Convert.ToInt32(edge[1]);
                w = Convert.ToInt32(edge[2]);
                graph.addEdge(s, d, w);
            }
        }

        graph.printGraph();
        Console.WriteLine("Number of nodes in graph = " + graph.getNumberOfNodes());

        // Call teh following when teh method dijksta is implemented
        //int[] dist=graph.dijkstra(0);
        //for (int i = 0; i < graph.getNumberOfNodes(); i++)
        //   Console.WriteLine("{0} {1}", i, dist[i]);  

    }
}