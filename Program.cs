using System.Collections.Generic;
using DesignPatterns.BehavioralPatterns;
using DesignPatterns.CreationalPatterns;
using DesignPatterns.StructuralPatterns;

namespace DesignPatterns {

	public class Program {

		public static void Main(string[] args) {
			var items = new List<Pattern> {
				new CommandPattern(),
				new IteratorPattern(),
				new MediatorPattern(),
				new MementoPattern(),
				new StrategyPattern(),
				new TemplateMethodPattern(),
				new VisitorPattern(),
				new AbstractFactoryPattern(),
				new BuilderPattern(),
				new FactoryMethodPattern(),
				new PrototypePattern(),
				new SingletonPattern(),
				new AdapterPattern(),
				new BridgePattern(),
				new CompositePattern(),
				new DecoratorPattern(),
				new FacadePattern(),
				new FlyweightPattern(),
				new ProxyPattern()
			};
			var selection = new Selection(items);
			selection.Process();
		}
	}
}
