using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MazeProblem
{
    class Program
    {
        static readonly int[] rowDir = { -1, 1, 0, 0, -1, -1, 1, 1 };
        static readonly int[] colDir = { 0, 0, -1, 1, -1, 1, -1, 1 };
        static void Main(string[] args)
        {/*
            int[,] maze = //dataset
            {
                  {1, 0, 1, 1, 1, 1, 1, 1 },
                  {1, 0, 0, 0, 0, 0, 0, 1 },
                  {1, 1, 1, 1, 1, 1, 0, 1 },
                  {1, 0, 0, 0, 0, 0, 0, 1 },
                  {1, 0, 1, 1, 1, 1, 1, 1 },
                  {1, 0, 0, 0, 0, 0, 0, 1 },
                  {1, 1, 1, 1, 1, 1, 0, 1 },
                  {1, 0, 0, 0, 0, 0, 0, 1 },
                  {1, 0, 1, 1, 1, 1, 1, 1 },
                  {1, 0, 0, 0, 0, 0, 0, 0 }, //512 unique paths
                  {1, 1 ,1, 1, 1, 1, 1, 1 }, //also this is the second graph
              };*/

            /* int[,] maze =
             {
                  {1, 0, 1, 1, 1, 1},
                  {1, 1, 0, 1, 1, 1},
                  {1, 1, 1, 0, 1, 1},
                  {1, 1, 1, 1, 0, 1},
                  {1, 1, 1, 1, 1, 0}, //exiit
                  {1, 1, 1, 1, 1, 1}, //tested, works with one path result! Path 1: (0, 1) -> (1, 2) -> (2, 3) -> (3, 4) -> (4, 5)
             };*/

            /*  int[,] maze =
              {
                  {1, 0, 1},
                  {1, 0, 0},
                  {1, 1, 0}, //test? works, 4 unique paths
              };*/

            /*  int[,] maze =
             {
                   {1, 0, 1, 1},
                   {1, 0, 0, 1},
                   {1, 1, 0, 0},
                   {1, 1, 1, 1}, //test 7 unique paths
               };*/
            /*
                        int[,] maze =
                        {
                             {1, 1, 1},
                             {1, 1, 1},
                             {1, 1, 1}, //test
                         };
            */
            /*int[,] maze =
           {
                {1, 0, 1, 1, 1, 1},
                {1, 1, 0, 1, 1, 1},
                {1, 1, 0, 0, 1, 1},
                {1, 1, 1, 0, 0, 1},
                {1, 1, 1, 1, 0, 0},
                {1, 1, 1, 1, 1, 1}, //test? 24 unique paths
            };*/

            /* int[,] maze =
             {
                 {1, 0, 1, 1},
                 {1, 0, 0, 1},
                 {1, 1, 0, 1}, //test? 12 unique paths
                 {1, 0, 0, 0},
             };*/

            int[,] maze =
            {
                 {1, 0, 1},
                 {1, 0, 1},
                 {1, 0, 0}, //test?  2 unique paths
             };

            /* int[,] maze =
             {
                 {0, 0, 1},
                 {1, 0, 1},
                 {1, 0, 0}, //test?  4 unique paths
             };*/

            /* int[,] maze =
             {
                 {1, 0, 1, 1, 1},
                 {1, 0, 0, 0, 1},
                 {1, 1, 1, 0, 1},
                 {1, 0, 0, 0, 1},
                 {1, 1, 1, 0, 0}, //test? 28 unique paths
             };*/


            /* int[,] maze =
            {
                  {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                  {1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1 },
                  {1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1 },
                  {1, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1 },
                  {1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 1 },
                  {1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                  {1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1 },
                  {1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                  {1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1 },
                  {1, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1 },
                  {1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1 },
                  {1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0 },
                  {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, //16128 unique paths oof 
              }; //first graph
 */

            (int, int) entry = FindEntry(maze);
            (int, int) exit = FindExit(maze);

            if (entry == (-1, -1) || exit == (-1, -1))
            {
                Console.WriteLine("No valid entry or exit found.");
                return;
            }

            List<List<(int, int)>> allPaths = new List<List<(int, int)>>(); //stores all unique paths
            List<(int, int)> path = new List<(int, int)>(); //tracks current path
            bool[,] visited = new bool[maze.GetLength(0), maze.GetLength(1)]; // Track visited cells

            // Func call
            DFS(maze, entry, exit, path, allPaths, visited);

            // output paths and shortest path
            OutputPaths(allPaths);

            // write to file //optional
            WritePathsToFile(allPaths);

        }

        static void DFS(int[,] maze, (int, int) current, (int, int) exit, List<(int, int)> path, List<List<(int, int)>> allPaths, bool[,] visited)
        {
            int row = current.Item1;
            int col = current.Item2;

            //base case: exit is reached
            if (current == exit)
            {
                path.Add(current);
                allPaths.Add(new List<(int, int)>(path));
                path.RemoveAt(path.Count - 1);
                return;
            }
            //otherwise
            visited[row, col] = true; //mark current as visited 
            path.Add(current); // add to path

            //check all directions
            for (int i = 0; i < 8; i++)
            {
                int newRow = row + rowDir[i];
                int newCol = col + colDir[i];

                if (IsValidMove(maze, newRow, newCol, visited))
                {
                    DFS(maze, (newRow, newCol), exit, path, allPaths, visited); //call it recursively
                }
            }
            //backtrack
            path.RemoveAt(path.Count - 1);
            visited[row, col] = false; //explain backtrack logic to see if it works
        }
        static bool IsValidMove(int[,] maze, int row, int col, bool[,] visited)
        {
            return row >= 0 && row < maze.GetLength(0) && col >= 0 && col < maze.GetLength(1) && maze[row, col] == 0 && !visited[row, col];
            // row, col is greater than or equal to zero and less than the maze lenght and the coordinate isnt a wall (1) and it isnt marked as visited 
        }
        static (int, int) FindEntry(int[,] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row, col] == 0) 
                    { 
                        return (row, col); 
                    }               
                }
            }
            return (-1, -1); // no entry found
        }

        static (int, int) FindExit(int[,] maze)
        {
            for (int row = maze.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = maze.GetLength(1) - 1; col >= 0; col--)
                {
                    if (maze[row, col] == 0)
                    {
                        return (row, col);
                    }
                }
            }
            return (-1, -1); // no exit found
        }

        static void OutputPaths(List<List<(int, int)>> allPaths)
        {
            Console.WriteLine($"Total Unique Paths: {allPaths.Count}");
            int pathIndex = 1;
            foreach (var path in allPaths)
            {
                Console.WriteLine($"Path {pathIndex}: {string.Join(" -> ", path)}");
                Console.WriteLine("\nNext Path:\n");
                pathIndex++;
            }

            if (allPaths.Count > 0)
            {
                var shortestPath = FindShortestPath(allPaths);
                Console.WriteLine("\nFastest Path:");
                Console.WriteLine(string.Join(" -> ", shortestPath));
            }
            else
            {
                Console.WriteLine("No valid paths found.");
            }
        }

        static void WritePathsToFile(List<List<(int, int)>> allPaths)
        {
            using (StreamWriter writer = new StreamWriter("Paths.txt")) //make sure file existss
            {
                writer.WriteLine($"Total Unique Paths: {allPaths.Count}");
                int pathIndex = 1;
                foreach (var path in allPaths)
                {
                    writer.WriteLine($"Path {pathIndex}: {string.Join(" -> ", path)}");
                    writer.WriteLine("\nNext Path:\n");
                    pathIndex++;
                }

                if (allPaths.Count > 0)
                {
                    var shortestPath = FindShortestPath(allPaths);
                    writer.WriteLine("\nFastest Path:");
                    writer.WriteLine(string.Join(" -> ", shortestPath));
                }
                else
                {
                    writer.WriteLine("No valid paths found.");
                }
                Console.WriteLine("saved to file");
            }
        
        }

        static List<(int, int)> FindShortestPath(List<List<(int, int)>> allPaths)
        {
            List<(int, int)> shortestPath = allPaths[0];
            foreach (var path in allPaths)
            {
                if (path.Count < shortestPath.Count)
                {
                    shortestPath = path;
                }
            }
            return shortestPath;
        }

    }
}


