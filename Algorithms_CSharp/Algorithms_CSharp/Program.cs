using System.IO;
using System.Diagnostics;
using Algorithms_DataStruct_Lib;

namespace Algorithms_CSharp
{
    internal partial class Program
    {
        class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime BirthDate { get; set; }
        }
        private static bool Exists(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number) 
                    return true;
            }
            return false;
        }

        //Linear Search - Time Complexity O(N)
        private static int IndexOf(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return i;
            }
            return -1;
        }

        public class CustomersComparer : IEqualityComparer<Customer>
        {
            bool IEqualityComparer<Customer>.Equals(Customer? x, Customer? y) => x.Age == y.Age && x.Name == y.Name;

            //Delegate GetHashCode to built-in mechanism
            int IEqualityComparer<Customer>.GetHashCode(Customer obj) => obj.GetHashCode();
        }

        static void Main(string[] args)
        {
            var customersList = new List<Customer>()
            {
                new Customer { Age = 3, Name = "Ann"}, 
                new Customer { Age = 16, Name = "Bill"}, 
                new Customer { Age = 20, Name = "Rose"}, 
                new Customer { Age = 14, Name = "Rob"}, 
                new Customer { Age = 28, Name = "Bill"}, 
                new Customer { Age = 14, Name = "John"},
            };

            var intList = new List<int>() { 1, 4, 2, 7, 5, 9, 12, 3, 2, 1 };

            //linear search method (list)
            bool contains = intList.Contains(3);

            //if pass contains on a List of custom type, then you may want to pass a second argument
            //which should be an object which implements the equality compare
            bool contains2 = customersList.Contains(new Customer { Age = 14, Name = "Rob" }, new CustomersComparer());

            bool exists = customersList.Exists(customer => customer.Age == 28);

            int min = intList.Min();
            int max = intList.Max();

            int youngestCustomerAge = customersList.Min(customer => customer.Age);

            Customer bill = customersList.Find(customer => customer.Name == "Bill");
            Customer lastBill = customersList.FindLast(customer => customer.Name == "Bill");
            Customer lastBill2 = customersList.Last(customer => customer.Name == "Bill");

            List<Customer> customers = customersList.FindAll(customer => customer.Age > 18);
            IEnumerable<Customer> whereAge = customersList.Where(customer => customer.Age > 18);

            int index1 = customersList.FindIndex(customer => customer.Age == 14);
            int lastIndex = customersList.FindIndex(customer => customer.Age > 18);

            int indexOf = intList.IndexOf(2);
            int lastindexOf = intList.LastIndexOf(2);

            //from list
            bool isTrueForAll = customersList.TrueForAll(customer => customer.Age > 10);

            //from linq
            bool all = customersList.All(customer => customer.Age > 18);
            bool allThereAny = customersList.Any(customer => customer.Age == 3);
            int count = customersList.Count(customer => customer.Age > 18);

            Customer firstBill = customersList.First(customer => customer.Name == "Bill");
            Customer singleAnn = customersList.Single(customer => customer.Name == "Ann");

            Console.Read();
        }

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