using UnityEngine;

namespace Modulo8
{
	public class Move : MonoBehaviour
	{
		public float Speed;

		public Vector3 Direction;

		private void FixedUpdate()
		{
			Translate(Direction * Speed * Time.fixedDeltaTime);
		}

		void Translate(Vector3 movementTranslation)
		{
			transform.position = transform.position + movementTranslation;
			//GetComponent<Rigidbody>().MovePosition(transform.position + movementTranslation);
		}
	}
}
