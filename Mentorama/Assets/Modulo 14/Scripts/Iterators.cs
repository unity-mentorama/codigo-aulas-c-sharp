using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modulo14
{
	public class Iterators : MonoBehaviour
	{
		private void Start()
		{
			var bag = new Bag<int>(10);

			bag[5] = 42;

			foreach (var item in bag)
			{
				Debug.Log(item);
			}

			foreach (var number in Iterator())
			{
				Debug.Log(number);
			}

			foreach (var number in Iterator2())
			{
				Debug.Log(number);
			}

			var foreachClass = new ForeachableClass();
			foreach (var number in foreachClass)
			{
				Debug.Log(number.ToString());
			}
		}

		private IEnumerable<int> Iterator()
		{
			yield return 0;

			for (int i = 0; i < 10; i++)
			{
				//if (i == 5) yield break;
				yield return 15 - i;
			}

			yield return -1;
		}

		private IEnumerable<int> Iterator2()
		{
			try
			{
				yield return 0;

				int i = 0;
				while (true)
				{
					yield return 15 - i;
					i++;
					if (i >= 10) yield break;
				}
			}
			finally
			{
				Debug.Log("Finally!");
			}
		}

		private class ForeachableClass : IEnumerable
		{
			public IEnumerator GetEnumerator() // Duck Typing
			{
				yield return 1;
				yield return 2;
			}
		}
	}
}
