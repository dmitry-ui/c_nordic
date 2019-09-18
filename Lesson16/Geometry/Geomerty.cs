using System;

namespace Geometry
{
	public class Rectangle
	{
		private double _length;

		private double _width;

		public Rectangle(double length, double width)
		{
			_length = length;
			_width = width;
		}

		public double Calculate(Func<double, double, double> operation)
		{
			return operation(_length, _width);
		}

	}

	public sealed class Circle
	{
		private double _radius;
		public Circle(double radius)
		{
			_radius = radius;
		}
		public double Calculate(Func<double, double> operation)
		{
			return operation(_radius);
		}
	}
}
