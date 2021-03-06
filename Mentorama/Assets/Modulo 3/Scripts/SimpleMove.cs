using UnityEngine;

namespace Modulo3
{
	public class SimpleMove : MonoBehaviour
	{
		[SerializeField]
		bool shouldMoveX;

		[SerializeField]
		bool shouldMoveY;

		void Update()
		{
			if (shouldMoveX)
			{
				Translate(new Vector3(0.01f, 0, 0));
			}

			if (shouldMoveY)
			{
				Translate(new Vector3(0, 0.01f, 0));
			}

			if (Input.GetKey(KeyCode.D))
			{
				Translate(new Vector3(0.01f, 0, 0));
			}
			if (Input.GetKey(KeyCode.A))
			{
				Translate(new Vector3(-0.01f, 0, 0));
			}
			if (Input.GetKey(KeyCode.W))
			{
				Translate(new Vector3(0, 0, 0.01f));
			}
			if (Input.GetKey(KeyCode.S))
			{
				Translate(new Vector3(0, 0, -0.01f));
			}
		}

		void Translate(Vector3 movementTranslation)
		{
			transform.position = transform.position + movementTranslation;
		}
	}
}