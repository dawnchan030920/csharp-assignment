var numbers = Enumerable.Repeat(0, 100).Select(_ => Random.Shared.Next(1001));

numbers.Print();

Console.WriteLine();

var sorted = from num in numbers orderby num descending select num;

sorted.Print();

Console.WriteLine();

Console.WriteLine($"Avg is: {numbers.Average()}");

Console.WriteLine();

Console.WriteLine($"Sum is: {numbers.Sum()}");

public static class IntInumberableExtensions
{
    public static void Print(this IEnumerable<int> ints)
    {
        foreach (var num in ints)
        {
            Console.Write($"{num},");
        }
        Console.WriteLine();
    }
}
