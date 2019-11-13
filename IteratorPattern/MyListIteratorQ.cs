using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication30
{
    internal interface Iterator
    {
        bool HasNext();
        object Next();
    }

    internal interface IContainer
    {
        Iterator GetIterator();
    }

    internal class MyList : Iterator, IContainer
    {
        private int index = 0;
        private readonly int[] myIntList;
        public MyList(int[] li)
        {
            myIntList = li;
        }

        public void PrintList()
        {
            Console.WriteLine(myIntList.ToString());
        }
        public void GoToFirst() { index = 0; }

        public bool HasNext()
        {
            return index < myIntList.Length;
        }

        public object Next()
        {
            int res = myIntList[index++];
            return res;
        }

        public Iterator GetIterator()
        {
            return new MyList(myIntList);
        }
    }

    internal class MyListIteratorQ
    {
        private static int Sum(MyList m1)
        {
            Iterator iterator = m1.GetIterator();
            int result = 0;
            while (iterator.HasNext())
            {
                result += (int)iterator.Next();
            }
            return result;
        }

        private static int Max(MyList m1)
        {
            Iterator iterator = m1.GetIterator();
            int result = 0;
            while (iterator.HasNext())
            {
                int next = (int)iterator.Next();
                if (result < next)
                {
                    result = next;
                }
            }
            return result;
        }

        private static void Main(string[] args)
        {
            int[] arr = { 5, 3, 9, 3, 8, 7 };
            MyList m = new MyList(arr);
            m.PrintList();
            Console.WriteLine("Sum=" + Sum(m));
            Console.WriteLine("Max=" + Max(m));
            Console.ReadLine();
        }
    }
}
