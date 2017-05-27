using System;
using System.Collections.Generic;

namespace DesignPatterns.BehavioralPatterns {
	class InterpreterPattern : Pattern {

		public override void Test() {

			var context = new Context();

			var operations = new List<AbstractExpression>();
			operations.Add(new TerminalExpression());
			operations.Add(new NonterminalExpression());
			operations.Add(new TerminalExpression());

			foreach ( var op in operations ) {
				op.Interpret(context);
			}
		}

		class Context {}


		abstract class AbstractExpression {
			public abstract void Interpret(Context context);
		}

		class TerminalExpression : AbstractExpression {

			public override void Interpret(Context context) {
				Console.WriteLine("TerminalExpression.Interpret()");
			}
		}

		class NonterminalExpression : AbstractExpression {

			public override void Interpret(Context context) {
				Console.WriteLine("NonterminalExpression.Interpret()");
			}
		}
	}
}
