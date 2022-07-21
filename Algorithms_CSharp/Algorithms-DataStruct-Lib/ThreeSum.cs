namespace Algorithms_DataStruct_Lib
{
    public class ThreeSum
    {
        public static int Count(int[] nums)
        {
            int n = nums.Length;
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            counter++;
                        }
                    }
                }
            }
            return counter;
        }
    }
}