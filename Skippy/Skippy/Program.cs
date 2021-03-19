using System;
using System.Collections;

namespace Skippy
{

    //class A : ICollection
    //{

    //    int[] test = new int[] { 1, 3, 21, 3, 2, 2, 1, 23, 3 };
    //    public int Count => throw new NotImplementedException();

    //    public bool IsSynchronized => throw new NotImplementedException();

    //    public object SyncRoot => throw new NotImplementedException();

    //    public void CopyTo(Array array, int index)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerator GetEnumerator()
    //    {
    //        for(int i = 0; i < test.Length; i++)
    //        {
    //            yield return test[i];
    //        }
    //    }
    //}
    class Program 
    {
        static void Main(string[] args)
        {
            Skip<int> skip = new Skippy.Skip<int>();
            Random gen = new Random();

            for(int i = 1; i < 10; i++)
            {
                skip.add(i);
            }
            for (int i = 0; i < 20; i++)
            {
                skip.add(gen.Next(0, 10000));
            }

            for(int i = 2; i < 6; i++)
            {
                skip.remove(i);
            }

            skip.search(7);

            foreach (var item in skip)
            {
                Console.WriteLine(item);
            }
        }
    }
}
