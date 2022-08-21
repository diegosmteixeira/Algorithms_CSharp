using System.Collections;

namespace Algorithms_DataStruct_Lib.Queues
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        /*
         * Resolve the problem of too fast growing of ArrayQueue
         * 
         * Solution is to wrap the Queue, and make it circular:
         * 
         *      Tail can be transfered to the beggining of Array,
         *      so after adding another item, tail goes to behind
         *      the Head.
         *      
         *      If after adding items the Array is filled, 
         *      it's necessary unwrap the Queue and double the size
         *      of Array.
         *      
         *      This way, copy elements in the right order and then
         *      place Head and Tail as usual.
         *      
         *      Another way, if Queue is wrapped and we start to Dequeue items,
         *      it's needed to reset the Head as well at some point.
         *      
         */

        private T[] _queue;
        private int _head;
        private int _tail;
        public int Count => _head <= _tail ? _tail - _head : _tail - _head + _queue.Length;
        public bool IsEmpty => Count == 0;
        public int Capacity => _queue.Length;

        public CircularQueue()
        {
            const int defaultCapacity = 4;
            _queue = new T[defaultCapacity];
        }

        public CircularQueue(int capacity)
        {
            _queue = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (Count == _queue.Length - 1)
            {
                int countPriorResize = Count;
                T[] newArray = new T[2 * _queue.Length];

                Array.Copy(_queue, _head, newArray, 0, _queue.Length - _head);
                Array.Copy(_queue, 0, newArray, _queue.Length - _head, _tail);

                _queue = newArray;

                _head = 0;
                _tail = countPriorResize;
            }

            _queue[_tail] = item;

            if (_tail < _queue.Length - 1)
            {
                _tail++;
            }
            else
            {
                _tail = 0;
            }
        }

        public void Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            _queue[_head++] = default;

            //If after remove, IsEmpty
            if (IsEmpty)
            {
                _head = _tail = 0;
            }
            else if (_head == _queue.Length)
            {
                _head = 0;
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
            //if _head <= _tail - Queue is unwrapped
            if (_head <= _tail)
            {
                for (int i = _head; i < _tail; i++)
                {
                    yield return _queue[i];
                }
            }
            //if _head > _tail - Queue is wrapped (circular)
            else
            {
                for (int i = _head; i < _queue.Length; i++)
                {
                    yield return _queue[i];
                }
                for (int i = 0; i < _tail; i++)
                {
                    yield return _queue[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
