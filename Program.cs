using System.Collections.Generic;
using DesignPatterns.CreationalPatterns;
using DesignPatterns.StructuralPatterns;

namespace DesignPatterns {

	public class Program {

		public static void Main(string[] args) {
			var items = new List<Pattern> {
				new AbstractFactoryPattern(),
				new Decorator()
			};
			var selection = new Selection(items);
			selection.Process();
		}
	}
}
