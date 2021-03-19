using System;
using System.Collections.Generic;

namespace skippybippy
{
    class Program
    {
        static void Main(string[] args)
        {
            skippilist<int> pleeeeeeeaaaaaasework = new skippilist<int>();
            pleeeeeeeaaaaaasework.init();

            for(int i = 0; i < 10; i++)
            {
                pleeeeeeeaaaaaasework.insert(i);
            }

            pleeeeeeeaaaaaasework.delete(5);

            Console.ReadKey();
        }
    }
}
