using System;

namespace DesignPatterns.BehavioralPatterns {
	class MementoPattern : Pattern {

		public override void Test() {
			var originator = new Originator(10);
			var caretaker = new Caretaker();
			TestOperation(originator, caretaker, 5);
			TestOperation(originator, caretaker, 0);
		}

		void TestOperation(Originator originator, Caretaker caretaker, double value) {
			Print(originator);
			caretaker.SaveState(originator);
			originator.Devide(value);
			Print(originator);
			caretaker.RestoreState(originator);
			Print(originator);
			Console.WriteLine();
		}

		void Print(Originator originator) {
			Console.WriteLine(originator.ValueString);
		}

		interface IOriginator {
			object GetMemento();
			void SetMemento(object memento);
		}

		class Originator : IOriginator {

			class Memento {
				public double Value { get; set; }
			}

			public string ValueString {
				get {
					return $"State: {_value}";
				}
			}

			double _value = 10;

			public Originator(double value) {
				_value = value;
			}

			public object GetMemento() {
				return new Memento { Value = _value };
			}

			public void SetMemento(object memento) {
				_value = ((Memento)memento).Value;
			}

			public void Devide(double value) {
				try {
					_value = _value / value;
				} catch {
					_value = double.NaN;
				}
			}
		}

		class Caretaker {

			object _memento = null;

			public void SaveState(IOriginator originator) {
				_memento = originator.GetMemento();
			}

			public void RestoreState(IOriginator originator) {
				originator.SetMemento(_memento);
			}
		}
	}
}
