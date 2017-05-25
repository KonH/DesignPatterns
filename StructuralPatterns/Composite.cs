using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralPatterns {
	class CompositePattern : Pattern {

		public override void Test() {
			
			var root = new NodeComposite("Root");

			root.Add(new Node("Node_1"));
			root.Add(new Node("Node_2"));

			var comp = new NodeComposite("NodeComposite_1");
			comp.Add(new Node("Node_1_1"));
			comp.Add(new Node("Node_1_2"));

			root.Add(comp);

			root.Add(new Node("Node_3"));

			root.Show(1);
		}

		abstract class Component {

			protected string _name;

			public Component(string name) {
				_name = name;
			}

			protected void ShowName(int depth) {
				var prefix = new String('-', depth);
				Console.WriteLine(prefix + _name);
			}

			public abstract void Show(int depth);
		}

		class NodeComposite : Component {

			List<Component> _childs = new List<Component>();

			public NodeComposite(string name) : base(name) {}

			public void Add(Component component) {
				_childs.Add(component);
			}

			public void Remove(Component component) {
				_childs.Remove(component);
			}

			public override void Show(int depth) {
				ShowName(depth);
				foreach ( var child in _childs ) {
					child.Show(depth + 1);
				}
			}
		}

		class Node : Component {
			
			public Node(string name) : base(name) {}

			public override void Show(int depth) {
				ShowName(depth);
			}
		}
	}
}
