using UnityEngine;

namespace Modulo18
{
	public class AICharacterMotor : MonoBehaviour
	{
		public float MoveSpeed;

		public Vector3 TargetPosition;

		private void FixedUpdate()
		{
			var translation = TargetPosition - transform.position;

			if (translation.magnitude > (MoveSpeed * Time.fixedDeltaTime))
			{
				translation = translation.normalized * (MoveSpeed * Time.fixedDeltaTime);
			}

			transform.Translate(translation, Space.World);

			transform.LookAt(transform.position + translation.normalized);
		}
	}
}
