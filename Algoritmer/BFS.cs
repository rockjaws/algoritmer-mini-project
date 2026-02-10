using Algoritmer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
  public class BFS<T>
  {
    public int Comparisons { get; private set; } = 0;

    public void BFSRoute(Graph<T> graph, Node<T> source, Node<T> destination)
    {
      Comparisons = 0;

      List<Node<T>> exitToSource = new List<Node<T>>();
      List<Node<T>> marked = new List<Node<T>>();
      Dictionary<Node<T>, Node<T>> parent = new Dictionary<Node<T>, Node<T>>();
      Queue<Node<T>> queue = new Queue<Node<T>>();

      queue.Enqueue(source);
      parent[source] = null;

      Console.WriteLine();
      Console.WriteLine("Starting BFS...");
      Console.Write("Order of nodes visited: ");
      while (queue.Count > 0)
      {
        Node<T> node = queue.Dequeue();
        Console.Write(node.Data);

        if (marked.Contains(node))
          continue;
        marked.Add(node);

        if (node.Equals(destination))
        {
          Console.WriteLine();
          Console.WriteLine("Destination found!");
          exitToSource.Add(node);
          break;
        }
        Console.Write(", ");
        foreach (var edge in node.Edges)
        {
          if (!parent.ContainsKey(edge.To))
          {
            parent[edge.To] = node;
            queue.Enqueue(edge.To);
          }
        }
      }


      foreach (var exit in exitToSource)
      {
        Node<T> current = exit;
        List<Node<T>> path = new List<Node<T>>();

        while (current != null)
        {
          path.Add(current);
          current = parent[current];
        }

        path.Reverse();

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
      Console.WriteLine($"\nBFS Visited Nodes: {Comparisons}");
    }
  }
}
