namespace Algorithms_DataStruct_Lib
{
    public class SinglyLinkedList<T>
    {
        /*
         *Linked List is abstract data type which allows to build chains of elements
         *
         *[ Head ]: contains reference to first node
         *[ Tail ]: contains reference to the last node
         *
         *_Supported Operations_:
         *  .Add
         *  .Remove
         *  .Find
         *  .Enumerate
         */

        public Node<T>? Head { get; private set; }
        public Node<T>? Tail { get; private set; }
        public int Count { get; private set; } //reflects the number of nodes on the list


        //Add a Node in the front of the list
        //Allows to pass a value directly (for convinience)
        public void AddFirst (T value)
        {
            //this method is just going to call another at the first method,
            //wrapping the value into the node
            AddFirst(new Node<T>(value));
        }

        //Add a whole node
        private void AddFirst(Node<T> node)
        {
            //save off the current head in case of list is not empty
            Node<T> tmp = Head;

            Head = node;

            //shifting the former head
            Head.Next = tmp;

            Count++;

            if(Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        private void AddLast(Node<T> node)
        {
            if (IsEmpty())
            {
                //in case of a empty list
                Head = node;
                Tail = node;
            }
            else
            {
                //the last node will point to the new one
                Tail.Next = node;

                //now, tail receive the new node
                Tail = node;
            }

            //Tail = node; twice, can be removed.. Just stayed for learning purposes

            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            //if nothing references the old former head, this will be garbage collected
            Head = Head.Next; //if only one node, head = null;

            if (Count == 1)
            {
                //if only one node
                Tail = null;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (IsEmpty()) { throw new InvalidOperationException();}

            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                
                var current = Head;

                //find the penultimate node
                //iterate over nodes, while current.next isn't the tail
                //the loop will stop on penultimate node
                while (current.Next != Tail)
                {
                    current = current.Next;
                }

                current.Next = null;
                Tail = current;
            }
            Count--;
        }

        public void RemoveByIndex(int index)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            if (Count < index)
            {
                throw new InvalidOperationException();
            }

            if (Count == 1)
            {
                Head = Tail = null;
                Count--;
            }

            if (index == 0)
            {
                throw new InvalidOperationException("Index starts at 1, in this list");
            }
            if (index == 1)
            {
                Head = Head.Next;
                Count--;
            }
            else if (index > 1)
            {
                var current = Head;

                for (int i = 1; i < index-1; i++)
                {
                    current = current.Next;
                }

                var toDelete = Head;

                for (int i = 1; i < index; i++)
                {
                    toDelete = toDelete.Next;
                }

                current.Next = null;
                current.Next = toDelete.Next;
                Count--;
            }
        }

        public Node<T> FindByIndex(int index)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            if (Count < index)
            {
                throw new InvalidOperationException();
            }

            var current = Head;

            for (int i = 0; i < index; i++)
            {
                if (!current.Next.Equals(Tail))
                {
                    current = current.Next;
                }
            }
            return current;
        }

        public bool IsEmpty() => Count == 0;
    }
}
