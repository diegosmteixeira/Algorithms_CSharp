namespace Algorithms_DataStruct_Lib
{
    public class MergeSort : Swap
    {
        //[Not an in-place algorithm]:
        //uses much memory (amount depends on n)

        //allocating small auxiliary arrays at each merge
        //or a big auxiliary array used for all the merging (better performance view)

        //[Stable]:
        //in the classic implementation
        //(there are implementations of Merge Sort which make it unstable)

        //is stable because when we compare elements from the left and right side
        //the left element will go first at the auxiliary array

        //[Running time complexity]: - linearithmic
        //Wrost: O(nlogn)
        //Average: O(nlogn)
        //Best: O(nlogn)

        //[Space Complexity]:
        //O(n)

        public static void Sort(int[] array)
        {
            int[] aux = new int[array.Length];


            //C# 7 Local Functions - InnerSort and Merge
            //dont need pass array itself because the local function will have access to array
            InnerSort(0, array.Length - 1);

            void InnerSort(int low, int high)
            {
                if (high <= low)
                    return;

                int mid = (high + low) / 2;

                //split left side
                InnerSort(low, mid);

                //split right side
                InnerSort(mid + 1, high);

                //if had defined the merge method outside of main Sort method,
                //would need to pass original array aswell

                //its possible create small auxiliary arrays whitin merge phase
                //and it would save some memory,
                //but the performance will degrade since allocation takes some time
                //if there plenty memory on the machine that is going to run
                //is better to create big auxiliary array at once,
                //in the beggining of the merge sort method.
                Merge(low, mid, high);
            }

            void Merge(int low, int mid, int high)
            {
                //this verification speed up the implementation
                //detects situtation which array is already sorted
                if (array[mid] <= array[mid + 1])
                    return;

                int i = low; //first element of the left array
                int j = mid + 1; //first element of the right array

                Array.Copy(array,/*from*/ low, /*into*/ aux, /*start*/ low, /*length*/ high - low + 1);

                for (int k = low; k <= high; k++)
                {
                    if (i > mid) array[k] = aux[j++];
                    else if(j > high) array[k] = aux[i++];
                    else if(array[j] < aux[i])
                        array[k] = aux[j++];
                    else array[k] = aux[i++];
                }
            }
        }
    }
}
