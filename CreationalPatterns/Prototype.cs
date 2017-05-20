using System;

namespace DesignPatterns.CreationalPatterns {
	class Prototype : Pattern {

		public override void Test() {
			var proto = new ConcreteItem("Item");
			var clone1 = proto.Clone();
			var clone2 = proto.Clone();
			Console.WriteLine(clone1 == clone2);
		}

		abstract class PrototypeExample {

			public string Name { get; private set; }

			public PrototypeExample(string name) {
				Name = name;
				Console.WriteLine("Prototype created");
			}
			
			public virtual PrototypeExample Clone() {
				return (PrototypeExample)MemberwiseClone();
			}
		}

		class ConcreteItem : PrototypeExample {

			public ConcreteItem(string name) : base(name) {}
		}
	}
}
