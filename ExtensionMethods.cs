using System;
using System.Linq;

namespace ExtensionMethods;

public class Program
{
    public static void Main()
    {
        string str = "very very long text blah blah blah blah blah blah blah blah blah blah";
        string shortenStr = str.Shorten(5);
     }
}

public static class StringExtensions
{
    public static string Shorten(this String str, int numberOfWords)
    {
        if(numberOfWords <= 0)
            throw new ArgumentOutOfRangeException("numberOfWords need to be greater than 0");

        string[] words = str.Split(" ");

        return string.Join(" ", words.Take(5)) + "...";
    }
}
