using System;
using System.Collections;
using UnityEngine;

namespace Modulo14
{
	public class Coroutines : MonoBehaviour
	{
		private void Start()
		{
			// Start
			StartCoroutine("UnityCoroutine");
			StartCoroutine(UnityCoroutine());

			StartCoroutine(UnityCoroutineWithParameter(3f));
			StartCoroutine("UnityCoroutineWithParameter", 3f);

			// Stop
			StopCoroutine("UnityCoroutine");

			var enumerator = UnityCoroutine();
			var coroutine = StartCoroutine(enumerator);

			StopCoroutine(enumerator);
			StopCoroutine(coroutine);

			// Stop all
			StopAllCoroutines();
		}

		private IEnumerator UnityCoroutine()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForFixedUpdate();
			yield return new WaitForSeconds(3f);
			yield return new WaitForSecondsRealtime(3f);
			yield return new WaitUntil(TestUntil);
			yield return new WaitWhile(TestWhile);

			Debug.Log("Waiting key down");
			yield return new WaitForKeyDown(KeyCode.A);
			Debug.Log("Key pressed");
			yield return new WaitWhile1(TestWhile);
			yield return new WaitWhile2(TestWhile);

			yield return null;
		}

		private IEnumerator UnityCoroutineWithParameter(float value)
		{
			Debug.Log($"Waiting for {value} seconds.");
			yield return new WaitForSeconds(value);
			Debug.Log($"Done waiting.");
		}

		private bool TestUntil()
		{
			return true;
		}

		private bool TestWhile()
		{
			return false;
		}

		private class WaitForKeyDown : CustomYieldInstruction
		{
			private KeyCode _keyCode;

			public override bool keepWaiting
			{
				get
				{
					return !Input.GetKeyDown(_keyCode);
				}
			}

			public WaitForKeyDown(KeyCode keyCode)
			{
				_keyCode = keyCode;
			}
		}

		class WaitWhile1 : CustomYieldInstruction
		{
			private Func<bool> _predicate;

			public override bool keepWaiting
			{
				get
				{
					return _predicate();
				}
			}

			public WaitWhile1(Func<bool> predicate)
			{
				_predicate = predicate;
			}
		}

		class WaitWhile2 : IEnumerator
		{
			private Func<bool> _predicate;

			object IEnumerator.Current { get { return null; } }

			bool IEnumerator.MoveNext() { return _predicate(); }

			void IEnumerator.Reset() { }

			public WaitWhile2(Func<bool> predicate) { _predicate = predicate; }
		}
	}
}