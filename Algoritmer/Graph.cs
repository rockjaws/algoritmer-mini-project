using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
    public class Graph<T>
    {
        public List<Node<T>> Nodeset { get; set; } = new List<Node<T>>();

        public void AddNode(T value)
        {
            Node<T> node = new Node<T>(value);
            Nodeset.Add(node);
        }

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

        public void AddEdge(T from, T to)
        {
            Node<T>? nodeFrom = FindNode(from);
            Node<T>? nodeTo = FindNode(to);

            if (nodeFrom == null || nodeTo == null)
            {
                throw new Exception("Both nodes must exist.");
            }

            nodeFrom.AddEdge(nodeTo);
            nodeTo.AddEdge(nodeFrom);
        }

        public Node<T>? FindNode(T value)
        {
            Node<T>? node = Nodeset.Find(n => EqualityComparer<T>.Default.Equals(n.Data, value));
            return node ?? null;
        }
    }
}
