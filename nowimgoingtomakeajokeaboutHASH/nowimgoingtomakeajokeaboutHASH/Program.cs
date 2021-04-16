using System;
using System.Collections.Generic;

namespace nowimgoingtomakeajokeaboutHASH
{
    class bloom<T> 
    {
        private int k = 53467819;
        private bool[] filter;
        public HashSet<Func<T, int>> set = new HashSet<Func<T, int>>();

        public bloom(int m)
        {
            filter = new bool[m];
            set.Add(hashOne);
            set.Add(hashTwo);
            set.Add(hashThree);
        }

        public int hashOne(T obj)
        {
            return obj.GetHashCode();
        }

        public int hashTwo(T obj)
        {
            return obj.GetHashCode() + k.GetHashCode();
        }

        public int hashThree(T obj)
        {
            return (hashTwo(obj) / k) + k.GetHashCode();
        }

        public void addHash(Func<T, int> func)
        {
            set.Add(func);
        }

        public void insert(T obj)
        {
            foreach(var f in set)
            {
                filter[f(obj)] = true;
            }     
        }

        public bool probContains(T obj)
        {
            foreach(var f in set)
            {
                if (!filter[f(obj)])
                {
                    return false;
                }
            }
            return true;
        }
    }
    
    class Program
    {

        static void func1(int val)
        {
            Console.WriteLine("test");
        }
        static void Main(string[] args)
        {
            Action<int> myAction = func1;
            myAction?.Invoke(3);

            Func<int, int> myFunc = (x => x + 10);

            Console.WriteLine(myFunc?.Invoke(23));
            Console.WriteLine("Hello World!");
        }
    }
}
