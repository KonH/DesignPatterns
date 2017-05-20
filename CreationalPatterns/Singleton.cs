using System;

namespace DesignPatterns.CreationalPatterns {
	class Singleton : Pattern {

		public override void Test() {
			var instance0 = SingletonExample.Instance;
			instance0.Value = 1;
			var instance1 = SingletonExample.Instance;
			Console.WriteLine(instance0 == instance1);
			Console.WriteLine(instance1.Value);
		}

		sealed class SingletonExample {

			public static SingletonExample Instance {
				get { return _instanceHolder.Value; }
			}

			static readonly Lazy<SingletonExample> _instanceHolder =
				new Lazy<SingletonExample>(() => new SingletonExample());

			public int Value { get; set; }

			private SingletonExample() {}

		}
	}
}
