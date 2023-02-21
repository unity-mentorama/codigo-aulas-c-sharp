using ClassLibrary;
using UnityEngine;

namespace Modulo19
{
	public class MyScript : MonoBehaviour
	{
		void Start()
		{
			var classObject = new ClassLibrary.Class1
			{
				StringVariable = "Hello World"
			};

			var staticIntVariable = Class1.IntVariable;
		}
	}
}
