using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Review
{
    class Program
    {

        static void Quicksort(List<int> nums)
        {
            if (nums.Count < 2)
            {
                return;
            }
            RQuickSort(nums, 0, nums.Count - 1);
        }


        static void RQuickSort(List<int> nums, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(nums, left, right);

                RQuickSort(nums, left, pivotIndex);
                RQuickSort(nums, pivotIndex + 1, right);
            }
        }

        private static int Partition(List<int> nums, int left, int right)
        {
            int l = left - 1;
            int r = right + 1;

            int pivot = nums[(left + right) / 2];

            while(true)
            {
                do
                {
                    l++;
                }
                while (nums[l] < pivot);

                do
                {
                    r--;
                }
                while (nums[r] > pivot);

                if (l >= r)
                {
                    return r;
                }

                int temp = nums[l];
                nums[l] = nums[r];
                nums[r] = temp;
            }
        }

        static void SelectionSort(List<int> nums)
        {
            int placeholder = 0;
            int smallestNum = int.MaxValue;
            int numplace = 0;

            for(int j = 0; j < nums.Count; j++)
            {
                smallestNum = int.MaxValue;
                for(int i = j; i < nums.Count; i++)
                {
                    if(nums[i] < smallestNum)
                    {
                        smallestNum = nums[i];
                        numplace = i;
                    }
                }

                placeholder = nums[j];
                nums[j] = smallestNum;
                nums[numplace] = placeholder;
            }
            
        }

        static void MergeSort(List<int> nums)
        {
            // create a left list and a right list

            if (nums.Count < 2)
            {
                return;
            }

            int mid = nums.Count/2;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for(int i = 0; i < mid; i++)
            {
                left.Add(nums[i]);
            }
            for(int i = mid; i < nums.Count; i++)
            {
                right.Add(nums[i]);
            }

            MergeSort(left);
            MergeSort(right);

            Merge(left, right, nums);

        }

        private static void Merge(List<int> left, List<int> right, List<int> list)
        {
            list.Clear();

            int leftcount = 0;
            int rightcount = 0;

            while (leftcount < left.Count && rightcount < right.Count)
            {
                if (left[leftcount] < right[rightcount])
                {
                    list.Add(left[leftcount]);
                    leftcount++;
                }
                else
                {
                    list.Add(right[rightcount]);
                    rightcount++;
                }
            }


            while(leftcount < left.Count)
            {
                list.Add(left[leftcount]);
                leftcount++;
            }

            while (rightcount < right.Count)
            {
                list.Add(right[rightcount]);
                rightcount++;
            }


            //for (int i = 0; i < left.Count + right.Count; i++)
            //{
            //    if(left[leftcount] < right[rightcount])
            //    {
            //        list.Add(left[leftcount]);
            //        leftcount++;
            //    }
            //    else
            //    {
            //        right.Add(right[rightcount]);
            //        rightcount++;
            //    }
            //}

            ;
        }

        static void QuickSort(List<int> nums, int left, int right)
        {
            if(left < right)
            {
                int piv = partition(nums, left , right-1);

                QuickSort(nums, left, piv);
                QuickSort(nums, piv+1, right);
            }
        }

        static int partition(List<int> nums, int left, int right)
        {
            int l = left-1;
            int r = right+1;
            int pivot = nums[(l + r)/2];

            while(true)
            {
                l++;
                if(nums[l] < pivot)
                {
                    l++;
                }
                r--;
                if(nums[r] > pivot)
                {
                    r--;
                }

                if(l >= r)
                {
                    return r;
                }

                int sw = nums[l];
                nums[l] = nums[r];
                nums[r] = sw;
            }
        }

        static void Main(string[] args)
        {
            var list = new List<int> { 5, 6, 78, 3, 4, 2, 3, 1 };

            QuickSort(list, 0, list.Count);

        }
    }
}
