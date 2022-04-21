using UnityEngine;

public class ExampleIfElse : MonoBehaviour
{
	[SerializeField]
	float n1;

	[SerializeField]
	float n2;

	void Start()
	{
		float m = (n1 + n2) / 2f;

		if (m > 5)
		{
			Debug.Log("Aprovado");
		}
		else
		{
			Debug.Log("Reprovado");
		}
	}
}
