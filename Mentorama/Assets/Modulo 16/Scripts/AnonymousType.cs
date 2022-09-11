using UnityEngine;

namespace Modulo16
{
	public class AnonymousType : MonoBehaviour
	{
		private void Start()
		{
			// Read only
			var player = new
			{
				Name = "Lex",
				Score = 42
			};

			Debug.Log($"{player.Name}: {player.Score}");

			var class1 = new Class1 { A = 1, B = 2, Z = 42 };
			var class2 = new Class2 { C = 3, D = 4, Z = 13 };

			var flattened = new
			{
				class1.A,
				class1.B,
				class1.Z,
				class2.C,
				class2.D,
				Z2 = class2.Z
			};

			Debug.Log($"{flattened.A}" +
				$"{flattened.B}" +
				$"{flattened.Z}" +
				$"{flattened.C}" +
				$"{flattened.D}" +
				$"{flattened.Z2}");
		}

		private class Class1
		{
			public int A;
			public int B;
			public int Z;
		}

		private class Class2
		{
			public int C;
			public int D;
			public int Z;
		}
	}
}