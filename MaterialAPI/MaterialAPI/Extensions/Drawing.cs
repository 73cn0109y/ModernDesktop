using System;

namespace MaterialAPI.Extensions.Drawing
{
	public static class Extensions
	{
		#region Enum
		public enum GraphicsType : int
		{
			Triangle = 0,
			Square = 1
		}

		public enum Direction : int
		{
			NULL,
			North,
			NorthEast,
			East,
			SouthEast,
			South,
			SouthWest,
			West,
			NorthWest
		}
		#endregion

		public static System.Drawing.Drawing2D.GraphicsPath GenerateGraphicsPath(GraphicsType type, System.Drawing.Rectangle rectangle, Direction direction = Direction.NULL)
		{
			if (type == GraphicsType.Triangle && direction != Direction.NULL)
				return GenerateTrianglePath(rectangle, direction);
			else if (type == GraphicsType.Square)
				return GenerateSquarePath(rectangle);

			return null;
		}

		public static System.Drawing.Drawing2D.GraphicsPath GenerateTrianglePath(System.Drawing.Rectangle rect, Direction direction)
		{
			System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

			switch (direction)
			{
				case Direction.North:
					gp.AddLine(new System.Drawing.Point(rect.Width / 2, rect.Top), new System.Drawing.Point(rect.Width, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Width, rect.Bottom), new System.Drawing.Point(rect.Left, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Bottom), new System.Drawing.Point(rect.Width / 2, rect.Top));
					break;
				case Direction.NorthEast:
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Top), new System.Drawing.Point(rect.Right, rect.Top));
					gp.AddLine(new System.Drawing.Point(rect.Right, rect.Top), new System.Drawing.Point(rect.Right, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Right, rect.Bottom), new System.Drawing.Point(rect.Left, rect.Top));
					break;
				case Direction.East:
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Top), new System.Drawing.Point(rect.Right, rect.Height / 2));
					gp.AddLine(new System.Drawing.Point(rect.Right, rect.Height / 2), new System.Drawing.Point(rect.Left, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Bottom), new System.Drawing.Point(rect.Left, rect.Top));
					break;
				case Direction.SouthEast:
					gp.AddLine(new System.Drawing.Point(rect.Right, rect.Top), new System.Drawing.Point(rect.Right, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Right, rect.Bottom), new System.Drawing.Point(rect.Left, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Bottom), new System.Drawing.Point(rect.Right, rect.Top));
					break;
				case Direction.South:
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Top), new System.Drawing.Point(rect.Right, rect.Top));
					gp.AddLine(new System.Drawing.Point(rect.Right, rect.Top), new System.Drawing.Point(rect.Width / 2, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Width / 2, rect.Bottom), new System.Drawing.Point(rect.Left, rect.Top));
					break;
				case Direction.SouthWest:
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Top), new System.Drawing.Point(rect.Right, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Right, rect.Bottom), new System.Drawing.Point(rect.Left, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Bottom), new System.Drawing.Point(rect.Left, rect.Top));
					break;
				case Direction.West:
					gp.AddLine(new System.Drawing.Point(rect.Right, rect.Top), new System.Drawing.Point(rect.Right, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Right, rect.Bottom), new System.Drawing.Point(rect.Left, rect.Height / 2));
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Height / 2), new System.Drawing.Point(rect.Right, rect.Top));
					break;
				case Direction.NorthWest:
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Top), new System.Drawing.Point(rect.Right, rect.Top));
					gp.AddLine(new System.Drawing.Point(rect.Right, rect.Top), new System.Drawing.Point(rect.Left, rect.Bottom));
					gp.AddLine(new System.Drawing.Point(rect.Left, rect.Bottom), new System.Drawing.Point(rect.Left, rect.Top));
					break;
			}

			return gp;
		}

		public static System.Drawing.Drawing2D.GraphicsPath GenerateSquarePath(System.Drawing.Rectangle rectangle)
		{
			System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

			gp.AddRectangle(rectangle);

			return gp;
		}
	}
}
