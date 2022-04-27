using UnityEngine;

namespace Modulo10
{
	public class PlayerLoop : MonoBehaviour
	{
		private void Awake()
		{
			Debug.Log("Awake");
		}

		private void OnEnable()
		{
			Debug.Log("OnEnable");
		}

		private void Reset()
		{
			Debug.Log("Reset");
		}

		private void Start()
		{
			Debug.Log("Start");
		}

		private void FixedUpdate()
		{
			//Debug.Log("FixedUpdate");
		}

		private void Update()
		{
			//Debug.Log("Update");
		}

		private void LateUpdate()
		{
			//Debug.Log("LateUpdate");
		}

		private void OnDrawGizmos()
		{
			//Debug.Log("OnDrawGizmos");
		}

		private void OnApplicationPause(bool paused)
		{
			Debug.Log($"paused: {paused}");
			Debug.Log("OnApplicationPause");
		}

		private void OnApplicationQuit()
		{
			Debug.Log("OnApplicationQuit");
		}

		private void OnDisable()
		{
			Debug.Log("OnDisable");
		}

		private void OnDestroy()
		{
			Debug.Log("OnDestroy");
		}
	}
}