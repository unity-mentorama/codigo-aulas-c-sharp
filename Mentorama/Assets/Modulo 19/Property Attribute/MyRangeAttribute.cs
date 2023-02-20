using UnityEngine;

namespace Modulo19
{
	public class MyRangeAttribute : PropertyAttribute
	{
		public readonly float Min;
		public readonly float Max;

		public MyRangeAttribute(float min, float max)
		{
			this.Min = min;
			this.Max = max;
		}
	}
}
