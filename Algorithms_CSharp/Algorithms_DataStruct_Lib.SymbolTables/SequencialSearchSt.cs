namespace Algorithms_DataStruct_Lib.SymbolTables
{

    // Searching and Inserting (Get and Add operations) - O(N)
    // Searching - O(N/2) on average
    // That implementation implies that we keep keys unsorted
    public class SequencialSearchSt<TKey, TValue>
    {
        private class Node
        {
            public TKey Key { get;  }
            public TValue Value { get; set; }

            public Node Next { get; set; }

            public Node(TKey key, TValue value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }
        }

        private Node _first;
        private readonly IEqualityComparer<TKey> _comparer;

        public int Count { get; private set; }

        public SequencialSearchSt()
        {
            //provided for specific types,
            //such as integer or string
            _comparer = EqualityComparer<TKey>.Default;
        }

        public SequencialSearchSt(IEqualityComparer<TKey> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException();
        }

        public bool TryGet(TKey key, out TValue val)
        {
            for (Node x = _first; x!= null; x = x.Next)
            {
                if (_comparer.Equals(key, x.Key))
                {
                    val = x.Value;
                    return true;
                }
            }

            val = default;
            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if(key == null)
            {
                throw new ArgumentNullException("Key can't be null.");
            }
            for(Node x= _first; x!= null; x = x.Next)
            {
                if (_comparer.Equals(key, x.Key))
                {
                    //update the value if key already exists
                    x.Value = val;
                    return;
                }
            }
            //if there is no such a key, need to add
            _first = new Node(key, val, _first);

            Count++;
        }

        public bool Contains(TKey key)
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(key, x.Key))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                yield return x.Key;
            }
        }

        public bool Remove(TKey key)
        {
            // Null key is not allowed
            // Counter should be adjusted properly
            // It should remove a key - value pair entirely
            // It should return false if the requested key was not found, otherwise true

            if (key == null)
            {
                throw new ArgumentNullException("Key can't be null");
            }

            if (Count == 1 && _comparer.Equals(_first.Key, key))
            {
                _first = null;
                Count--;
                return true;
            }

            Node prev = null;
            Node current = _first;

            //Iterates over SinglyLinkedList
            while (current != null)
            {
                if (_comparer.Equals(current.Key, key))
                {
                    //when there more than one node,
                    //and the node which going to be removed is the first one
                    if (prev == null)
                    {
                        _first = current.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }

                    Count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }
            return false;
        }
    }
}