var primes = GetPrimes(100);

for (int i = 6; i <= 100; i += 2)
{
    var found = false;
    foreach (var prime in primes)
    {
        var otherPrime = i - prime;
        if (primes.Contains(otherPrime))
        {
            Console.WriteLine($"{i} = {prime} + {otherPrime}");
            found = true;
            break;
        }
    }

    if (!found)
    {
        Console.WriteLine($"{i} doesn't obey to Goldbach conjecture.");
    }
}


IEnumerable<int> GetPrimes(int max)
{
    var sieve = new bool[max + 1];
    for (int i = 2; i <= max; i++)
    {
        if (!sieve[i])
        {
            yield return i;
            for (int j = i * i; j <= max; j += i)
            {
                sieve[j] = true;
            }
        }
    }
}
