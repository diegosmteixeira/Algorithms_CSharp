using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CSharp
{
    internal class ArrayFundamentals
    {
        public static void ArraysDemo()
        {
            
            //a1 variable point to the memory address of the first element 
            int[] a1;

            //arrays are not dinamic, whe need specify its lenght
            a1 = new int[10];

            //to resize an array we need to create new one and copy all the elements
            int[] a2 = new int[5];

            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };

            int[] a4 = { 1, 2, 3, 4, 5 }; //shortest syntax

            Console.Write("a3[] = ");
            for (int i = 0; i < a3.Length; i++)
            {
                Console.Write($"{a3[i]}");
            }
            Console.WriteLine();

            Console.Write("a4[] = ");
            foreach (var i in a4)
            {
                Console.Write($"{i}");
            }

            //System.Array
            //Working with array type directly

            Array myArray = new int[5];

            //which is equals:
            Array myArray2 = Array.CreateInstance(typeof(int), 5);
            myArray2.SetValue(1, 0);

            Console.WriteLine();
        }

        public static void TestBasedArray()
        {
            //creates a new array with 4 elements which starts from 1
            //Array CreateInstance(Type elementType, int[] lengths, int[] lowerBounds);
            Array myArray = Array.CreateInstance(typeof(int), new[] { 4 }, new[] { 1 });

            myArray.SetValue(2019, 1);
            myArray.SetValue(2020, 2);
            myArray.SetValue(2021, 3);
            myArray.SetValue(2022, 4);

            Console.WriteLine($"Starting index:{myArray.GetLowerBound(0)}");
            Console.WriteLine($"Ending index:{myArray.GetUpperBound(0)}");

            for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
            {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
            }
        }

        public static void MultiDimensionalArray()
        {
            int[,] r1 = new int[2, 3] {{ 1, 2, 3 }, { 4, 5, 6 }};

            int[,] r2 = { { 1, 2, 3 }, { 4, 5, 6 } }; //compiler will infer the dimensions

            //to iterate over a two dimensional arrays
            //run two nested loops

            for (int i = 0; i < r2.GetLength(0) ; i++)
            {
                for (int j = 0; j < r2.GetLength(1); i++)
                {
                    Console.WriteLine($"{r2[i, j]}");
                }
                Console.WriteLine();
            }
        }

        //A jagged array is an array whose elements are arrays, possibly of different sizes.
        //A jagged array is sometimes called an "array of arrays."
        //A jagged array allow to spare some memory, avoiding allocation of memory for unused elements 
        public static void JaggedArray()
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[4];

            Console.WriteLine("Enter the numbers for a jagged array");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    string st = Console.ReadLine();
                    jaggedArray[i][j] = int.Parse(st);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Printing the elements: ");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j]);
                    Console.Write("\0");
                }
                Console.WriteLine();
            }
        }
    }
}
