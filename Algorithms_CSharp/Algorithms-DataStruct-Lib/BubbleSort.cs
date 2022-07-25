namespace Algorithms_DataStruct_Lib
{
    public class BubbleSort
    {

        //[In-place algorithm]:
        //-no extra space requirements-
        //an in-place algorithm is an algorithm which transforms input using no auxiliary data structure.
        
        //Space complexity: Constant O(1)


        //[Stable]:
        //sorting algorithms preserve the relative order of equal elements
        //maintains the position of two equals elements relative to one another:
        //an 5 which index 3 will be placed before an 5 of index 7


        //[Running time complexity]
        //Wrost: Quadratic O(n²) - it means for sort 100 items peform 10000 steps -
        //Average: Quadratic O(n²)
        //Best: Linear O(n)

        //Implementation:
        public static void Sort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                for (int i = 0; i < partIndex; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                    }

                }
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            if (i == j)
                return;

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }


    }
}
