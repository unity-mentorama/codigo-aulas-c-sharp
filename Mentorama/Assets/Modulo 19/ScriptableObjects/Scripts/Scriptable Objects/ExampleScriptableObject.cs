using UnityEngine;

namespace Modulo19
{
	[CreateAssetMenu(fileName = "New ScriptableObject", menuName = "ScriptableObjects/Example")]
	public class ExampleScriptableObject : ScriptableObject, ISerializationCallbackReceiver
	{
		public int IntVariable;
		public string StringVariable;
		public float FloatVariable;

		private void OnEnable()
		{
			//Debug.Log("OnEnable");
		}

		private void OnDisable()
		{
			//Debug.Log("OnDisable");
		}

		private void OnDestroy()
		{
			//Debug.Log("OnDestroy");
		}

		public void OnBeforeSerialize()
		{
			// Cuidado, é chamado frequentemente.
			//Debug.Log("OnBeforeSerialize");
		}

		public void OnAfterDeserialize()
		{
			// Chamado logo antes do scriptable começar a ser utilizado.
			// Ideal para inicializar valores, por exemplo.
			Debug.Log("OnAfterDeserialize");
		}
	}
}
