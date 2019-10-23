using System;

delegate bool GreaterThan(int v);

static class Functions
{
    public static int MyCount(this int[] ints)
    {
        return ints.Length;
    }

    public static int MyCount(this int[] ints, GreaterThan func)
    {
        int count = 0;
        foreach (int value in ints)
        { if (func(value)) { count++; } }

        return count;
    }
}

class Program
{

    static void Main(string[] args)
    {
        int[] a = { 3, 3, 5, 8, 9, 1 };
        int result = a.MyCount(e => e % 2 == 0);
        Console.WriteLine("Res={0}", result);
        Console.ReadLine();
    }
}
