using System;

namespace DesignPatterns.BehavioralPatterns {
	class ChainOfResponsibilityPattern : Pattern {

		public override void Test() {
			var intHandler = new IntHandler();
			var strHandler = new StringHandler();
			var nullHandler = new NullHandler();
			intHandler.Successor = strHandler;
			strHandler.Successor = nullHandler;

			var input = new string[] { "123", "str", null };
			foreach ( var item in input ) {
				Console.WriteLine($"Input: {item}");
				intHandler.HandleRequest(item);
			}
		}

		abstract class Handler {

			public Handler Successor { get; set; }

			public abstract void HandleRequest(string content);
		}

		class IntHandler : Handler {

			public override void HandleRequest(string content) {
				int value = 0;
				if ( int.TryParse(content, out value) ) {
					Console.WriteLine($"It is int: {value}");
				} else if ( Successor != null ) {
					Successor.HandleRequest(content);
				}
			}
		}

		class StringHandler : Handler {

			public override void HandleRequest(string content) {
				if ( content != null ) {
					Console.WriteLine($"It is string: {content}");
				} else if ( Successor != null ) {
					Successor.HandleRequest(content);
				}
			}
		}

		class NullHandler : Handler {
			public override void HandleRequest(string content) {
				if ( content == null ) {
					Console.WriteLine("It is null");
				} else if ( Successor != null ) {
					Successor.HandleRequest(content);
				}
			}
		}
	}
}
