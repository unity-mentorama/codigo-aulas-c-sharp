using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modulo15
{
	public class QueueAndStack : MonoBehaviour
	{
		private void Start()
		{
			QueueExample();
			GenericQueueExample();

			StackExample();
			GenericStackExample();
		}

		private void QueueExample()
		{
			Queue queue = new Queue();

			queue.Enqueue(42);
			queue.Enqueue('A');
			queue.Enqueue(9.75f);
			queue.Enqueue("Lex");

			Helper.UnityLogCollection(queue);

			Debug.Log($"Dequeue: {queue.Dequeue()}");
			Debug.Log($"Dequeue: {queue.Dequeue()}");
			Debug.Log($"Peek: {queue.Peek()}");

			Helper.UnityLogCollection(queue);

			Debug.Log($"O valor \"Lex\" está na queue: {queue.Contains("Lex")}");

			object[] array = queue.ToArray();

			queue.Clear();
			Helper.UnityLogCollection(queue);
		}

		private void GenericQueueExample()
		{
			Queue<int> queue = new Queue<int>();

			queue.Enqueue(42);
			queue.Enqueue('A');
			queue.Enqueue(13);
			queue.Enqueue(7);
			//queue.Enqueue(9.75f); // Tipo inválido
			//queue.Enqueue("Lex"); // Tipo inválido

			Helper.UnityLogCollection(queue);

			Debug.Log($"Dequeue: {queue.Dequeue()}");
			Debug.Log($"Dequeue: {queue.Dequeue()}");
			Debug.Log($"Peek: {queue.Peek()}");

			Helper.UnityLogCollection(queue);

			Debug.Log($"O valor 3 está na queue: {queue.Contains(3)}");

			int[] array = queue.ToArray();

			queue.Clear();
			Helper.UnityLogCollection(queue);
		}

		private void StackExample()
		{
			Stack stack = new Stack();

			stack.Push(42);
			stack.Push('A');
			stack.Push(9.75f);
			stack.Push("Lex");

			Helper.UnityLogCollection(stack);

			Debug.Log($"Pop: {stack.Pop()}");
			Debug.Log($"Pop: {stack.Pop()}");
			Debug.Log($"Peek: {stack.Peek()}");

			Helper.UnityLogCollection(stack);

			Debug.Log($"O valor \"Lex\" está na stack: {stack.Contains("Lex")}");

			object[] array = stack.ToArray();

			stack.Clear();
			Helper.UnityLogCollection(stack);
		}

		private void GenericStackExample()
		{
			Stack<int> stack = new Stack<int>();

			stack.Push(42);
			stack.Push('A');
			stack.Push(13);
			stack.Push(7);
			//stack.Push(9.75f); // Tipo inválido
			//stack.Push("Lex"); // Tipo inválido

			Helper.UnityLogCollection(stack);

			Debug.Log($"Pop: {stack.Pop()}");
			Debug.Log($"Pop: {stack.Pop()}");
			Debug.Log($"Peek: {stack.Peek()}");

			Helper.UnityLogCollection(stack);

			Debug.Log($"O valor 3 está na stack: {stack.Contains(3)}");

			int[] array = stack.ToArray();

			stack.Clear();
			Helper.UnityLogCollection(stack);
		}
	}
}
