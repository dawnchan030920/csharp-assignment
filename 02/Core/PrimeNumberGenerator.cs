namespace Core;

public static class PrimeNumberGenerator
{
	public static List<int> GeneratePrimeNumbers(int min, int max)
	{
		return Enumerable.Range(min, max - min + 1).Where(new Func<int, bool>(IsPrime)).ToList();
	}

	private static bool IsPrime(int num)
	{
		if (num <= 1) return false;

		for (int i = 2; i < num; i++)
		{
			if (num % i == 0) return false;
		}

		return true;
	}
}
