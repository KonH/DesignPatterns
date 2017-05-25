using System;

namespace DesignPatterns.CreationalPatterns {
	class SingletonPattern : Pattern {

		public override void Test() {
			var instance0 = Singleton.Instance;
			instance0.Value = 1;
			var instance1 = Singleton.Instance;
			Console.WriteLine(instance0 == instance1);
			Console.WriteLine(instance1.Value);
		}

		sealed class Singleton {

			public static Singleton Instance {
				get { return _instanceHolder.Value; }
			}

			static readonly Lazy<Singleton> _instanceHolder =
				new Lazy<Singleton>(() => new Singleton());

			public int Value { get; set; }

			private Singleton() {}

		}
	}
}
