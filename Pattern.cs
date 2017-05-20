namespace DesignPatterns {

	abstract class Pattern {

		public string Name {
			get {
				return Utils.ShortName(this);
			}
		}

		public abstract void Test();
	}
}
