namespace DesignPatterns {

	abstract class Pattern {
		public string Name { get; private set; }

		public Pattern(string name) {
			Name = name;
		}

		public abstract void Test();
	}
}
