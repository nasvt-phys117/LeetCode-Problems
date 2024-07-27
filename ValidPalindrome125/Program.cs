// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
string phrase = "a.";

if(IsPalindrome(phrase))
{
    Console.WriteLine($"The phrase: {phrase} \t is a palindrome.");
}

bool IsPalindrome(string s)
{
    bool isPalindrome = false;
    if (string.IsNullOrEmpty(s)) return true;
    if (s.Length == 1) return true;

    //modify the input string
    string tempString = s.ToLower().Replace(" ","");
    string testPhrase = Regex.Replace(tempString, "[^a-zA-Z0-9]", "");

    char[] arr = testPhrase.ToCharArray();
    if (arr.Length == 1 || arr.Length == 0)
        return true;
    //Case 1: length is odd
    if (arr.Length % 2 == 1)
    {
        for (int i = 0; i < arr.Length/2; i++ )
        {
            if (arr[i] != arr[arr.Length - i - 1])
                return false;
            else
                isPalindrome = true;
        }
    }

    //Case 2: length is even
    if(arr.Length % 2 == 0)
    {
        if (arr[arr.Length/2 - 1] != arr[arr.Length/2])
            return false;
        for (int i = 0; i < arr.Length/2 - 1; i++ )
        {
            if (arr[i] != arr[arr.Length - i - 1])
                return false;
        }
        isPalindrome = true;

    }
    return isPalindrome;
}
