using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modulo16
{
	public class QueryExpressions : MonoBehaviour
	{
		private void Start()
		{
			#region Data Source
			List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			#endregion

			#region Consulta
			// 1. Inicialização (para trabalhar com uma fonte de dados)
			// 2. Condição (onde, filtro, condição de ordenação)
			// 3. Seleção (seleção singular, seleção em grupos ou "joining")

			// Consulta LINQ usando Query Syntax
			var QuerySyntax = from obj in numbers   // Inicialização
							  where obj > 5         // Condição
							  select obj;           // Seleção

			// Consulta LINQ usando Method Syntax
			var MethodSyntax = numbers.Where(obj => obj > 5).ToList();

			// Consulta LINQ usando Mixed Syntax
			var MixedSyntax = (from obj in numbers
							   where obj > 5
							   select obj).Sum();
			#endregion

			#region Execução
			foreach (var item in QuerySyntax)
			{
				Debug.Log(item);
			}
			#endregion

			string[] words = { "velha", "mosca", "rato", "gato", "cachorro", "pau", "fogo", "agua", "boi", "homem" };

			// Method syntax
			IEnumerable<string> query = words       // Inicialização
				.Where(word => word.Length >= 4)    // Condição
				.OrderBy(word => word)              // Condição
				.Select(word => word.ToUpper());    // Seleção

			foreach (string word in query)
			{
				Debug.Log($"Word {word}");
			}

			IEnumerable<string> query2 =
				Enumerable.Select(
					Enumerable.OrderBy(
						Enumerable.Where(words, words => words.Length >= 4),
						word => word),
					word => word.ToUpper());

			var tmp1 = Enumerable.Where(words, word => word.Length > 4);
			var tmp2 = Enumerable.OrderBy(tmp1, word => word);
			var query3 = Enumerable.Select(tmp2, word => word.ToUpper());

			// Query syntax
			IEnumerable<string> query4 = from word in words // Range variable
										 where word.Length >= 4
										 orderby word
										 select word.ToUpper();

			IEnumerable<string> query5 = from word in words
										 let lengh = word.Length // Outra range variable
										 where lengh >= 4
										 orderby lengh
										 select $"{lengh}: {word.ToUpper()}";

			// Method syntax
			IEnumerable<string> query6 =
					words.Select(word => new { word, lengh = word.Length })
						.Where(tmp => tmp.lengh >= 4)
						.OrderBy(tmp => tmp.lengh)
						.Select(tmp => $"{tmp.lengh}: {tmp.word.ToUpper()}");

			// Qual você acha mais legível?
			var q1 = from word in words
					 where word.Length >= 4
					 select word;

			var q2 = words.Where(word => word.Length >= 4);
		}
	}
}