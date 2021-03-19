using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ComparerExample
{
    class Program
    {

        static void Sort<T>(List<T> items, IComparer<T> comp = null)
        {
            if (comp == null)
            {
                comp = Comparer<T>.Default;
            }

            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < items.Count; j++)
                {

                    //if (items[i].CompareTo(items[j]) < 0)
                    if (comp.Compare(items[i], items[j]) < 0)
                    {
                        T temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }

                }

            }

        }


        class ComparableCar : IComparable<ComparableCar>
        {
            public int Hp { get; set; }

            public int CompareTo([AllowNull] ComparableCar other)
            {
                return Hp.CompareTo(other.Hp);
            }
        }


        sealed class Car
        {
            public int Hp { get; set; }
        }

        class CarHpComparer : Comparer<Car>
        {
            public override int Compare([AllowNull] Car x, [AllowNull] Car y)
            {
                return x.Hp.CompareTo(y.Hp);
            }
        }


        static void Main(string[] args)
        {
            //var list = new List<int> { 5, 6, 2, 3, 4, 6, 2, 1 };
            //var list = new List<ComparableCar>
            //{
            //    new ComparableCar{Hp = 512},
            //    new ComparableCar{Hp = 112},
            //    new ComparableCar{Hp = 712},
            //};

            var list = new List<Car>
            {
                new Car {Hp = 512},
                new Car {Hp = 712},
                new Car {Hp = 112},
            };

            Sort(list, new CarHpComparer());
        }
    }
}
