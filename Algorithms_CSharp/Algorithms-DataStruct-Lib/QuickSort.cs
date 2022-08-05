namespace Algorithms_DataStruct_Lib
{
    public class QuickSort : Swap
    {

        //[In-place algorithm]:
        //uses a small amount of extra memory (doesn't depend on N)

        //[Running time complexity]
        //Wrost: Quadratic O(n²) - extremely rare case
        //Average: Linearithmic O(n(logn))
        //Best: Linearithmic O(n(logn))

        //worst case occurs when the pivot element is either greatest or smallest element.
        //Suppose, if the pivot element is always the last element of the array,
        //the worst case would occur when the given array is sorted already in ascending or descending order.

        //[Unstable]:
        //if have duplicate elements,
        //there is no guarantee that the original relative ordering will be preserved

        //----
        //Divide and Conquer

        //Recursive

        //Splitting based on pivot elements
        //Elements < pivot go to its left
        //Elements > pivot go to its right

        //Pivot gets into its place in the end of each pass

        public static void Sort(int[] array)
        {
            InnerSort(0, array.Length - 1);

            //low boundary, high boundary
            void InnerSort(int low, int high)
            {
                //base case to left recursion
                if (high <= low)
                    return;

                int j = Partition(low, high);
                InnerSort(low, j - 1);
                InnerSort(j + 1, high);
            }

            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;

                int pivot = array[low];
                while (true)
                {
                    while (array[++i] < pivot)
                    {
                        if (i == high)
                            break;
                    }

                    while (pivot < array[--j])
                    {
                        if (j == low)
                            break;
                    }

                    if (i >= j)
                        break;

                    DoSwap(array, i, j);
                }
                DoSwap(array, low, j);
                return j;
            }
        }
    }
}
