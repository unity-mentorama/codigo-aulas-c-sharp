using UnityEngine;

namespace Modulo19
{
	[CreateAssetMenu(fileName = "New FloatVariable", menuName = "ScriptableObjects/Float Variable")]
	public class FloatVariable : ScriptableObject//, ISerializationCallbackReceiver
	{
		public float Value;

		//[NonSerialized]
		//public float Value;

		//[SerializeField]
		//private float _initialValue;

		//public void OnAfterDeserialize()
		//{
		//	Value = _initialValue;
		//}

		//public void OnBeforeSerialize() { }
	}
}
