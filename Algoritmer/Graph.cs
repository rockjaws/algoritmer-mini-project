using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
  /// <summary>
  /// Represents a graph data structure consisting of nodes and edges.
  /// Supports both directed and undirected edges.
  /// </summary>
  /// <typeparam name="T">The type of data stored in the graph nodes.</typeparam>
  public class Graph<T>
  {
    /// <summary>
    /// Gets or sets the collection of all nodes in the graph.
    /// </summary>
    public List<Node<T>> Nodeset { get; set; } = new List<Node<T>>();

    /// <summary>
    /// Adds a new node with the specified value to the graph.
    /// </summary>
    /// <param name="value">The value to store in the new node.</param>
    public void AddNode(T value)
    {
      Node<T> node = new Node<T>(value);
      Nodeset.Add(node);
    }

    /// <summary>
    /// Adds a directed edge from one node to another.
    /// The edge goes from 'from' to 'to' (one-way).
    /// </summary>
    /// <param name="from">The value of the source node.</param>
    /// <param name="to">The value of the destination node.</param>
    public void AddDirectedEdge(T from, T to)
    {
      Node<T>? nodeFrom = FindNode(from);
      Node<T>? nodeTo = FindNode(to);

      if (nodeFrom == null || nodeTo == null)
      {
        throw new Exception("Both nodes must exist.");
      }

      nodeFrom.AddEdge(nodeTo);
    }

    /// <summary>
    /// Adds an undirected edge between two nodes.
    /// Creates edges in both directions (two-way).
    /// </summary>
    /// <param name="from">The value of the first node.</param>
    /// <param name="to">The value of the second node.</param>
    public void AddEdge(T from, T to)
    {
      Node<T>? nodeFrom = FindNode(from);
      Node<T>? nodeTo = FindNode(to);

      if (nodeFrom == null || nodeTo == null)
      {
        throw new Exception("Both nodes must exist.");
      }

      // Add edges in both directions for undirected graph
      nodeFrom.AddEdge(nodeTo);
      nodeTo.AddEdge(nodeFrom);
    }

    /// <summary>
    /// Finds and returns a node with the specified value.
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns>The node containing the value, or null if not found.</returns>
    public Node<T>? FindNode(T value)
    {
      Node<T>? node = Nodeset.Find(n => EqualityComparer<T>.Default.Equals(n.Data, value));
      return node ?? null;
    }
  }
}
