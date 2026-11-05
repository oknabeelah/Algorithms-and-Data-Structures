using System;
using System.Collections;
using System.Collections.Generic;

internal class Graph
{
    private static void Main(string[] args)
    {
        int n, m;
        Console.WriteLine("Enter Number of vertices");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Number of edges");
        m = Convert.ToInt32(Console.ReadLine());
        int[,] A = new int[n, n];
        bool[] visited = new bool[n];

        //Read from console
        //A = createGraphFromConsole(n,m);

        //Read from file.     
        //string fileName = "C:\\Users\\Admin\\OneDrive - Sheffield Hallam University\\Graph_Traversal\\Graph_Traversal\\edge_list1.txt";  //for my device  
        string fileName = "C:\\Users\\c3030385\\OneDrive - Sheffield Hallam University\\Graph_Traversal\\Graph_Traversal\\edge_list1.txt";  //for at uni
        A = createGraph(n, m, fileName); //9, 8, filename

        printGraph(n, A); //9, A

        // Call this after writing code for DFS
          Console.WriteLine("\nDFS");

        DFS(A, n, visited, 0);

        /* for (int i = 0; i < n; i++)
         {
           *//*if (!visited[i])
             {*//*
                 DFS(A, n, visited, i);
             //}
         }*/
        for (int i = 0; i < n; i++)
        {
            visited[i] = false;
        }

        // Call this after writing code for BFS
        Console.WriteLine();
        Console.WriteLine("BFS");


        BFS(A, n, visited, 0); 
        
    }
    //9     //8
    public static int[,] createGraph(int n, int m, string fileName)
    {
        int s, d; //source , diurection 
        int[,] A = new int[n, n]; // to cover all possible cases because theres morer edges than nodes/vertices, ie. a graph with 9 edges and 8 nodes has a 9.9 possiblities of node to node combination

        if (File.Exists(fileName)) 
        {
            StreamReader sr = new StreamReader(File.OpenRead(fileName));

            while (!sr.EndOfStream)
            {
                string[] edge = sr.ReadLine().Split(' ');
              
                s = Convert.ToInt32(edge[0]); //source is the first nuymbe
                d = Convert.ToInt32(edge[1]); //destination is the servond one
                A[s, d] = 1; //check if the direction exists, if so replace3 index with , if not leave as 0
                A[d, s] = 1; //sameee
            }
            sr.Close();
        }
        return A; 
    }
                                   //9
    public static void printGraph(int n, int[,] A)
    {
        Console.WriteLine("Adj Matrix");
        for (int i = 0; i < n; i++) 
        {
            Console.WriteLine();
            for (int j = 0; j < n; j++)
                Console.Write(A[i, j] + " ");
        }
    }
    public static void BFS(int[,] A, int n, bool[] visited, int si)
    {
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(si); //add v to queue //yeah but how do i increment this aaaah
        visited[si] = true; //set visitd to true

        while (queue.Count > 0) //while quen is not empty 
        {
            int current = queue.Dequeue(); // v := deleteQ()
            Console.Write(current + " ");

            for (int i = 0; i < n; i++) // for each neighbor i of v
            {
                if (A[current, i] == 1 && !visited[i]) // if visited[i] is False
                {
                    visited[i] = true; // visited[i] = True
                    queue.Enqueue(i); // addQ(i)

                }
            }
        }
        
    }

    public static void DFS(int[,] A, int n, bool[] visited, int si)
    {
        //ue recursion
        visited[si] = true;
        Console.Write(si + " ");
        for (int i = 0; i < n;i++)
        {
            
            if (A[si,i] == 1 && visited[i] == false)
           {
                visited[i] = true;
                DFS(A, n, visited, i); //recursion
           }
        }
    }
    

}