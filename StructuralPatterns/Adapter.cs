using System;

namespace DesignPatterns.StructuralPatterns {
	class AdapterPattern : Pattern {

		public override void Test() {
			Target target = new Adapter();
			target.PrintValue(42);
		}

		class Target {

			public virtual void PrintValue(int value) {
				Console.Write(value);
			}
		}

		class Adapter : Target {

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
