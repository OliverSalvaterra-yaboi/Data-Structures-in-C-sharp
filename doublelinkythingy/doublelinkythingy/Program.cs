using System;

namespace doublelinkythingy
{
    class Program
    {
        static void Main(string[] args)
        {
            bubblelink<Char> characters = new bubblelink<char>();
            string word = Console.ReadLine();
            string rndword = "";
            int shift = int.Parse(Console.ReadLine());

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] - shift < 97)
                {
                    rndword += (char)(123 - (97 - (word[i] - shift)));
                    continue;
                }

                rndword += (char)(word[i] - shift);
            }
            Console.WriteLine(rndword);

            Console.ReadKey();
        }
    }
}
