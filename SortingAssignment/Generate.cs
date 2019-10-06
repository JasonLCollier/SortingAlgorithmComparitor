using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAssignment
{
    class Generate
    {
        int size;
        Random elem = new Random();

        public Generate(int input)
        {
            size = input;
        }

        private string Element()
        {
            string alphaNum = "";
            string[] charArr = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            int amountChar = 0;
            int amountNum = 0;
            
            while (amountChar + amountNum < 9)
            {
                int next = elem.Next(0, 2);
                if (next == 0 && amountNum <= 6)
                {
                    int randomNum = elem.Next(0, 10);
                    alphaNum += randomNum.ToString();
                    amountNum++;
                }
                else if (next == 1 && amountChar < 3)
                {
                    int randomIndex = elem.Next(0, 52);
                    alphaNum += charArr[randomIndex];
                    amountChar++;
                }
            }
            return alphaNum;
        }

        public ArrayList RandomArray()
        {
            ArrayList array = new ArrayList();
            for (int x = 0; x < size; x++)
            {
                array.Add(Element());
            }
            return array;
        }

        public ArrayList SortedArray()
        {
            ArrayList array = new ArrayList();
            for (int x = 0; x < size; x++)
            {
                if (x < 10)
                    array.Add("00000" + Convert.ToString(x) + "abc");
                else if (x < 100)
                    array.Add("0000" + Convert.ToString(x) + "abc");
                else if (x < 1000)
                    array.Add("000" + Convert.ToString(x) + "abc");
                else if (x < 10000)
                    array.Add("00" + Convert.ToString(x) + "abc");
                else
                    array.Add("0" + Convert.ToString(x) + "abc");
            }
            return array;
        }

        public ArrayList ReversedArray()
        {
            ArrayList array = SortedArray();
            array.Reverse();
            return array;
        }

        public ArrayList DuplicatesArray()
        {
            ArrayList array = new ArrayList();
            string element = Element();
            for (int x = 0; x < size; x++)
            {
                array.Add(element);
            }
            return array;
        }
    }
}
