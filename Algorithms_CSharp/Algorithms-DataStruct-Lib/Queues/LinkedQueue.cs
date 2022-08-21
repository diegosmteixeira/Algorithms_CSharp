using System.Collections;

namespace Algorithms_DataStruct_Lib.Queues
{
    public class LinkedQueue<T> : IEnumerable<T>
    {
        //it's not needed to use Double Linked List
        //because it's no meaning here of keeping references of previous nodes

        private readonly SinglyLinkedList<T> _list = new SinglyLinkedList<T>();
        public int Count => _list.Count;
        public bool IsEmpty => Count == 0;

        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        public void Dequeue()
        {
            //guard clause IsEmpty is implemented by RemoveFirst() on list
            _list.RemoveFirst();
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return _list.Head.Value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            //return the enumerator of SinglyLinkedList because iterates over
            //the list from head to tail
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
