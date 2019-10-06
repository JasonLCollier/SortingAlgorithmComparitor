using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAssignment
{
    class List
    {
        private ArrayList data;

        public List (ArrayList input)
        {
            data = input;
        }

        private ArrayList cloneList()
        {
            ArrayList cloneData = new ArrayList();
            foreach (string temp in data)
                cloneData.Add(temp);
            return cloneData;
        }

        public void Display(ArrayList list)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            for (int x = 0; x < list.Count; x++)
                Console.Write(list[x] + "\t");
            Console.WriteLine();
        }

        private void Swap(ArrayList list, int a, int b)
        {
            object temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public long SelectionSort()
        {
            ArrayList copyList = cloneList();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int min;
            for (int i = 0; i < copyList.Count - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < copyList.Count; j++)
                {
                    if (((string)copyList[j]).CompareTo((string)copyList[min]) < 0)
                        min = j;
                }
                Swap(copyList, i, min);
            }
            sw.Stop();
            //Display(copyList);
            return sw.ElapsedTicks;
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public long SelectionSortRecursion()
        {
            ArrayList copyList = cloneList();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            doSlnSort(copyList, 0);
            sw.Stop();
            //Display(copyList);
            return sw.ElapsedTicks;
        }

        private void doSlnSort(ArrayList copyList, int curIndex)
        {
            if (curIndex == copyList.Count - 1)
                return;
            int minIndex = getMinIndex(copyList, curIndex);
            Swap(copyList, curIndex, minIndex);
            doSlnSort(copyList, curIndex + 1);
        }

        private int getMinIndex(ArrayList copyList, int i)
        {

            if (i < copyList.Count - 1)
            {
                int restOfList = getMinIndex(copyList, i + 1);
                if (((string)copyList[i]).CompareTo((string)copyList[restOfList]) < 0)
                    return i;
                else
                    return restOfList;
            }
            return i;
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public long DBLSelectionSort()
        {
            ArrayList copyList = cloneList();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int min, max;

            double middle = copyList.Count / 2;
            double limit = Math.Ceiling(middle);

            for (int i = 0; i < limit; i++)
            {
                min = i;
                for (int j = i + 1; j < copyList.Count - i; j++)
                {
                    if (((string)copyList[j]).CompareTo((string)copyList[min]) < 0)
                        min = j;
                }
                if (i != min)
                    Swap(copyList, i, min);

                max = (copyList.Count - 1) - i;
                for (int j = (copyList.Count - 2) - i; j >= 1 + i; j--)
                {
                    if (((string)copyList[j]).CompareTo((string)copyList[max]) > 0)
                        max = j;
                }
                if (((copyList.Count - 1) - i)!=max)
                    Swap(copyList, (copyList.Count - 1) - i, max);
            }
            sw.Stop();
            //Display(copyList);
            return sw.ElapsedTicks;
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private int getNumericalValue(object obj)
        {
            char[] chars = (Convert.ToString(obj)).ToCharArray();
            if (chars[0] >= 97 && chars[0] <= 122)
                return chars[0] - 32;
            return chars[0];
        }

        private int findIndex(object obj, ArrayList curBucket)
        {
            int index = 0;
            if (curBucket.Count == 0)
                return index;
            while (((string)obj).CompareTo((string)curBucket[index]) > 0)
            {
                index++;
                if (index == curBucket.Count)
                    break;
            }
            return index;
        }

        public long BucketSort()
        {
            ArrayList List = cloneList();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //Number of buckets
            int numBuckets = Convert.ToInt16(0.1 * List.Count);
            if (numBuckets < 3)
                numBuckets = 3;

            //Find Bucket Range
            int max = -1;
            int min = int.MaxValue;
            for (int x = 0; x < List.Count; x++)
            {
                int curVal = getNumericalValue(List[x]);
                if (curVal > max)
                    max = curVal;
                if (curVal < min)
                    min = curVal;
            }
            int size = ((max - min) / numBuckets) + 1;

            //Initialise Buclets
            ArrayList[] Buckets = new ArrayList[numBuckets];
            for (int i = 0; i < Buckets.Length; i++)
                Buckets[i] = new ArrayList();

            for (int i = 0; i < List.Count; i++)
            {
                //Find bucket current value must be placed in
                int curVal = getNumericalValue(List[i]);
                int bucket = (curVal - min) / size;
                ArrayList curBucket = Buckets[bucket];

                //Add current value to correct place in bucket
                int pos = findIndex(List[i], curBucket);
                curBucket.Insert(pos, List[i]);
            }

            //Gather all values
            int index = 0;
            for (int i = 0; i < Buckets.Length; i++)
            {
                foreach (object cur in Buckets[i])
                {
                    List[index] = cur;
                    index++;
                }
            }
            sw.Stop();
            //Display(List);
            return sw.ElapsedTicks;
        }
    }
}
