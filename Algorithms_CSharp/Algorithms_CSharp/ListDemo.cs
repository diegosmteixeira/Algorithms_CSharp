using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CSharp
{
    public class ListDemo
    {
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
            //Count is the actual number of elements contained in the list
            //Capacity shows how many items can be contained whitin at least until the next resize

            //when reach the capacity,
            //List doubles the length of the array where elements are stored

            //resizing is an expensive operation
            //which demonstrates the linear time complexity
            //since need to allocate a new chunk of memory
            //and copy to it the elements

            //thats why resizing the underlying array at least doubles it !!

            Console.WriteLine($"Count={list.Count}. Capacity={list.Capacity}");
        }
    }
}
