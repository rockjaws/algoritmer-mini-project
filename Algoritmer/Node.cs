using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
    public class Node<T>
    {
        public T Data { get; set; }
        public List<Edge<T>> Edges { get; set; } = new List<Edge<T>>();

        public Node(T data)
        {
            Data = data;
        }

        public void AddEdge(Node<T> other)
        {
            Edge<T> edge = new Edge<T>(this, other);
            Edges.Add(edge);
        }
    }
}
