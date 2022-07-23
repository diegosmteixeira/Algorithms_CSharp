using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CSharp
{
    internal class ArrayOperations
    {
        
        public static void ArrayTimeComplexity(object[] array) 
        {
            //Access by index O(1)
            Console.WriteLine("Access by index O(1): ");
            Console.WriteLine(array[0]);

            int length = array.Length;
            object elementINeedToFind = new object();

            //Searching for an element O(N)
            Console.WriteLine("Searching for an element O(N)");
            for (int i = 0; i < length; i++)
            {
                if (array[i] == elementINeedToFind)
                {
                    Console.WriteLine("Exists/Found");
                }
            }

            //Add to a full array O(N)
            var bigArray = new int[length * 2];
            Array.Copy(array, bigArray, length);
            bigArray[length + 1] = 10;

            //Add to the end when there's some space O(1)
            array[length - 1] = 10;

            //Insert / Update at index O(1)
            //Removing element by index O(1)

            //Remove an element by null-ing O(1)
            array[6] = null;
        }

        public static void RemoveAt(object[] array, int index)
        {

            //Remove an element by shifting elements - O(N)
            //(just demonstration for purpose)
            var newArray = new object[array.Length - 1];
            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, array.Length - 1 - index);

        }
    }
}
