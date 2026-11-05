using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class Node
{
    public int data;
    public Node left, right;
    // Constructor
    public Node(int item)
    {
        data = item;  //list of nodes?
        left = null;
        right = null;
    }
}

public class Minheap()
{
    private static Node? root;
    public Minheap()
    {
        root = null;
    }
    public static void Main(string[] args)
    {

    }
}