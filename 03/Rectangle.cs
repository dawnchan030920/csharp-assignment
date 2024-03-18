public class Rectangle : IShape
{
	public double Height { get; set; }

	public double Width { get; set; }
	
	public double Area() => Height * Width;

	public Rectangle(double width, double height)
	{
		if (width == height) throw new ArgumentException("Height and width should be different.");
		if (width <= 0 || height <= 0) throw new ArgumentException("Width and height should be larger than 0.");

		Width = width;
		Height = height;
	}

	public override string ToString() => $"Rect with width of {Width} and height of {Height}. Area: {Area()}.";
}
