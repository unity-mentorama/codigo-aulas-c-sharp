using UnityEngine;

namespace Modulo19
{
	public class PropertyAttributeExample : MonoBehaviour
	{
		//[MyRange(0f, 1f)]
		public float FloatValue;

		public int IntValue;

		public string StringValue;

		//[RequiredField]
		//public GameObject ShouldBeAssigned;

		//[RequiredField(FieldColor.Yellow)]
		//public Transform YellowField;

		//[SerializeField, RequiredField(FieldColor.Blue)]
		//private GameObject[] SerializedHighlight;

		//[RequiredField]
		//public Ingredient IngredientValue;
	}
}
