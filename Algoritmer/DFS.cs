using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
  /// <summary>
  /// Implements Depth-First Search (DFS) algorithm for graph traversal.
  /// DFS explores as far as possible along each branch before backtracking.
  /// Time Complexity: O(V + E) where V is vertices and E is edges
  /// Space Complexity: O(V) for the stack and tracking structures
  /// </summary>
  /// <typeparam name="T">The type of data stored in graph nodes.</typeparam>
  public class DFS<T>
  {
    /// <summary>
    /// Gets the number of nodes visited during the last DFS operation.
    /// </summary>
    public int Comparisons { get; private set; } = 0;

    /// <summary>
    /// Finds a path from source to destination node using Depth-First Search.
    /// </summary>
    /// <param name="graph">The graph to search.</param>
    /// <param name="source">The starting node.</param>
    /// <param name="destination">The target node to find.</param>
    public void DFSRoute(Graph<T> graph, Node<T> source, Node<T> destination)
    {
      Comparisons = 0;
      List<Node<T>> marked = new List<Node<T>>();  // Tracks visited nodes
      List<Node<T>> exitToSource = new List<Node<T>>();
      Dictionary<Node<T>, Node<T>> parent = new Dictionary<Node<T>, Node<T>>();  // Tracks path for reconstruction
      Stack<Node<T>> stack = new Stack<Node<T>>();  // LIFO structure for depth-first traversal

      // Initialize: start with source node
      stack.Push(source);
      parent[source] = null;  // Source has no parent

      Console.WriteLine();
      Console.WriteLine("Starting DFS...");
      Console.Write("Order of nodes visited: ");

      // Main DFS loop: process nodes in depth-first order
      while (stack.Count > 0)
      {
        Node<T> node = stack.Pop();
        Console.Write(node.Data);

        // Skip if already visited (can happen if node is pushed multiple times)
        if (marked.Contains(node))
        {
          Console.Write(", ");
          continue;
        }

        marked.Add(node);

        // Check if we've reached the destination
        if (node.Equals(destination))
        {
          Console.WriteLine();
          Console.WriteLine("Destination found!");
          exitToSource.Add(node);
          break;
        }

        Console.Write(", ");

        // Explore all neighbors of current node
        // Note: edges are pushed in order, so they're popped in reverse (LIFO)
        foreach (var edge in node.Edges)
        {
          // Record parent relationship if not already discovered
          if (!parent.ContainsKey(edge.To))
          {
            parent[edge.To] = node;
          }

          stack.Push(edge.To);  // Push neighbor for later exploration
        }
      }

      // Reconstruct and display the path from source to destination
      foreach (var exit in exitToSource)
      {
        Node<T> current = exit;
        List<Node<T>> path = new List<Node<T>>();

        // Backtrack from destination to source using parent pointers
        while (current != null)
        {
          path.Add(current);
          current = parent[current];
        }

        path.Reverse();  // Reverse to get source → destination order

        Console.Write("Path to destination: ");
        for (int i = 0; i < path.Count; i++)
        {
          Console.Write(path[i].Data);
          if (i + 1 != path.Count)
          {
            Console.Write(" -> ");
          }
        }
      }

      Comparisons = marked.Count;
      Console.WriteLine($"\nDFS Visited Nodes: {Comparisons}");
    }
  }
}
