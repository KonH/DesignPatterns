using System;

namespace DesignPatterns.StructuralPatterns {

	class DecoratorPattern : Pattern {

		public override void Test() {
			TestItem(new TextWriter());
			TestItem(new StarTextWriterDecorator());
		}

		void TestItem(TextWriterComponent comp) {
			comp.WriteLine(Utils.ShortName(comp));
		}

		abstract class TextWriterComponent {

			public abstract void WriteLine(string content);
		}

		class TextWriter : TextWriterComponent {

			public override void WriteLine(string content) {
				Console.WriteLine(content);
			}
		}

		abstract class TextWriterDecorator : TextWriterComponent {

			protected TextWriter _writer = null;

			public TextWriterDecorator(TextWriter writer) {
				_writer = writer;
			}
		}

		class StarTextWriterDecorator : TextWriterDecorator {

			public StarTextWriterDecorator():base(new TextWriter()) { }

			public override void WriteLine(string content) {
				var newContent = $"*{content}*";
				_writer.WriteLine(newContent);
			}
		}
	}
}
