using System.IO;
using System.Diagnostics;
using Algorithms_DataStruct_Lib;

namespace Algorithms_CSharp
{
    internal partial class Program
    {

        static void Main(string[] args)
        {
            /*Time consumption doesn't grows linearly*/
            //1Kints Time taken:0:00:00.268237
            //4Kints Time taken:0:00:17.8734063
            //8Kints Time taken:0:02:24.635803

            var ints = In.ReadInts("./Data/8Kints.txt").ToArray();

            //High resolution timer
            var watch = new Stopwatch();
            watch.Start();

            var triplets = ThreeSum.Count(ints);

            watch.Stop();

            Console.WriteLine($"The number of \"zero-sum\" triplets:{triplets}");
            Console.WriteLine($"Time taken:{watch.Elapsed:g}");
        }
    }
}