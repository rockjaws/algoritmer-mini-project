using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
  /// <summary>
  /// Represents a node (vertex) in a graph.
  /// Each node contains data and a list of outgoing edges to other nodes.
  /// </summary>
  /// <typeparam name="T">The type of data stored in the node.</typeparam>
  public class Node<T>
  {
    public T Data { get; set; }
    public List<Edge<T>> Edges { get; set; } = new List<Edge<T>>();
    public Node(T data)
    {
      Data = data;
    }

    /// <summary>
    /// Adds a directed edge from this node to another node.
    /// </summary>
    /// <param name="other">The destination node.</param>
    public void AddEdge(Node<T> other)
    {
      Edge<T> edge = new Edge<T>(this, other);
      Edges.Add(edge);
    }
  }
}
