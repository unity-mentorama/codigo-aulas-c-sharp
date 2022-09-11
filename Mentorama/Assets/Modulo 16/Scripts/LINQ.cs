using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modulo16
{
	public class LINQ : MonoBehaviour
	{
		private void Start()
		{
			string[] words = { "velha", "mosca", "rato", "gato", "cachorro", "pau", "fogo", "agua", "boi", "homem" };
			int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			#region Projection
			// Especificar o formato dos dados de retorno de cada elemento.

			words.Select(word => new
			{
				firstLetter = word[0],
				lastLetter = word[word.Length - 1]
			});

			IEnumerable<char> selectManyQuery = words.SelectMany(word => word);
			selectManyQuery = from word in words
							  from @char in word
							  select @char;
			#endregion

			#region Ordering
			//Ordenar os elementos em uma sequência.

			words.OrderBy(word => word);
			words.OrderByDescending(word => word);
			words.OrderBy(word => word).ThenBy(word => word);
			words.OrderBy(word => word).ThenByDescending(word => word);
			words.Reverse();
			#endregion

			#region Filtering
			// Filtrar determinados elementos de uma collection.


			words.Where(word => word.Length > 4);
			words.OfType<char>();
			#endregion

			#region Set
			// Operações de conjunto.

			var grupo = new string[] { "rato", "gato" };
			words.Distinct();
			words.Except(grupo);
			words.Intersect(grupo);
			words.Union(grupo);
			words.Concat(grupo);
			#endregion

			#region Quantifier
			// Verificações com base na quantidade de elementos.

			words.All(word => word.Length > 4);
			words.Any(word => word.Length > 4);
			words.Contains("ra");
			#endregion

			#region Grouping
			// Agrupar elementos com base em critérios.

			words.GroupBy(word => word.Length); // Deferred - Lazy
			words.ToLookup(word => word.Length); // Immediate - Greedy

			// 3 -> pau, boi
			// 4 -> rato, gato, fogo, agua
			// 5 -> velha, mosca, homem
			// 8 -> cachorro
			#endregion

			#region Partitioning
			// Particionar ou dividir elementos.

			words.Take(4); // 4 primeiro elementos
			words.TakeWhile(word => word.Length < 8); // Todos os elementos até "gato" (para no cachorro)

			words.Skip(4); // A partir do 5o. elemento
			words.SkipWhile(word => word.Length < 8); // Todos os elementos de "cachorro" em diante
			#endregion

			#region Element
			// Buscar elementos específicos.

			words.ElementAt(0);
			words.ElementAtOrDefault(0);

			words.First();
			words.FirstOrDefault();

			words.Last();
			words.LastOrDefault();

			words.Single(word => word.Length > 7);
			words.SingleOrDefault(word => word.Length < 3); // Ainda pode dar exception se existir mais de 1

			words.DefaultIfEmpty();
			words.DefaultIfEmpty("hello"); // Se words fosse empty, iria retornar { "hello" }
			#endregion

			#region Equality
			// Comparar collections de elementos.

			words.SequenceEqual(words);
			words.SequenceEqual(words, StringComparer.OrdinalIgnoreCase);
			#endregion

			#region Conversion
			// Converter o tipo da collection.

			words.ToList();
			words.ToArray();
			//words.ToDictionary(word => word.Length); // vai dar erro
			words.Select((word, index) => new { ID = index, word = word }).ToDictionary(obj => obj.ID);
			#endregion

			#region Concatenation
			// Adicionar elementos ao início ou fim.

			words.Append("morte");
			words.Prepend("fiar");

			// NOTA: Você não está modificando words
			#endregion

			#region Aggregation
			// Realizar operações considerando todos os elementos.

			numbers.Sum();
			numbers.Max();
			numbers.Min();
			numbers.Average();
			numbers.Count();
			numbers.Aggregate((s1, s2) => s1 + s2); // Sum
			words.Aggregate((s1, s2) => $"{s1}, {s2}"); // Append
			#endregion

			#region Generation
			// Gerar novos elementos.

			IEnumerable<int> numberSequence = Enumerable.Range(1, 10).Where(n => n % 2 == 0);

			IEnumerable<string> repeatStrings = Enumerable.Repeat("Hello world", 10);
			var repeatForwardVectors = Enumerable.Repeat(Vector3.forward, 10).ToList();

			var emptyCollection1 = Enumerable.Empty<string>();
			var emptyCollection2 = Enumerable.Empty<Transform>();
			#endregion

			#region Join
			// Fazer associações entre dados de collections diferentes.

			var nato = new string[] { "alpha", "bravo", "charlie" };

			// Method syntax
			var joins = words.Join(nato,
				word => word[0],
				code => code[0],
				(word, code) => new
				{
					Word = word,
					Nato = code
				}).ToList();

			// Query syntax
			joins = (from word in words
					 join code in nato
					 on word[0] equals code[0]
					 select new
					 {
						 Word = word,
						 Nato = code
					 }).ToList();

			var groupJoins = nato.GroupJoin(words,
				code => code[0],
				word => word[0],
				(code, words) => new
				{
					code,
					words
				});

			foreach (var item in groupJoins)
			{
				Debug.Log("Nato: " + item.code);
				foreach (var word in item.words)
				{
					Debug.Log($"  Word: {word}");
				}
			}

			var groupJoins2 = numbers.GroupJoin(words,
				number => number,
				word => word.Length,
				(number, words) => new
				{
					number,
					words
				});

			foreach (var item in groupJoins2)
			{
				Debug.Log("Number: " + item.number);
				foreach (var word in item.words)
				{
					Debug.Log($"  Word: {word}");
				}
			}

			// Inner Join
			// Left Join
			// Right Join
			// Full Join
			#endregion

			#region Miscellaneous
			// Zip.

			var resultSequence = numbers.Zip(words, (number, word) => number + " - " + word);

			// 1 - velha
			// 2 - mosca
			// 3 - rato
			// ...
			#endregion

			#region Custom
			// Suas próprias implementações.

			// Custom Sequence
			numbers.CountNegativeNumbers();

			float[] floatNumbers = { 1.1f, 2.2f, 3.3f };
			floatNumbers.CountNegativeNumbers();

			words.CountWithCondition(word => word.Length > 3);

			words.AlternateElements().OrderBy(word => word).ToList();
			#endregion
		}
	}

	public static class CustomLINQ
	{
		public static int CountNegativeNumbers(this IEnumerable<int> source)
		{
			int count = 0;
			foreach (var number in source)
			{
				if (number < 0) count++;
			}

			return count;
		}

		public static int CountNegativeNumbers(this IEnumerable<float> source)
			=> (from num in source select (int)num).CountNegativeNumbers();

		public static int CountWithCondition<T>(this IEnumerable<T> source, Predicate<T> selector)
		{
			int count = 0;
			foreach (var element in source)
			{
				if (selector.Invoke(element)) count++;
			}

			return count;
		}

		public static IEnumerable<T> AlternateElements<T>(this IEnumerable<T> source)
		{
			int index = 0;

			foreach (T element in source)
			{
				if (index % 2 == 0)
				{
					yield return element;
				}

				index++;
			}
		}
	}
}