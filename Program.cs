﻿using System.Collections.Generic;
using DesignPatterns.BehavioralPatterns;
using DesignPatterns.CreationalPatterns;
using DesignPatterns.StructuralPatterns;

namespace DesignPatterns {

	public class Program {

		public static void Main(string[] args) {
			var items = new List<Pattern> {
				new TemplateMethod(),
				new AbstractFactory(),
				new Builder(),
				new FactoryMethod(),
				new Prototype(),
				new Singleton(),
				new Decorator(),
				new Facade()
			};
			var selection = new Selection(items);
			selection.Process();
		}
	}
}
