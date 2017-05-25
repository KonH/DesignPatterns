using System;

namespace DesignPatterns.BehavioralPatterns {
	class StrategyPattern : Pattern {

		public override void Test() {
			TestProcessor(new MemoryTextReader("test"));
			TestProcessor(new ConsoleTextReader());
		}

		void TestProcessor(ITextReader reader) {
			var processor = new TextProcessor(reader);
			processor.ProcessInput();
		}

		class TextProcessor {

			ITextReader _reader = null;

			public TextProcessor(ITextReader reader) {
				_reader = reader;
			}

			public void ProcessInput() {
				var input = _reader.ReadLine();
				Console.WriteLine($"Input is '{input}'");
			}
		}

		interface ITextReader {
			string ReadLine();
		}

		class ConsoleTextReader : ITextReader {

			public string ReadLine() {
				Console.WriteLine("Input?");
				return Console.ReadLine();
			}
		}

		class MemoryTextReader : ITextReader {

			string _text = null;

			public MemoryTextReader(string text) {
				_text = text;
			}

			public string ReadLine() {
				return _text;
			}
		}
	}
}
