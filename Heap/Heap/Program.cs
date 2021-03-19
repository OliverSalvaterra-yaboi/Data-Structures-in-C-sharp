using System;
using System.Collections.Generic;
using System.Text;

namespace HeapsonHeaps
{
    public class Heap<T>
    {
        public List<T> list = new List<T>();

        private IComparer<T> comparer;
        public Heap(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Count => list.Count;

        public void Insert(T val)
        {
            list.Add(val);

            up(list.Count - 1);
        }

        public bool contains(T val)
        {
            foreach (var item in list)
            {
                if (comparer.Compare(item, val) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void up(int i)
        {
            if (i <= 0)
            {
                return;
            }

            if (comparer.Compare(list[i], list[(i - 1) / 2]) < 0)
            {
                T temp = list[(i - 1) / 2];
                list[(i - 1) / 2] = list[i];
                list[i] = temp;
                i = (i - 1) / 2;
            }
            else
            {
                return;
            }

            up(i);
        }

        public T Pop()
        {
            T temp = list[0];
            list[0] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Down(0);

            return temp;
        }

        private void Down(int i)
        {
            //int leftChildIndex = i * 2 + 1;
            //if (leftChildIndex >= list.Count)
            //{
            //    return;
            //}

            //int potentialSwapIndex = leftChildIndex;
            //int rightChildIndex = i * 2 + 2;

            //if (rightChildIndex < list.Count && list[rightChildIndex] < list[leftChildIndex])
            //{
            //    potentialSwapIndex = rightChildIndex;
            //}

            //if (list[i] > list[potentialSwapIndex])
            //{
            //    int temp = list[i];
            //    list[i] = list[potentialSwapIndex];
            //    list[potentialSwapIndex] = temp;

            //    down(potentialSwapIndex);
            //}

            int lci = i * 2 + 1;
            if (lci > list.Count - 1)
            {
                return;
            }

            int poti = lci;
            int rci = i * 2 + 2;
            if (rci < list.Count && comparer.Compare(list[lci], list[rci]) > 0)
            {
                poti = rci;
            }

            if (comparer.Compare(list[i], list[poti]) > 0)
            {
                T temp = list[i];
                list[i] = list[poti];
                list[poti] = temp;
                Down(poti);
            }
        }
    }
}
