using UnityEngine;

namespace Modulo19
{
	public class PropertyAttributeExample : MonoBehaviour
	{
		[MyRangeAttribute(0f, 1.5f)]
		public float FloatValue;

		[MyRange(1f, 3f)]
		public int IntValue;

		[MyRange(1f, 3f)]
		public string StringValue;

		[RequiredField]
		public GameObject ShouldBeAssigned;

		[RequiredField(FieldColor.Yellow)]
		public Transform YellowField;

		[SerializeField, RequiredField(FieldColor.Blue)]
		private GameObject[] _serializedHighlight;

		[RequiredField]
		public Ingredient IngredientValue;
	}
}
