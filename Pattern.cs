namespace DesignPatterns {

	abstract class Pattern {

		const string PatternSuffix = "Pattern";

		public string Name {
			get {
				var rawName = Utils.ShortName(this);
				if ( rawName.EndsWith(PatternSuffix) ) {
					return rawName.Substring(0, rawName.Length - PatternSuffix.Length);
				}
				return rawName;
			}
		}

		public abstract void Test();
	}
}
