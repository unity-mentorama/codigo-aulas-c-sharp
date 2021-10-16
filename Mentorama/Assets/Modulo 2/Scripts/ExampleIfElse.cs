using UnityEngine;

public class ExampleIfElse : MonoBehaviour
{
	[SerializeField]
	float n1;

	[SerializeField]
	float n2;

	// Start is called before the first frame update
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
