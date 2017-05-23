using System;

namespace DesignPatterns.BehavioralPatterns {
	class Visitor : Pattern {

		public override void Test() {
			var elements = new IElement[] { new IntElement(100), new StringElement("test") };
			var visitor = new LogVisitor();
			foreach ( var elem in elements ) {
				elem.Accept(visitor);
			}
		}

		interface IElement {
			int Code { get; }
			void Accept(IVisitor visitor);
		}

		class IntElement : IElement {

			public int Code { get { return Value; } }
			public int Value { get; }

			public IntElement(int value) {
				Value = value;
			}

			public void Accept(IVisitor visitor) {
				visitor.Visit(this);
			}
		}

		class StringElement : IElement {

			public int Code { get { return Value.GetHashCode(); } }
			public string Value { get; }

			public StringElement(string value) {
				Value = value;
			}

			public void Accept(IVisitor visitor) {
				visitor.Visit(this);
			}
		}

		interface IVisitor {
			void Visit(IntElement element);
			void Visit(StringElement element);
		}

		class LogVisitor : IVisitor {

			public void Visit(IntElement element) {
				Console.WriteLine($"Int:{element.Value}({element.Code})");
			}

			public void Visit(StringElement element) {
				Console.WriteLine($"String:'{element.Value}'({element.Code})");
			}
		}
	}
}
