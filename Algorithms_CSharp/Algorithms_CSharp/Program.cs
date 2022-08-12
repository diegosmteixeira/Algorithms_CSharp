using System.IO;
using System.Diagnostics;
using Algorithms_DataStruct_Lib;

namespace Algorithms_CSharp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
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

            Console.Read();
        }


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