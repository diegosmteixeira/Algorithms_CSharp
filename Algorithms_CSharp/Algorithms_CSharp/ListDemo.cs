using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CSharp
{
    public class ListDemo
    {
        public class Customer
        {
            public string? Name { get; set; }
            public DateTime BirthDate { get; set; }

        }

        public static void Run()
        {
            //Generic list can hold elements of any type
            //the concrete type should be define in angle brackets
            List<int> list = new List<int>();
            LogCountAndCapacity(list);

            for (int i =0; i < 16; i++) 
            {
                list.Add(i);
                LogCountAndCapacity(list);
            }


            //when remove elements, capacity don't shrink, stay unchanged
            

            for (int i = 10; i > 0; i--)
            {
                list.RemoveAt(i);
                LogCountAndCapacity(list);
            }

            //if want to save some memory is needed to call the trim access method explicity
            //TrimExcess() will have effect only if less than 90% of capacity is used

            //Otherwise, if 90% of capacity is used, TrimExcess() will do nothing (resize will not happen)
            list.TrimExcess();
            LogCountAndCapacity(list);

            //after trim, capacity = 6
            //after add one element, capacity double = 12
            list.Add(1);
            LogCountAndCapacity(list);

            
            //Why capacity don't shrink automatically?
            //in 99% of cases, there is enough memory on the device to keep the entire list in memory
            //so we don't want to experience the hit on perfomance as the result of shrinking the underlying array

            Console.Read();
        }

        private static void LogCountAndCapacity(List<int> list)
        {
            /*
             * Count is the actual number of elements contained in the list
             * Capacity shows how many items can be contained whitin at least until the next resize
             * 
             * when reach the capacity, List doubles the length of the array where elements are stored
             * 
             * resizing is an expensive operation
             * which demonstrates the linear time complexity
             * since need to allocate a new chunk of memory
             * and copy to it the elements

            thats why resizing the underlying array at least doubles it !! 
            */

            Console.WriteLine($"Count={list.Count}. Capacity={list.Capacity}");
        }

        public static void ApiMembers()
        {
            var list = new List<int>() {1, 0, 5, 3, 4};

            //primitive values going to be sorted in the ascending order by default
            list.Sort();


            var listCustomers = new List<Customer>
            {
                new Customer {BirthDate = new DateTime(1988, 08, 12), Name = "Diego"},
                new Customer {BirthDate = new DateTime(1990, 06, 09), Name = "Mauricio"},
                new Customer {BirthDate = new DateTime(2015, 06, 09), Name = "Ann"}
            };

            /*
             * to sort reference types by a particular property,
             * then is needed to call Sort() passing a lambda expression
             * 
             * left go after right, return a positive value
             * right go before left, return a negative value
             * if they're equal, return 0 
             */

            listCustomers.Sort ((left, right) => 
            {
                if (left.BirthDate > right.BirthDate)
                {
                    return 1;
                }
                if (right.BirthDate > left.BirthDate)
                {
                    return -1;
                }
                else return 0;
            });

            /* The List<T>.Sort() method is quite slick, it call internally another
             * search method, which is Array.Sort<T>(), 
             * and what this does depend on the circunstances
             * 
             * 
             * if T is primitive type -> TrySZSort() - native implementation of the quicksort
             * --------------------------------
             * (implemented in CLR itself)
             * 
             * 
             * if T is reference type -> the behavior depends on the target plataform
             * --------------------------------
             * 
             * 
             * if (plataform == .NET Core || plataform >= .NET Framework 4.5)
             * {
             *     //combination of insertion sort, heap sort, QSort
             *     IntroSort();
             * }
             * else 
             * {
             *     //actually IntroSort as well
             *     //QSort with 32 calls - max recursion depth, if exceeded switchs to HeapSort
             *     DepthLimitedQuickSort();
             * }
             */


            /*
             * the IntroSort is implemented by the following way:
             * --------------------------------
             * if the number of elements is 16 or less, 
             * then the collection will be sorted by the InsertionSort
             * 
             * if the number of partitions exceeds 2 * log2(n)
             * then the will be sorted by HeapSort
             * 
             * otherwise, it uses QuickSort
             * 
             * [Important]: while only InsertionSort is stable
             * unless the number of elements in collection never exceeds 16 elements
             * there will be not a guarantee that the result will be Stable.
             */

            //Array.Sort demonstrates the following time complexity:
            //  O(nlogn) linearithmic on average
            //  O(n²) quadratic - extremely rare case

            //---

            //BinarySearch is the fastest searching algorithm
            //but requires from a collection to be sorted to run the search
            int indexBinSearch = list.BinarySearch(3);


            //Reverse does not sort in descending order,
            //it just reverses the current order of elements
            list.Reverse();


            //returns a ReadOnlyCollection
            //is a collection which deprecates any changes to elements
            list.AsReadOnly();

            //return an array
            int[] array = list.ToArray();


            /*
             * [Time Complexity] to List operations:
             * --------------------------------
             * 
             * Add -- O(1) if enough space, O(N) if not enough space (array will be resized)
             * 
             * Remove -- O(N) since the method has to search the list for the item that matches with the given value
             * 
             * RemoveAt -- O(N) despite index of element is known, removing an element triggers allocation of a new array
             * and copy of all elements over to a new array
             * 
             * Reverse -- O(N) takes linear time since N elements have to be swapped
             * 
             * ToArray -- O(N) takes linear time since it's actually calls a copy which is going to copy N elements
             * to a newly created array. (Based on Array.Copy)
             * 
             * Contains, IndexOf etc. -- O(N) all searching operations have to traverse N elements
             * 
             * Sort -- 99% O(nlogn) linearithmic on average, because IntroSort uses HeapSort and QuickSort.
             * O(n²) quadratic - extremely rare case -> wrost case of Insertion Sort (N <= 16 elements)
             * 
             */

            //DO NOT USE ArrayList (IList interface) - which designed to hold heterogeneous collections of objects
            //It means that is possible add to an instance of ArrayList, strings, integers, etc.
            //(hosts elements as objects of type object)

            //ArrayList Implementations is not efficient as the List implementation - so is deprecated

            //USE List<Object> instead


            Console.Read();
        }
    }
}
