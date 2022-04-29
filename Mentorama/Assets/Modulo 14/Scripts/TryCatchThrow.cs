using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace Modulo14
{
	public class TryCatchThrow : MonoBehaviour
	{
		private void Start()
		{
			try
			{
				MethodWithError();
			}
			catch (InvalidItemException e)
			{
				Debug.LogError(e.Message);
			}
			catch (Exception e)
			{
				Debug.LogError(e.Message);
			}
			finally
			{
				Debug.Log("Sempre executa");
			}

			Debug.Log("Código após erro.");
		}

		private void MethodWithError()
		{
			//System.NullReferenceException
			//System.IndexOutOfRangeException
			//System.ArgumentOutOfRangeException
			//System.ArgumentNullException
			//System.IO.IOException
			//System.StackOverflowException
			//System.OutOfMemoryException
			//System.InvalidCastException
			//System.InvalidOperationException
			//System.ObjectDisposedException
			//System.DivideByZeroException
			//System.NotImplementedException

			throw new Exception("Algo deu errado");
		}
	}

	[Serializable]
	public class InvalidItemException : Exception
	{
		public InvalidItemException() : base() { }
		public InvalidItemException(string message) : base(message) { }
		public InvalidItemException(string message, Exception inner) : base(message, inner) { }

		// Necessário para serialização da exception em contextos remotos
		protected InvalidItemException(SerializationInfo info,
			StreamingContext context) : base(info, context) { }
	}
}