using System.Collections.Generic;
using DesignPatterns.BehavioralPatterns;
using DesignPatterns.CreationalPatterns;
using DesignPatterns.StructuralPatterns;

namespace DesignPatterns {

	public class Program {

		public static void Main(string[] args) {
			var items = new List<Pattern> {
				new TemplateMethod(),
				new Visitor(),
				new AbstractFactory(),
				new Builder(),
				new FactoryMethod(),
				new Prototype(),
				new Singleton(),
				new Adapter(),
				new Bridge(),
				new Composite(),
				new Decorator(),
				new Facade(),
				new Flyweight(),
				new Proxy()
			};
			var selection = new Selection(items);
			selection.Process();
		}
	}
}
