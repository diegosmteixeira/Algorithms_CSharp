using System.Collections;

namespace Algorithms_DataStruct_Lib.Queues
{
    public class ArrayQueue<T> : IEnumerable<T>
    {
        /*
         * Abstract Data Type 
         * 
         * FIFO - "First In, First Out" - way of managing elements.
         * 
         * - Enqueue : add an item to the end of the queue
         * 
         * - Dequeue : remove an item at the front of queue
         * 
         * - Peek : get an item at the front of the queue without removing
         * 
         * The characteristics of the queue is similar to Stack
         * 
         * [Time Complexity]:
         * 
         * - Peek works for O(1) in any cases
         * 
         * - If backed up by a LinkedList:
         * 
         *      Enqueue / Dequeue work for O(1)
         *      
         *      
         * - If backed up by an array, then Enqueue / Dequeue:
         * 
         *      . if enough space Eqnueue - O(1)
         *      
         *      . if not enough space, Enqueue - O(N) - resizing array
         *      
         *      . Dequeue works for O(1) if we never shrink array; O(N) when shrinking
         *      
         * [Note]:
         * 
         *  ->     If there's enough memory on a device, or the max number of items is not known,
         *         then Linked List is preferable as a backing data structure
         *      
         *  ->     Otherwise, if not enough memory or the max number of items is known,
         *         then Array is preferable as a backing data structure
         */


        private T[] _queue;

        private int _head;

        private int _tail;

        public int Count => _tail - _head;

        public bool IsEmpty => Count == 0;

        public double Capacity => _queue.Length;

        public ArrayQueue()
        {
            const int defaultCapacity = 4;
            _queue = new T[defaultCapacity];
        }

        public ArrayQueue(int capacity)
        {
            _queue = new T[capacity];
        }

        public void Enqueue(T item)
        {
            // cannot be _queue.Length == Count; because if we need to resize the array
            // count will be much less than length and we will access the array at an invalid index
            if (_queue.Length == _tail)
            {
                T[] largerArray = new T[Count * 2];
                Array.Copy(_queue, largerArray, Count);
                _queue = largerArray;
            }

            _queue[_tail++] = item;
        }

        public void Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            _queue[_head++] = default;

            if (IsEmpty)
            {
                _head = _tail = 0;
            }
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return _queue[_head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _head; i < _tail; i++)
            {
                yield return _queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
