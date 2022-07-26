namespace Algorithms_DataStruct_Lib
{
    public class SelectionSort : Swap
    {
        //[In-place algorithm]:
        //uses a small amount of extra memory (doesn't depend on N)

        //Space complexity: Constant O(1)

        //[Unstable]:
        //if have duplicate elements,
        //there is no guarantee that the original relative ordering will be preserved

        //[Running time complexity]
        //Wrost: Quadratic O(n²) - it means for sort 100 items peform 10000 steps -
        //Average: Quadratic O(n²)
        //Best: Quadratic O(n²)

        //is usually a little bit faster than Bubble Sort
        //due to the fact that the number of swaps is much less

        public static void Sort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {

                int largestAt = 0;

                //is minus or equal (i <= partIndex) because is visiting all elements
                //and not only neighbors like BubbleSort do
                for (int i = 1; i <= partIndex; i++)
                {
                    if (array[i] > array[largestAt])
                    {
                        largestAt = i;
                    }
                }
                DoSwap(array, largestAt, partIndex);
            }
        }
    }
}
