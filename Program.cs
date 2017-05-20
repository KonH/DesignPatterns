using System.Collections.Generic;
using DesignPatterns.BehavioralPatterns;
using DesignPatterns.CreationalPatterns;
using DesignPatterns.StructuralPatterns;

namespace DesignPatterns {

	public class Program {

		public static void Main(string[] args) {
			var items = new List<Pattern> {
				new TemplateMethod(),
				new AbstractFactory(),
				new Singleton(),
				new Decorator()
			};
			var selection = new Selection(items);
			selection.Process();
		}
	}
}
