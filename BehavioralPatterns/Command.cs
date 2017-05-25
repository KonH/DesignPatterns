using System;
using System.Collections.Generic;

namespace DesignPatterns.BehavioralPatterns {
	class CommandPattern : Pattern {

		public override void Test() {
			var invoker = new Invoker();
			invoker.Compute("A");
			invoker.Compute("B");
			invoker.Compute("C");
			invoker.Undo(2);
			invoker.Redo(1);
		}

		abstract class Command {
			public abstract void Execute();
			public abstract void UnExecute();
		}

		class AddTextCommand : Command {
			string _content;
			TextHolder _holder;

			public AddTextCommand(TextHolder holder, string content) {
				_holder = holder;
				_content = content;
			}

			public override void Execute() {
				_holder.Operation(true, _content);
			}

			public override void UnExecute() {
				_holder.Operation(false, _content);
			}
		}

		class TextHolder {
			List<string> _texts = new List<string>();

			public void Operation(bool addRemove, string content) {
				if ( addRemove ) {
					_texts.Add(content);
				} else {
					_texts.Remove(content);
				}
				var str = "Content: {";
				foreach ( var text in _texts ) {
					str += text + "; ";
				}
				str += "}";
				Console.WriteLine(str);
			}
		}

		class Invoker {
			TextHolder _holder = new TextHolder();
			List<Command> _commands = new List<Command>();

			private int _current = 0;

			public void Redo(int count) {
				Console.WriteLine($"Redo x{count}");
				for ( int i = 0; i < count; i++ ) {
					if ( _current < _commands.Count ) {
						_commands[_current].Execute();
						_current++;
					}
				}
			}

			public void Undo(int count) {
				Console.WriteLine($"Undo x{count}");
				for ( int i = 0; i < count; i++ ) {
					if ( _current > 0 ) {
						_current--;
						_commands[_current].UnExecute();
					}
				}
			}

			public void Compute(string content) {
				Command command = new AddTextCommand(_holder, content);
				command.Execute();
				if ( _current < _commands.Count ) {
					_commands.RemoveRange(_current, _commands.Count - _current);
				}
				_commands.Add(command);
				_current++;
			}
		}
	}
}
