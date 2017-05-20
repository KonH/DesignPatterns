using System.Collections.Generic;
using DesignPatterns.CreationalPatterns;

namespace DesignPatterns {

	public class Program {

		public static void Main(string[] args) {
			var items = new List<Pattern> {
				new AbstractFactoryPattern()
			};
			var selection = new Selection(items);
			selection.Process();
		}
	}
}
