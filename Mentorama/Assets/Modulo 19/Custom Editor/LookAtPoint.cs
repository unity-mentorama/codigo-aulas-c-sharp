using UnityEngine;

namespace Modulo19
{
	[ExecuteInEditMode]
	public class LookAtPoint : MonoBehaviour
	{
		public Vector3 LookPosition = Vector3.zero;

		public void Update()
		{
			transform.LookAt(LookPosition);
		}
	}
}
