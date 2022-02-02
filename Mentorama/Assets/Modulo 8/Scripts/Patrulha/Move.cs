using UnityEngine;

public class Move : MonoBehaviour
{
	public float Speed;

	public Vector3 Direction;

	private void Update()
	{
		Translate(Direction * Speed * Time.deltaTime);
	}

	void Translate(Vector3 movementTranslation)
	{
		transform.position = transform.position + movementTranslation;
	}
}
