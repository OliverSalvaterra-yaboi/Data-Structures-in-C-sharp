using System;

namespace Imreallydoingbubbledsortagain
{
    class Program
    {
        static void Main(string[] args)
        {
            int placeholder = 0;
            Random rnd = new Random();
            bool isdone = false;
            int[] nums = new int[100]; 

            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = rnd.Next(1, 100);
            }

            while(true)
            {
                if(isdone)
                {
                    break;
                }
                isdone = true;
                for(int i = 0; i < nums.Length - 1; i++)
                {
                    if(nums[i] > nums[i+1])
                    {
                        placeholder = nums[i];
                        nums[i] = nums[i+1];
                        nums[i + 1] = placeholder;
                        isdone = false;
                    }
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }

            Console.ReadKey();
        }
    }
}
