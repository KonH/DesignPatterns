using System;

namespace DesignPatterns.BehavioralPatterns
{
    class StatePattern:Pattern
    {
		public override void Test() {
			var automat = new Automat();
			automat.Close();
			automat.PerformAction();
			automat.Open();
			automat.PerformAction();
			automat.Close();
			automat.PerformAction();
			automat.Open();
			automat.Close();
		}

		interface IState {
			bool Open();
			bool Close();
			void PerformAction();
		}

		class Automat : IState {

			IState State { get; set; }

			public Automat() {
				State = new ReadyToOpenState(this);
			}

			public bool Open() {
				return State.Open();
			}

			public bool Close() {
				return State.Close();
			}

			public void PerformAction() {
				State.PerformAction();
			}

			class ReadyToOpenState : IState {

				Automat _owner = null;

				public ReadyToOpenState(Automat owner) {
					Console.WriteLine("State: ReadyToOpen");
					_owner = owner;
				}

				public bool Close() {
					Console.WriteLine("It is not opened yet.");
					return false;
				}

				public bool Open() {
					_owner.State = new OpenState(_owner);
					return true;
				}

				public void PerformAction() {
					Console.WriteLine("Can't perform action.");
				}
			}

			class OpenState : IState {

				Automat _owner = null;

				public OpenState(Automat owner) {
					Console.WriteLine("State: Open");
					_owner = owner;
				}

				public bool Close() {
					_owner.State = new ClosedState(_owner);
					return true;
				}

				public bool Open() {
					Console.WriteLine("Already opened.");
					return false;
				}

				public void PerformAction() {
					Console.WriteLine("Action is performed.");
				}
			}

			class ClosedState : IState {

				Automat _owner = null;

				public ClosedState(Automat owner) {
					Console.WriteLine("State: Closed");
					_owner = owner;
				}

				public bool Close() {
					Console.WriteLine("Already closed.");
					return false;
				}

				public bool Open() {
					Console.WriteLine("Not ready to open.");
					return false;
				}

				public void PerformAction() {
					Console.WriteLine("Can't perform action.");
				}
			}
		}
	}
}
