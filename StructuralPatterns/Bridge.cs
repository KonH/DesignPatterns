using System;

namespace DesignPatterns.StructuralPatterns {
	class BridgePattern : Pattern {

		public override void Test() {
			var bridge = new Bridge();

			bridge.Implementor = new ImplementorA();
			bridge.Method();

			bridge.Implementor = new ImplementorB();
			bridge.Method();
		}

		class Bridge {

			public Implementor Implementor { get; set; }

			public virtual void Method() {
				Implementor.Method();
			}
		}

		abstract class Implementor {

			public abstract void Method();
		}

		class ImplementorA : Implementor {

			public override void Method() {
				Console.WriteLine("A");
			}
		}

		class ImplementorB : Implementor {

			public override void Method() {
				Console.WriteLine("B");
			}
		}
	}
}
