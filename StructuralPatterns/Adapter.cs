using System;

namespace DesignPatterns.StructuralPatterns {
	class Adapter : Pattern {

		public override void Test() {
			Target target = new AdapterExample();
			target.PrintValue(42);
		}

		class Target {

			public virtual void PrintValue(int value) {
				Console.Write(value);
			}
		}

		class AdapterExample : Target {

			Adaptee _adaptee = new Adaptee();

			public override void PrintValue(int value) {
				_adaptee.Print(new AdapteeWriter(), value);
			}
		}

		class AdapteeWriter {

			public void PrintValue(string value) {
				Console.WriteLine(value);
			}
		}

		class Adaptee {

			public void Print(AdapteeWriter writer, int value) {
				writer.PrintValue(value.ToString());
			}
		}
	}
}
