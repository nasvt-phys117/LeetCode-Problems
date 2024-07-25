// See https://aka.ms/new-console-template for more information
int[] arr = { 1, 2, 3, 3, 5, 6, 6, 6, 6 };
Console.WriteLine($"Array");
foreach (int i in arr)
    Console.Write("\t{0}", i);
Console.WriteLine("");

Console.WriteLine("{0}", RemoveDuplicates(arr));

Console.WriteLine("The modified array is: ");
foreach (int i in arr)
    Console.Write("\t{0}", i);
Console.WriteLine("");

int RemoveDuplicates(int[] nums)
{
    //My solution was very inefficient - using the hints from Leetcode
    //Constraints and basic case
    if (nums.Length == 0 || nums.Length > 30000)
        return -1;

    foreach (int i in nums)
    {
        if (Math.Abs(i) > 100)
            return -1;
    }

    if (nums.Length == 1)
        return 1;

    int uniqueIdx = 0;
    for (int currentIdx = 1; currentIdx < nums.Length; currentIdx++)
    {
        //bypass duplicates
        if (nums[currentIdx] == nums[uniqueIdx])
            continue;
        //
        if (nums[currentIdx] != nums[uniqueIdx])
        {
            uniqueIdx++;
            nums[uniqueIdx] = nums[currentIdx];
        }
    }
    return uniqueIdx + 1;
}

int RemoveDuplicatesNasos(int[] nums)
{
    //Constraints and basic case
    if (nums.Length == 0 || nums.Length > 30000)
        return -1;

    foreach (int i in nums)
    {
        if (Math.Abs(i) > 100)
            return -1;
    }

    if (nums.Length == 1)
        return 1;

    //Main Functionality
    bool hasDuplicates = false;
    int duplicateValue = nums[0];
    for (int i = 0; i < nums.Length - 1; i++)
    {
        int nAppearance = 0;
        if (nums[i] == duplicateValue)
        {
            foreach (int j in nums)
            {
                if (j == duplicateValue)
                {
                    nAppearance++;
                }
            }
            if (nAppearance > 1)
                hasDuplicates = true;

            while (nAppearance > 1)
            {
                int tempVal = duplicateValue;
                for (int j = i; j < nums.Length - nAppearance; j++)
                {
                    tempVal = nums[j + nAppearance];
                    nums[j + nAppearance] = nums[j + nAppearance - 1];
                    nums[j + nAppearance - 1] = tempVal;
                }
                nAppearance--;
            }

        }
        if (nums[i + 1] != duplicateValue)
        {
            duplicateValue = nums[i + 1];
            continue;
        }
    }
    int index = 0;
    if (hasDuplicates)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i + 1] <= nums[i])
            {
                index = i + 1;
                break;
            }
        }
    }
    else index = nums.Length;
    return index;
}