using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
  /// <summary>
  /// Represents a directed edge connecting two nodes in a graph.
  /// </summary>
  /// <typeparam name="T">The type of data stored in the connected nodes.</typeparam>
  public class Edge<T>
  {
    public Node<T> From { get; set; }
    public Node<T> To { get; set; }
    public Edge(Node<T> from, Node<T> to)
    {
      From = from;
      To = to;
    }
  }
}
