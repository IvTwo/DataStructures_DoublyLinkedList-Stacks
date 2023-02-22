// CMIS 2720
// Assignment 2a
// Implement the missing methods as indicated below.

namespace DoublyLinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }
        public T Value { get; set; }

        // Default Constructor
        public DoublyLinkedListNode()
        {
            // Use default(T) for the generic type
            // If T is a value type, the default is 0.
            // If T is a reference type, the default is null.
            Value = default(T);

            Next = null;
            Prev = null;
        }

        public DoublyLinkedListNode(T data)
        {
            Value = data;
            Next = null;
            Prev = null;
        }
    }

    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;
        public int Count { get; set; }
        public DoublyLinkedListNode<T> First { get { return _head; } }
        public DoublyLinkedListNode<T> Last { get { return _tail; } }

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public void AddLast(T data)
        {
            // Consider two cases: The list is empty or not empty. 

            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data);

            if (_tail == null)
            {
                // If the list was empty
                _head = _tail = newNode;
            }
            else
            {
                // If the list was not empty
                _tail.Next = newNode;
                newNode.Prev = _tail;

                // The new node is the tail now
                _tail = newNode;
            }

            Count++;
        }

        public void AddFirst(T data)
        {
            // Consider two cases: The list is empty or not empty. 

            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data);

            if (_head == null)
            {
                // The list was empty
                _head = _tail = newNode;
            }
            else
            {
                // The list was not empty
                _head.Prev = newNode;
                newNode.Next = _head;
                _head = newNode;
            }

            Count++;
        }

        public void RemoveFirst()
        {
            // Consider three cases: empty, one node, more than one node

            if (Count > 0)
            {
                if (Count == 1)
                {
                    // The list had only one node
                    _head = _tail = null;
                }
                else
                {
                    // The list had two or more nodes
                    _head = _head.Next;
                    _head.Prev = null;
                }

                Count--;
            }
            else
            {
                // Empty
                Console.WriteLine("Cannot remove because the list is empty.");
            }
        }

        public void RemoveLast()
        {
            // Consider three cases: empty, one node, more than one node

            if (Count > 0)
            {
                if (Count == 1)
                {
                    // The list had only one node
                    _head = _tail = null;
                }
                else
                {
                    // The list had two or more nodes
                    _tail = _tail.Prev;
                    _tail.Next = null;
                }

                Count--;
            }
            else
            {
                // Empty
                Console.WriteLine("Cannot remove because the list is empty.");
            }
        }

        public DoublyLinkedListNode<T>? Find(T data)
        {
            DoublyLinkedListNode<T> current = _head;
            while (current != null)
            {

                // Don't use (current.Value == data)
                if (current.Value.Equals(data))
                {
                    return current;
                }
                else
                {
                    current = current.Next;
                }
            }

            return null;
        }

        public DoublyLinkedListNode<T> AddAfter(DoublyLinkedListNode<T> node, T data)
        {
            if (node == null)
            {
                return null;
            }

            // Make sure the node exists in the list
            DoublyLinkedListNode<T> current = _head;
            while (current != null)
            {
                if (current == node)
                {
                    // If the node is in the list

                    DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data);

                    // Consider two cases: The current node is the last node and this node is not the last. 

                    // Pay attention to the sequence of operations

                    // First, link the new node
                    newNode.Next = node.Next;
                    newNode.Prev = node;

                    // Next, take care of the node behind the current node.
                    // Consider the case where the current node is the last.
                    if (node.Next != null)
                    {
                        node.Next.Prev = newNode;
                    }
                    else
                    {
                        // The current node is the last node

                        // Remember to update _tail
                        _tail = newNode;
                    }

                    // Finally update the current node
                    node.Next = newNode;

                    Count++;

                    return newNode;
                }

                current = current.Next;
            }

            return null;
        }

        public bool Remove(T data)
        {
            DoublyLinkedListNode<T> node = Find(data);

            if (node == null)
            {
                // The data does not exist
                return false;
            }

            // Consider three cases: This node is the first, 
            // this node is the last, and this node is between other nodes.

            // Pay attention to the sequence of operations
            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                // This node is the first node

                // Update _head
                _head = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else
            {
                // This node is the last node

                // Update _tail
                _tail = node.Prev;
            }

            Count--;

            return true;

        }

        public void PrintAllNodes()
        {
            Console.Write("Head -> ");
            DoublyLinkedListNode<T> current = _head;
            while (current != null)
            {
                Console.Write(current.Value);
                Console.Write(" -> ");
                current = current.Next;
            }

            Console.Write("NULL\n");

        }

        // To-do: Implement AddBefore()
        public DoublyLinkedListNode<T> AddBefore(DoublyLinkedListNode<T> node, T data)
        {
            // used the method "AddAfter" as reference

            if (node == null)
            {
                return null;
            }

            // make sure the node exists in the list
            DoublyLinkedListNode<T> current = _head;
            while (current != null)
            {
                // if the node is in the list
                if (current == node)
                {
                    DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data);

                    // consider two situations: the current node is first note || the current node is not the first node

                    // first link the new node
                    newNode.Prev = node.Prev;
                    newNode.Next = node;

                    // next handle the node in front of the current node
                    // consider if node is first
                    if (node.Prev != null)
                    {
                        node.Prev.Next = newNode;
                    }
                    else // current node == first node
                    {
                        _head = newNode;    // update head
                    }

                    // finally update the current node
                    node.Prev = newNode;
                    Count++;
                    return newNode;
                }

                current= current.Next;  // basically an "else"
            }
            return null;
        }

        // To-do: Implement FindLast()
        // find the last instance of "data" 
        public DoublyLinkedListNode<T>? FindLast(T data) 
        {
            DoublyLinkedListNode<T> current = _head;
            DoublyLinkedListNode<T> temp = null;
            while (current != null)
            {
                //Console.WriteLine(current.Value);
                if (current.Value.Equals(data))
                {
                    temp = current;
                }
                current = current.Next;
            }

            return temp;
        }

        // To-do: Implement Clear()
        // Removes all nodes from the
        public void Clear() 
        {
            DoublyLinkedListNode<T> current = _head;
            while (current != null) 
            { 
                Remove(current.Value);  // this method is already implemented(?)
                current = current.Next;
            }
        }
    }
    class DoublyLinkedListTest
    {
        static void Main(string[] args)
        {

            DoublyLinkedList<int> dLinkedList = new DoublyLinkedList<int>();

            dLinkedList.AddLast(1);
            dLinkedList.AddLast(2);
            dLinkedList.AddLast(3);
            dLinkedList.AddLast(4);
            dLinkedList.AddFirst(2);
            dLinkedList.AddFirst(6);

            dLinkedList.PrintAllNodes();

            dLinkedList.AddBefore(dLinkedList.FindLast(2), 5);
            dLinkedList.PrintAllNodes();

            dLinkedList.Clear();
            dLinkedList.PrintAllNodes();
        }
    }
}