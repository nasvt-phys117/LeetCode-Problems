// See https://aka.ms/new-console-template for more information
using System;
int[] array1 = {0,1,2,2,3,0,4,2};
int removeValue = 2;

Console.WriteLine("The original array is: ");
foreach (int i in array1)
    Console.Write("\t{0}", i);
Console.WriteLine("");

Console.WriteLine("Value to be removed = {0}", removeValue);

Console.WriteLine("{0}", RemoveElement(array1, removeValue));

Console.WriteLine("The modified array is: ");
foreach (int i in array1)
    Console.Write("\t{0}", i);
Console.WriteLine("");

int RemoveElement(int[] nums, int val)
{
    //Constraints
    if (nums.Length > 100)
        return -1;
    foreach (int i in nums)
    {
        if (i > 50)
            return -1;
    }
    if (val < 0 || val > 100)
        return -1;

    //Main funtionality
    int counter = 0;
    int n = 0;
    foreach (int i in nums)
    {
        if (i == val)
            counter++;
    }
    n = counter;
    while (n > 0)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            int temp = -1;
            if (nums[i] == val)
            {
                temp = nums[i + 1];
                nums[i + 1] = nums[i];
                nums[i] = temp;
            }
        }
        n--;
    }
    Array.Sort(nums, 0, nums.Length - counter);
    foreach (int i in nums)
        Console.Write("\t{0}", i);
    Console.WriteLine("");
return nums.Length - counter;
}