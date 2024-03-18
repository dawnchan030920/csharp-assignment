var shapes = GetRandomShapes(10);
var area = shapes.Sum(shape => shape.Area());

foreach (var shape in shapes)
{
	Console.WriteLine(shape);
}

Console.WriteLine($"\nTotal area is {area}.");

// INFO For demo usage, the max value is hard caded as 100.
List<IShape> GetRandomShapes(int count)
{
	var result = new List<IShape>();
	int max = 100;
	foreach (var i in Enumerable.Range(0, count))
	{
		var random = new Random();
		int choice = random.Next(3);
		IShape shape = choice switch
		{
			0 => GetRandomRect(max),
			1 => GetRandomCircle(max),
			2  => GetRandomSquare(max),
			_ => throw new Exception()
		};

		result.Add(shape);
	}
	return result;
}

Rectangle GetRandomRect(int max)
{
	if (max <= 0) throw new ArgumentException("Max should be larger than 0.");
	
  	// WARNING May lead to long loop and cause relevant performance issues. Only for assignment!
	Random random = new Random();
	double first;
	do
	{
		first = random.NextDouble();
	} while (first == 0);
	
	double second;
	do
	{
  		second = random.NextDouble();
	} while (second == first || second == 0);
	
	return new Rectangle(first * max, second * max);
}

Square GetRandomSquare(int max)
{
	if (max <= 0) throw new ArgumentException("Max should be larger than 0.");
	
	Random random = new Random();

	double l;
	do
	{
		l = random.NextDouble();
	} while (l == 0);

	return new Square(l * max);
}

Circle GetRandomCircle(int max)
{
	if (max <= 0) throw new ArgumentException("Max should be larger than 0.");
	
	Random random = new Random();

	double r;
	do
	{
		r = random.NextDouble();
	} while (r == 0);

	return new Circle(r * max);
}
