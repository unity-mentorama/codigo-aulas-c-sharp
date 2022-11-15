using System.Collections;
using UnityEngine;

namespace Modulo18
{
	public class AttackAnimator : MonoBehaviour
	{
		public MeshRenderer MeshRenderer;

		public void PlayAttackAnim()
		{
			StartCoroutine(AttackAnimCoroutine());
		}

		private IEnumerator AttackAnimCoroutine()
		{
			MeshRenderer.material.color = Color.red;
			yield return new WaitForSeconds(0.5f);
			MeshRenderer.material.color = Color.white;
		}
	}
}
