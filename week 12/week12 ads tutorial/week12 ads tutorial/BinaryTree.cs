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
public class BinaryTree
{
    private static Node? root;
    public BinaryTree()
    {
        root = null;
    }

    public static void Main(string[] args)
    {
        //BinaryTree tree = new BinaryTree();
        //Creation of a node named root:
        Node root = new Node(20);

        root.InsertNode(10);
        root.InsertNode(30);
        root.InsertNode(8);

        Console.WriteLine("\nIn order traversal\n");
        BinaryTree.inorderTraversal(root);

        Console.WriteLine("\nPre order traversal\n");
        BinaryTree.preorderTraversal(root);

        Console.WriteLine("\nPost order traversal\n");
        BinaryTree.postorderTraversal(root);
    }

    public bool isEmpty()
    {
        return (root == null); //start as true
    }
    public void InsertNode(int node)
    {
        Node newNode = new Node(node);

        if (root == null) //If the tree is empty, the new node becomes the root
        {
            root = newNode;
            return;
        }

        Node current = root; // Start at the root
        Node parent = root; // Keep track of the parent node

        while (current != null) // Traverse the tree
        {
            if (node < current.data) // Move to the left subtree
            {
                parent = current;
                current = current.left;
            }
            else if (node > current.data) // Move to the right subtree
            {
                parent = current;
                current = current.right;
            }
            else // Duplicate values are not allowed in this BST
            {
                Console.WriteLine("Element already exists");
                return;
            }

        }
    }
    public static bool SearchNode()
    {
        return false; //fix 
    }
    public static void DeleteNode(BinaryTree tree, int nodeid)  //searcvh and delete have given nodes
    {

    }
    public static void inorderTraversal(Node root) 
    {
        if (root != null)
        {
            inorderTraversal(root.left);
            Console.Write(root.data + " ");
            inorderTraversal(root.right);
        }
    }
    public static void preorderTraversal(Node root)
    {
        if (root != null)
        {
            Console.Write(root.data + " ");
            preorderTraversal(root.left);
            preorderTraversal(root.right);
        }
    }
    public static void postorderTraversal(Node root)
    {
        if (root != null)
        {
            postorderTraversal(root.left);
            postorderTraversal(root.right);
            Console.Write(root.data + " ");
        }
    }

    //bonus
    public static void PrintTree(BinaryTree tree)
    {
        /*
                        x
                       / \
                      y   z
         */
    }
}
