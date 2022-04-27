using UnityEngine;

namespace Modulo10
{
	public class SpherePhisics : MonoBehaviour
	{
		private void OnCollisionEnter(Collision collision)
		{
			Debug.Log($"OnCollisionEnter: {collision.transform.name}");
		}

		private void OnCollisionStay(Collision collision)
		{
			Debug.Log($"OnCollisionStay: {collision.transform.name}");
		}

		private void OnCollisionExit(Collision collision)
		{
			Debug.Log($"OnCollisionExit: {collision.transform.name}");
		}

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log($"OnTriggerEnter: {other.transform.name}");
		}

		private void OnTriggerStay(Collider other)
		{
			Debug.Log($"OnTriggerStay: {other.transform.name}");
		}

		private void OnTriggerExit(Collider other)
		{
			Debug.Log($"OnTriggerExit: {other.transform.name}");
		}
	}
}