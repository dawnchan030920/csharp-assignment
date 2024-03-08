namespace Core;

public class ArrayStatistic
{
    public ArrayStatistic(List<int> numbers)
    {
        Numbers = numbers;
    }

    public List<int> Numbers
	{
		get;
		set;
	}

	public int Max
	{
		get => Numbers.Max();
	}

	public int Min
	{
		get => Numbers.Min();
	}

	public double Average
	{
		get => Numbers.Average();
	}

	public int Sum
	{
		get => Numbers.Sum();
	}
}
