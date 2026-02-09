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
            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();
                Console.WriteLine(node.Data);

                if (marked.Contains(node))
                    continue;

                if (node.Equals(destination))
                {
                    Console.WriteLine();
                    Console.WriteLine($"Desitnation found {node.Data}");
                    exitToSource.Add(node);
                    break;
                }
                foreach (var edge in node.Edges)
                {
                    if (!parent.ContainsKey(edge.To))
                    {
                        parent[edge.To] = node;
                        queue.Enqueue(edge.To);
                    }
                }
                marked.Add(node);
            }


            foreach (var exit in exitToSource)
            {
                Console.WriteLine();
                Console.WriteLine("Path to exit:");

                Node<T> current = exit;
                List<Node<T>> path = new List<Node<T>>();

                while (current != null)
                {
                    path.Add(current);
                    current = parent[current];
                }

                path.Reverse();

                foreach (var node in path)
                {
                    Console.WriteLine(node.Data);
                }
            }
            Comparisons = marked.Count;
            Console.WriteLine($"\nBFS total comparisons: {Comparisons}");
        }
    }
}