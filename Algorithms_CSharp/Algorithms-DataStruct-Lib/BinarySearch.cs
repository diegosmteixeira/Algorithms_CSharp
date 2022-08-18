namespace Algorithms_DataStruct_Lib
{
    /*
     *  - The idea is to divide the problem at each step
     * 
     *  - Data must be sorted before search
     *  
     *  - Takes element in the middle and compares against the search value
     *  
     *      If equal : done
     *      If element > value : search left half
     *      If element < value : search right half
     *      
     *  - repeat log2(n) steps
     *  
     * 
     * If you need to run searching many times, then it's meaningful 
     * and not very costly to run a sorting process before searching
     * 
     * In such cases, the amount of time spent on sorting will be negligible,
     * comparing to the amount of time will be saved running search much faster
     */

    public class BinarySearch
    {
        //[Note]: Recursive goals are not cost free.

        //A recursive implementation is always slower than the iterative one

        //Recursive implementation
        public static int RecursiveBinarySearch(int[] array, int value)
        {
            return InternalRecursiveBinarySearch(0, array.Length);

            int InternalRecursiveBinarySearch(int low, int high)
            {
                if(low >= high)
                {
                    return -1;
                }

                int mid = (low + high) / 2;

                if (array[mid] == value)
                {
                    return mid;
                }

                if (array[mid] < value)
                {
                    return InternalRecursiveBinarySearch(mid + 1, high);
                }
                else
                {
                    return InternalRecursiveBinarySearch(low, mid);
                }
            }
        }

        //Iterative implementation
        public static int Searching(int[] array, int value)
        {
            int low = 0;
            int high = array.Length;

            while (low < high)
            {
                //working with integers the decimal part will be trimmed
                int mid = (low + high) / 2;

                if(array[mid] == value)
                {
                    return mid;
                }
                if (array[mid] < value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return -1;
        }
    }
}
