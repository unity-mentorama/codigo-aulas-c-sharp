using UnityEngine;

namespace Modulo10
{
	[SelectionBase]
	[HelpURL("https://mentorama.com.br/")]
	[AddComponentMenu("Your New Menu/Script with Attributes")]
	//[ExecuteInEditMode]
	public class Attributes : MonoBehaviour
	{
		// Não funciona com properties, somente fields.
		[SerializeField]
		private int DontWork { get; set; }

		[SerializeField]
		public int SerializedField;

		[Space]
		[SerializeField]
		private int _serializedField;

		[Space(20)]
		[SerializeField]
		private int m_SerializedField;

		[Header("Won't remove k_")]
		[SerializeField]
		private int k_SerializedField;

		[Header("Hidden")]
		[HideInInspector]
		public int HiddenPublicField;

		[Header("Control Attributes")]
		[Range(1f, 2.4f), SerializeField]
		private float RangeValue;

		[Min(10), SerializeField]
		public int MinValue;

		[NonReorderable]
		public int[] Numbers = new int[] { 1, 2, 3, 4, 5 };

		[Header("Text Attributes")]
		[Multiline(5)]
		public string MultiLineText;

		[TextArea]
		[Tooltip("This explains the variable.")]
		public string TextArea;

		[Delayed]
		public int SetValueDelayed;

		public enum MyEnum
		{
			[InspectorName("Primeiro")] First = 0,
			[InspectorName("Segundo")] Second = 1
		}

		public MyEnum myEnum;

		[ContextMenuItem("Get a random number", "GetRandomNumber")]
		public int RandomNumber;

		private void Update()
		{
			Debug.Log($"NonDelayed: {MinValue} - Delayed: {SetValueDelayed}");
		}

		private void GetRandomNumber()
		{
			RandomNumber = Random.Range(0, 42);
		}

		[ContextMenu("Do your thing.")]
		void NewThing()
		{
			Debug.Log("I did the thing!");
		}
	}
}