namespace DesignPatterns {

	public static class Utils {

		public static string ShortName<T>(T obj) {
			return obj.GetType().Name;
		}
	}
}
