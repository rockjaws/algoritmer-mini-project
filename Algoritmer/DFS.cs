using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
    public class DFS<T>
    {
        public void DFSRoute(Graph<T> graph, Node<T> source)
        {
            List<Node<T>> marked = new List<Node<T>>();
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(source);

            while (stack.Count > 0)
            {
                Node<T> node = stack.Pop();

                if (marked.Contains(node)) 
                    continue;

                marked.Add(node);
            }
        }
    }
}
