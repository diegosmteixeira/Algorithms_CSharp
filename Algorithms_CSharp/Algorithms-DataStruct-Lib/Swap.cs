namespace Algorithms_DataStruct_Lib
{
    public class Swap
    {

        public static void DoSwap(int[] array, int i, int j)
        {
            if (i == j)
                return;

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}