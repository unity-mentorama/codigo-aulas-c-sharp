using System.Collections.Generic;
using UnityEngine;

namespace Modulo13
{
	public class InterfacesExample : MonoBehaviour
	{
		private void Start()
		{
			var circle = new Circle(5f);
			var rectangle = new Rectangle(3f, 5f);

			//IArea circleArea = new Circle(3f);

			List<IArea> areas = new List<IArea>();
			areas.Add(circle);
			areas.Add(rectangle);

			foreach (var area in areas)
			{
				area.Area();
			}

			List<IPerimeter> perimeters = new List<IPerimeter>();
			perimeters.Add(circle);
			perimeters.Add(rectangle);

			foreach (var perimeter in perimeters)
			{
				perimeter.Perimeter();
			}
		}

		public interface IArea
		{
			float Area();
		}

		public interface IPerimeter
		{
			float Perimeter();
		}

		private class Rectangle : IArea, IPerimeter
		{
			private float _base;
			private float _height;

			public Rectangle(float @base, float height)
			{
				_base = @base;
				_height = height;
			}

			public float Area()
			{
				var area = _base * _height;
				Debug.Log($"A área do retângulo base {_base} e altura {_height} é: {area}");
				return area;
			}

			public float Perimeter()
			{
				var perimeter = (_base * 2) + (_height * 2);
				Debug.Log($"O perímetro do retângulo base {_base} e altura {_height} é: {perimeter}");
				return perimeter;
			}
		}

		private class Circle : IArea, IPerimeter
		{
			private const float PI = 3.14f;

			private float _radius;

			public Circle(float radius)
			{
				_radius = radius;
			}

			public float Area()
			{
				var area = PI * _radius * _radius;
				Debug.Log($"A área do círculo raio {_radius} é: {area}");
				return area;
			}

			public float Perimeter()
			{
				var perimeter = 2 * PI * _radius;
				Debug.Log($"O perímetro do círculo raio {_radius} é: {perimeter}");
				return perimeter;
			}
		}
	}
}
