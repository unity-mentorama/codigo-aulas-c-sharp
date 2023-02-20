using UnityEngine;

namespace Modulo19
{
	public class ExampleMonoBehaviour : MonoBehaviour
	{
		public ExampleScriptableObject ExampleScriptableObject;

		private void Update()
		{
			Debug.Log("Int: " + ExampleScriptableObject.IntVariable);
			Debug.Log("String: " + ExampleScriptableObject.StringVariable);
			Debug.Log("Float: " + ExampleScriptableObject.FloatVariable);
		}
	}
}
