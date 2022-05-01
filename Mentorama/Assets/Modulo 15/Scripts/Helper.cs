using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Helper
{
	public static void UnityLogCollection(ICollection collection)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int count = 0;

		foreach (object obj in collection)
		{
			stringBuilder.AppendLine($"{count}:\t{obj}");
			count++;
		}

		stringBuilder.AppendLine("================");
		stringBuilder.AppendLine($"Count: {collection.Count}");

		Debug.Log(stringBuilder.ToString());
	}

	public static void UnityLogGenericCollection<T>(ICollection<T> collection)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int count = 0;

		foreach (T item in collection)
		{
			stringBuilder.AppendLine($"{count}:\t{item}");
			count++;
		}

		stringBuilder.AppendLine("================");
		stringBuilder.AppendLine($"Count: {collection.Count}");

		Debug.Log(stringBuilder.ToString());
	}

	public static void UnityLogDictionary(IDictionary collection)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int count = 0;

		foreach (var key in collection.Keys)
		{
			stringBuilder.AppendLine($"{count}:\t [{key}, {collection[key]}]");
			count++;
		}

		stringBuilder.AppendLine("================");
		stringBuilder.AppendLine($"Count: {collection.Count}");

		Debug.Log(stringBuilder.ToString());
	}
}
