using System;
using System.Collections.Generic;

namespace DesignPatterns.BehavioralPatterns {
	class ObserverPattern : Pattern {

		public override void Test() {
			var intObservable = new ObservableInterger();
			intObservable.State = 10;

			var observer0 = new IntChangeObserver();
			intObservable.AddObserver(observer0);
			intObservable.State = 15;

			var observer1 = new IntChangeObserver();
			intObservable.AddObserver(observer1);
			intObservable.State = 20;

			intObservable.RemoveObserver(observer0);
			intObservable.State = 30;

			intObservable.RemoveObserver(observer1);
			intObservable.State = 40;
		}

		interface IObservable {
			void AddObserver(IObserver observer);
			void RemoveObserver(IObserver observer);
			void NotifyObservers(int state);
		}

		class ObservableInterger : IObservable {

			public int State {
				get {
					return _state;
				}
				set {
					_state = value;
					Console.WriteLine($"New state: {_state}");
					NotifyObservers(_state);
				}
			}

			int _state = 0;
			List<IObserver> _observers = new List<IObserver>();

			public void AddObserver(IObserver observer) {
				_observers.Add(observer);
			}

			public void RemoveObserver(IObserver observer) {
				_observers.Remove(observer);
			}

			public void NotifyObservers(int state) {
				foreach ( var observer in _observers ) {
					observer.HandleEvent(state);
				}
			}
		}

		interface IObserver {
			void HandleEvent(int state);
		}

		class IntChangeObserver : IObserver {

			public void HandleEvent(int state) {
				Console.WriteLine($"{GetHashCode()} handles new state: {state}");
			}
		}
	}
}
