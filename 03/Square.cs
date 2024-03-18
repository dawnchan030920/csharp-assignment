public class Square : IShape
{
	public double Length { get; set; }

	public double Area() => Length * Length;

	public Square(double length)
	{
		if (length <= 0) throw new ArgumentException("Length should be larger than 0.");

		Length = length;
	}

    public override string ToString() => $"Square with length of {Length}. Area: {Area()}.";
}
