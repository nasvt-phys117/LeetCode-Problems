// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.Globalization;

Console.WriteLine("Hello, World!");

int[] arr1 = { 0, 0, 0 };
int[] arr2 = { 1, 2, 3 };

int nOfElements_1 = NonZeroElements(arr1);
int nOfElements_2 = NonZeroElements(arr2);

Console.WriteLine($"Array no.1 is");
foreach (int i in arr1)
    Console.Write("\t{0}", i);
Console.WriteLine("");
Console.WriteLine("With m = {0} ", nOfElements_1);
Console.WriteLine("");
Console.WriteLine($"Array no.2 is");
foreach (int i in arr2)
    Console.Write("\t{0}", i);
Console.WriteLine("");
Console.WriteLine("With n = {0} ", nOfElements_2);
Console.WriteLine("");

Merge(arr1, nOfElements_1, arr2, nOfElements_2);

Console.WriteLine($"Merged Array no.1 is");
foreach (int i in arr1)
    Console.Write("\t{0}", i);

int NonZeroElements(int[] arr)
{
    int nonZeroElementNumber = 0;
    int initArrayLength = arr.Length;
    int zeroElementNumber = (arr.Where(x => x == 0)).Count();

    nonZeroElementNumber = initArrayLength - zeroElementNumber;
    return nonZeroElementNumber;
}

void Merge(int[] nums1, int m, int[] nums2, int n)
{
    if (n > 200 || n == 0)
        return;
    
    if (m == 0)
    {
        for(int i = 0; i < n; i++)
        {
            nums1[i] = nums2[i];
        }
        return;
    }

    if (nums1[m - 1] <= nums2[0])
    {
        for (int i = m; i <= m + n - 1; i++)
        {
            nums1[i] = nums2[i - m];
        }
    }
    else
    {

        while (m > 0 && n > 0)
        {
            if (nums1[m - 1] > nums2[n - 1])
            {
                nums1[m + n - 1] = nums1[m - 1];
                m--;
            }
            else
            {
                nums1[m + n - 1] = nums2[n - 1];
                n--;
            }
        }
        while (n > 0)
        {
            nums1[m + n - 1] = nums2[n - 1];
            n--;
        }
    }
}