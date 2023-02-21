using System;
using UnityEngine;

namespace Modulo19
{
	[CreateAssetMenu(fileName = "New FloatVariable", menuName = "ScriptableObjects/Float Variable")]
	public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
	{
		[NonSerialized]
		public float Value;

		[SerializeField]
		private float _initialValue;

		public void OnAfterDeserialize()
		{
			Value = _initialValue;
		}

		public void OnBeforeSerialize() { }
	}
}
