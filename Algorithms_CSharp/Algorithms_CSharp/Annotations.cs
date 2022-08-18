using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CSharp
{
    internal class Annotations
    {
        //System.Collections.Generic
        /* [Queue Built-In .NET & General Characteristics]:
         * 
         * Queue in BCL is circular and based on Array
         * 
         * Documentation:
         * 
         * "The capacity of a Queue is the number of elements the Queue can hold. 
         * As elements are added to a Queue, the capacity is automatically increased as required
         * through reallocation.  
         * 
         *  * The capacity can be decreased by calling TrimToSize. *
         * 
         * The growth factor is the number by which the current capacity is multiplied
         * when a greater capacity is required. The growth factor is determined when the Queue is constructed.
         * The elements are copied onto the Queue in the same order they are read by the IEnumerator of the
         * ICollection."
         * 
         * This constructor is an O(n) operation, where n is the number of elements in col.


        /* ---------------------
         *  - Peek/Dequeue - Always take constant time O(1) - since doesn't need to resize array
         *  - Enqueue O(N) when resizing, otherwise O(1)
         *  - Contains - O(N) - have to traverse N nodes
         *  - CopyTo / To Artray - O(N)
         *  - Clear - O(N)
         *  - TrimToSize - O(N)
         *


        //the default capacity is 4, but you can pass a bigger number
        Queue<int> q = new Queue<int>(8);

        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);

        Console.WriteLine($"Should print out 1:{q.Peek()}");

        q.Dequeue();

        Console.WriteLine($"Should print out 2:{q.Peek()}");

        Console.WriteLine($"Contains 3? Answer:{q.Contains(3)}");

        //System.Collections.Generic
        /* [Stack Built-In .NET & General Characteristics]:
         * 
         *  - Built-In stack implementation is based on an array
         *  
         *  [Time Complexity influence]:
         *  
         *  - Peek() - O(1)
         *  - Push() - O(N) when resizing, otherwise O(1)
         *  
         *  - All the search operations such as:
         *      Contains, Find / FindLast - O(N) - have to traverse N elements
         *  
         *  - CopyTo() - O(N)
         *  
         *  - Clear() - O(N) : resets each element in an array to the elements type default value
         *      reference types to null
         *      value types to the default values (boolean to false, int and float to zero, etc)
         * 
         *  - TrimExcess() - O(N)
         *      has effect only if less than 90% capacity is used
         *      otherwise, it won't do anything
         *      (trim capacity to actual length of the stack)
         *  

        var stack = new Stack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        Console.WriteLine($"Shoud print out 4:{stack.Peek()}");

        stack.Pop();

        Console.WriteLine($"Shoud print out 3:{stack.Peek()}");

        Console.WriteLine("Iterave over stack.");
        foreach (var i in stack)
        {
            Console.WriteLine(i);
        }

        /*
        DoublyLinkedList<int> doublyList = new DoublyLinkedList<int>();
        doublyList.AddFirst(1);
        doublyList.AddFirst(2);
        doublyList.AddFirst(3);
        doublyList.AddFirst(4);

        PrintOutDoublyLinkedList(doublyList.Head);

        static void PrintOutDoublyLinkedList(DoublyLinkedNode<int> node)
        {
            while (node != null)
            {
                Console.Write($"{node.Value} ");
                node = node.Next;
            }
        }
        */

        /*
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();


        list.RemoveByIndex(1);


        PrintOutLinkedList(list.Head);

        static void PrintOutLinkedList(Node<int> node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
        */

        /*
        Node first = new Node() { Value = 5};
        Node second = new Node() { Value = 1};

        first.Next = second;

        Node third = new Node() { Value = 3};
        second.Next = third;
        */

        /*
        //ListDemo.ApiMembers();

        /*Time consumption doesn't grows linearly
        //1Kints Time taken:0:00:00.268237
        //4Kints Time taken:0:00:17.8734063
        //8Kints Time taken:0:02:24.635803

        var ints = In.ReadInts("./Data/1Kints.txt").ToArray();

        //High resolution timer
        var watch = new Stopwatch();
        watch.Start();

        var triplets = ThreeSum.Count(ints);

        watch.Stop();

        /*
        Console.WriteLine($"The number of \"zero-sum\" triplets:{triplets}");
        Console.WriteLine($"Time taken:{watch.Elapsed:g}");
        Console.WriteLine();

        ArrayFundamentals.ArraysDemo();
        Console.WriteLine();
        ArrayFundamentals.TestBasedArray();
        Console.WriteLine();
        ArrayFundamentals.JaggedArray();
        */
    }
}
