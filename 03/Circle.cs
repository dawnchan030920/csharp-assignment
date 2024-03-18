public class Circle : IShape
{
	public double Radius { get; set; }

	public double Area() => Math.PI * Radius * Radius;

	public Circle(double radius)
	{
		if (radius <= 0) throw new ArgumentException("Radius should be larger than 0.");

		Radius = radius;
	}

	public override string ToString() => $"Circle with radius of {Radius}. Area: {Area()}.";
}
