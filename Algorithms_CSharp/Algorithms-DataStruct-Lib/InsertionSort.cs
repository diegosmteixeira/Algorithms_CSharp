namespace Algorithms_DataStruct_Lib
{
    public class InsertionSort : Swap
    {
        //[In-place algorithm]:
        //uses a small amount of extra memory (doesn't depend on N)
        //couple of variables: partIndex, iterator and current unsorted value

        //Space complexity: Constant O(1)

        //[Stable]:
        //when searching for right place to insert an element
        //stop reaching an element which is less than currently unsorted element or equal to it
        //it means that in case of duplicate elements, the right most one will state to the right side

        //[Running time complexity]
        //Wrost: Quadratic O(n²) - Degrades quickly
        //Average: Quadratic O(n²)
        //Best: Quadratic O(n)

        public static void Sort(int[] array)
        {
            for(int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                int curUnsorted = array[partIndex];
                int i = 0;

                for (i = partIndex; i > 0 && array[i - 1] > curUnsorted; i--)
                {
                    array[i] = array[i - 1];
                }
                array[i] = curUnsorted;
            }

            //two inner loops (O²)
            //in many cases involves a lot of shifting operations:
            //an small element at the end of array -- this is the weak point of the Insertion Sort
        }

    }
}
