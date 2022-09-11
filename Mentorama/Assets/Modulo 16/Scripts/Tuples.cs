using UnityEngine;

namespace Modulo16
{
	public class Tuples : MonoBehaviour
	{
		private void Start()
		{
			// Tuple type				// Typle literal
			(int min, int max) minMax = (min: 1, max: 2);
			Debug.Log($"minMax.min: {minMax.min} - minMax.max: {minMax.max}");

			minMax = (3, 4);
			Debug.Log($"minMax.min: {minMax.min} - minMax.max: {minMax.max}");

			(int, int) oi = MinMax(new int[] { 2, 1024, 3, -5, 13, 0, 42 });
			Debug.Log($"oi.item1: {oi.Item1} - oi.item2: {oi.Item2}");

#pragma warning disable CS0219, CS8123
			(int a, int b, int c, int, int) tuple =
				(a: 10, errado: 20, 30, desnecessario: 40, 50);
#pragma warning restore CS0219, CS8123
		}

		private (int min, int max) MinMax(int[] array)
		{
			var min = int.MaxValue;
			var max = int.MinValue;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] < min) min = array[i];
				if (array[i] > max) max = array[i];
			}
			return (min, max);
		}

		private (int min, int max) MinMax2(int[] array)
		{
			var result = (min: int.MaxValue, max: int.MinValue);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] < result.min) result.min = array[i];
				if (array[i] > result.max) result.max = array[i];
			}
			return result;
		}

		private (int min, int max) MinMax3(int[] array)
		{
			var result = (min: int.MaxValue, max: int.MinValue);
			for (int i = 0; i < array.Length; i++)
			{
				result = (Mathf.Min(result.min, array[i]),
					Mathf.Max(result.max, array[i]));
			}
			return result;
		}
	}
}
