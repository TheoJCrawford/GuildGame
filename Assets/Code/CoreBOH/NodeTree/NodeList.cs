using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GG
{
    public class NodeList<T>: Collection<Node<T>>
    {
        public NodeList(): base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T Value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.value.Equals(Value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
    }
}
