using System.Collections;

namespace Algorithms_DataStruct_Lib
{
    public class ArrayStack<T> : IEnumerable<T>
    {
        //Abstract Data Type(ADT)

        /*
         * Implements LIFO
         * "Last-In First-Out" - the mechanism of managing items 
         * 
         * basically means that you retrive first, those elements which came last
         * 
         *_Supported Operations_:
         *  .Push - add an item to the top
         *  .Pop - remove the top item
         *  .Peek - get the top item without removing
         *  
         * There are two major implementations of a stack
         * - one is based on an array
         * - and another one based on a linked list
         * 
         * [Time Complexity]:
         * 
         * - Peek works for O(1) in any cases
         * - If backed up by a LinkedList: 
         *      .Push/Pop works for O(1)
         *      
         * - If backed up by an array, then:
         * 
         *      .if enough space Push - O(1)
         *      .if not enough space, Push - O(N) resizing array
         *      
         *      .Pop works for O(1) if we never shrink array;
         *      .Pop works for O(N) when shrinking 
         *      (in case capacity is too big comparing to the number of elements being stored)
         *      
         * note: majority of stack implementations never shrink an array
         *       (a separate operation for shrink is provided,
         *       so in such a case, all the pop operations will work for a constant time)
         * 
         * 
         * To summarize the main points:
         * 
         *  [*] If there's enough memory on a device, or the max number of items is not known
         *    -> Linked List is preferable as a backing data structure
         *    
         *      (it's because a linked list requires more memory than an array - each node contains at least
         *      one reference which points to the next node).
         *  
         *  [*] otherwise, if not enough memory or the max number of items is known
         *    -> array is preferable as a backing data structure
         *  
         */

        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }

        private T[] _items;

        public ArrayStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public ArrayStack(int capacity)
        {
            _items = new T[capacity];
        }


        public T Peek()
        {
            return _items[Count - 1];
        }

        public void Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();


            /* default(T) is a special keyword which returns the default value of any type
             *  - zero for primitive types
             *  - null for strings and all reference types
            */

            _items[--Count] = default(T);

            //is equal to:

            //Count--;
            //_items[Count] = default(T);

            //(in this case decrement goes first because before accessing the item by index
            // is needed to decrement it and decide if is necessary shrink the internal array)


            /*----------------------
             * Note: Generally is not a good idea shrink here (it's better use another method to Trim()
             * 
             * In such a case, sometimes the Pop() operations would take a linear time..
             * moreover, if after shrinking the internal data storage, a client starts to Push() items,
             * there is a high chance that him will face linear time complexity once again,
             * because of the necessity to extend the internal data storage
             *----------------------
             */

        }

        public void Push(T item)
        {
            //if is full, create a new one with double size
            if (_items.Length == Count)
            {
                T[] largerArray = new T[Count * 2];
                Array.Copy(_items, largerArray, Count);

                //assign the reference of new array to _items
                _items = largerArray;
            }
            _items[Count++] = item;
            
                //is equal to:

                //_items[Count] = item;
                //Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}