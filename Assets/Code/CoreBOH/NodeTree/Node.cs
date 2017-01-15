using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG
{
    public class Node<T>
    {
        //private member-variables
        private T data;
        private NodeList<T> neightbors = null;

        public Node() { }
        public Node(T data): this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neightbors = neightbors;
        }

        public T value
        {
            get { return data; }
            set { data = value; }
        }

        protected NodeList<T> Neighbors
        {
            get { return neightbors; }
            set { Neighbors = value; }
        }
    }
}
