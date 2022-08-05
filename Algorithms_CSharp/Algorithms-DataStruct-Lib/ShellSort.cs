namespace Algorithms_DataStruct_Lib
{
    public class ShellSort : Swap
    {

        //[In-place algorithm]:
        //uses a small amount of extra memory (doesn't depend on N)

        //Space complexity: Constant O(1)

        //[Unstable]:
        //because of the pre-sorting phase
        //when compare elements distant from each other,
        //pre-sorting easily mixes all the positions of all duplicate elements

        //[Running time complexity]
        //The time complexity of Shell Sort depends on the gap sequence.
        //Its best-case time complexity is O(n* logn) and the worst case is O(n*(log2n)²)

        //Wrost: O(n(logn)²)
        //Average: O(n(logn)²)
        //Best: O(n(logn))

        //---

        //Based on Insertion Sort - insertion sort is fast on pre-sorted arrays
        //Basic idea: pre-sort the input and switch to Insertion Sort

        //Gap is used for pre-sorting: swap distant elements
        //Algorithm starts with a "large" gap and gradually reduces it
        //When gap = 1, Insertion Sort finishes the sorting process

        public static void Sort(int[] array)
        {
            int gap = 1;
            while (gap < array.Length / 3)
            {
                gap = gap * 3 + 1;
            }

            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    for (int j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                    {
                        DoSwap(array, j, j - gap);
                    }
                }
                gap /= 3;
            }
        }
    }
}
