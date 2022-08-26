using Algorithms_DataStruct_Lib.Trees;

namespace Algorithms_CSharp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var bstTest = new BinarySearchTree<int>();

            bstTest.Insert(37);
            bstTest.Insert(24);
            bstTest.Insert(17);
            bstTest.Insert(28);
            bstTest.Insert(31);
            bstTest.Insert(29);
            bstTest.Insert(15);
            bstTest.Insert(12);
            bstTest.Insert(20);

            foreach (var i in bstTest.TraverseInOrder())
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            Console.WriteLine(bstTest.Min());
            Console.WriteLine(bstTest.Max());
            Console.WriteLine(bstTest.Get(20).Value);

            Console.Read();
        }
    }
}