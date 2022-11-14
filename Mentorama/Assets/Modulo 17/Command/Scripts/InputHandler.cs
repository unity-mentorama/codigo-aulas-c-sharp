using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Modulo17.Command
{
	// Client + Invoker
	public class InputHandler : MonoBehaviour
	{
		public float MoveDistance = 50f;
		public GameObject ObjectToMove;
		public TextMeshProUGUI Text;

		private MoveCommandReceiver _moveCommandReciever;
		private readonly List<MoveCommand> _commands = new List<MoveCommand>();
		private int _currentCommandIndex = 0;

		void Start()
		{
			_moveCommandReciever = new MoveCommandReceiver();
		}

		public void Undo()
		{
			if (_currentCommandIndex > 0)
			{
				_currentCommandIndex--;
				MoveCommand moveCommand = _commands[_currentCommandIndex];
				moveCommand.UnExecute();
			}
		}

		public void Redo()
		{
			if (_currentCommandIndex < _commands.Count)
			{
				MoveCommand moveCommand = _commands[_currentCommandIndex];
				_currentCommandIndex++;
				moveCommand.Execute();
			}
		}

		private void Move(MoveDirection direction)
		{
			// Client
			var moveCommand = new MoveCommand(
				_moveCommandReciever,
				new MoveCommandState
				{
					Direction = direction,
					Distance = MoveDistance,
					GameObject = ObjectToMove
				});

			// Invoker
			moveCommand.Execute();

			// Limpa os comandos que estavam na lista depois desse
			if (_currentCommandIndex < _commands.Count)
			{
				_commands.RemoveRange(_currentCommandIndex, _commands.Count - _currentCommandIndex);
			}

			// Adiciona o comando na lista
			_commands.Add(moveCommand);
			_currentCommandIndex++;
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				Move(MoveDirection.Up);
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				Move(MoveDirection.Down);
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				Move(MoveDirection.Right);
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				Move(MoveDirection.Left);
			}

			if (Input.GetKeyDown(KeyCode.Z))
			{
				Undo();
			}
			else if (Input.GetKeyDown(KeyCode.Y))
			{
				Redo();
			}

			UpdateLabel();
		}

		private void UpdateLabel()
		{
			string output = "  Start";
			if (_currentCommandIndex == 0)
			{
				output = $"> Start";
			}

			output += "\n";

			for (int i = 0; i < _commands.Count; i++)
			{
				if (i == _currentCommandIndex - 1)
				{
					output += $"> {_commands[i]}\n";
				}
				else
				{
					output += $"  {_commands[i]}\n";
				}
			}

			Text.text = output;
		}
	}
}
