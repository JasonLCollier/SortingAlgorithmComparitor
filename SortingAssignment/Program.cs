using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Generate gen;
            List listOfSize;
            int[] sizes = { 10, 50, 100, 500, 1000, 2500, 5000, 7500, 10000, 15000, 20000, 30000, 50000 };

            //Test all algorithms on a randomly sorted array
            Console.WriteLine("Randomly sorted arrays:");
            StreamWriter Output = new StreamWriter("RandomArray.txt");
            for (int x = 0; x < sizes.Length; x++)
            {
                gen = new Generate(sizes[x]);
                listOfSize = new List(gen.RandomArray());
                Results(Output, listOfSize, sizes[x]);
            }
            Output.Close();

            //Test all algorithms on an already sorted (ascending) array
            Console.WriteLine("Ascending arrays:");
            Output = new StreamWriter("SortedArray.txt");
            for (int x = 0; x < sizes.Length; x++)
            {
                gen = new Generate(sizes[x]);
                listOfSize = new List(gen.SortedArray());
                Results(Output, listOfSize, sizes[x]);
            }
            Output.Close();

            //Test all algorithms on a reversed array
            Console.WriteLine("Reverse sorted arrays:");
            Output = new StreamWriter("ReversedArray.txt");
            for (int x = 0; x < sizes.Length; x++)
            {
                gen = new Generate(sizes[x]);
                listOfSize = new List(gen.ReversedArray());
                Results(Output, listOfSize, sizes[x]);
            }
            Output.Close();

            //Test all algorithms on an array full of duplicates
            Console.WriteLine("Arrays full of duplicates:");
            Output = new StreamWriter("DuplicatesArray.txt");
            for (int x = 0; x < sizes.Length; x++)
            {
                gen = new Generate(sizes[x]);
                listOfSize = new List(gen.DuplicatesArray());
                Results(Output, listOfSize, sizes[x]);
            }
            Output.Close();

            //testSorting();

            Console.WriteLine("Results captured successfully");
            Console.ReadLine();
        }

        public static void Results(StreamWriter Output, List curList, int amount)
        {
            
            long time1 = curList.SelectionSort();
            long time2;
            if (amount < 10000)
                time2 = curList.SelectionSortRecursion();
            else
                time2 = 0;
            long time3 = curList.DBLSelectionSort();
            long time4 = curList.BucketSort();

            Console.WriteLine(amount.ToString() + " Completed successfully.");
            Output.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", Convert.ToString(amount), Convert.ToString(time1), Convert.ToString(time2), Convert.ToString(time3), Convert.ToString(time4));
        }

        public static void testSorting()
        {
            Generate genTest = new Generate(50);
            ArrayList test1 = genTest.RandomArray();
            ArrayList test2 = genTest.SortedArray();
            ArrayList test3 = genTest.ReversedArray();
            ArrayList test4 = genTest.DuplicatesArray();

            Console.WriteLine("Random Array: ");
            List test = new List(test1);
            test.Display(test1);
            test.SelectionSort();
            test.SelectionSortRecursion();
            test.DBLSelectionSort();
            test.BucketSort();

            Console.WriteLine("\nSorted Array: ");
            test = new List(test2);
            test.Display(test2);
            test.SelectionSort();
            test.SelectionSortRecursion();
            test.DBLSelectionSort();
            test.BucketSort();

            Console.WriteLine("\nReversed Array: ");
            test = new List(test3);
            test.Display(test3);
            test.SelectionSort();
            test.SelectionSortRecursion();
            test.DBLSelectionSort();
            test.BucketSort();

            Console.WriteLine("\nDuplicates Array: ");
            test = new List(test4);
            test.Display(test4);
            test.SelectionSort();
            test.SelectionSortRecursion();
            test.DBLSelectionSort();
            test.BucketSort();
        }
    }
}
