using System;

namespace SupergoodBesTaiprogram
{
    class Program
    {
        static void Main(string[] args)
        {
            tree<int> tree = new tree<int>();

            for (int i = 0; i < 10; i++)
            {
                tree.insert(i);
            }

            Console.WriteLine(tree.inOrder());

            Console.ReadKey();
        }
    }
}
