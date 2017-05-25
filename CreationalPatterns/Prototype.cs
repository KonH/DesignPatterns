using System;

namespace DesignPatterns.CreationalPatterns {
	class PrototypePattern : Pattern {

		public override void Test() {
			var proto = new ConcreteItem("Item");
			var clone1 = proto.Clone();
			var clone2 = proto.Clone();
			Console.WriteLine(clone1 == clone2);
		}

		abstract class Prototype {

			public string Name { get; private set; }

			public Prototype(string name) {
				Name = name;
				Console.WriteLine("Prototype created");
			}
			
			public virtual Prototype Clone() {
				return (Prototype)MemberwiseClone();
			}
		}

		class ConcreteItem : Prototype {

			public ConcreteItem(string name) : base(name) {}
		}
	}
}
