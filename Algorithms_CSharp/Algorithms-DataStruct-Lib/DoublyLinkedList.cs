namespace Algorithms_DataStruct_Lib
{
    public class DoublyLinkedList<T>
    {
        /*
         * Each node has two references
         * one is pointing to the next node and one is pointing to the previous node.
         * 
         * Drawback: it allocates twice memory as a Singly Linked List allocate
         * because of keeping two references instead of one for each node.
         * 
         * note: previous pointer of the head node is equal to null
         * note: next pointer of the tail node is equal to null
         * 
         * but it's not necessary, we can make the Double Linked List circular..
         * in this case, the next pointer of tail node will point to the head
         * while the previous pointer of the head node, will point to the tail node
         * 
         * 
         *_Supported Operations_:
         *  .Add
         *  .Remove
         *  .Find
         *  .Enumerate
         */

        public DoublyLinkedNode<T>? Head { get; private set; }
        public DoublyLinkedNode<T>? Tail { get; private set; }
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedNode<T>(value));
        }

        private void AddFirst(DoublyLinkedNode<T> node)
        {
            //save off the current Head
            DoublyLinkedNode<T>? temp = Head;

            //point Head to node
            Head = node;

            //insert the rest of the list after the head
            Head.Next = temp;

            if (IsEmpty)
            {
                Tail = Head;
            }
            else
            {
                //before: 1(head) <----> 5 <-> 7 -> null
                //after: 3(head) <-----> 1 <-> 5 <-> 7 -> null

                //update "previous" ref of the former head
                temp.Previous = Head;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedNode<T>(value));
        }

        private void AddLast(DoublyLinkedNode<T> node)
        {
            if(IsEmpty)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;

            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            //shift head node
            Head = Head.Next;

            Count--;

            if (IsEmpty)
                Tail = null;
            else
                Head.Previous = null;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                //tail.previous is the penultimate node
                //null the pointer to the last node
                Tail.Previous.Next = null; 

                //shift the Tail (now it is the former penultimate node)
                Tail = Tail.Previous;
            }

            Count--;
        }


    }
}
