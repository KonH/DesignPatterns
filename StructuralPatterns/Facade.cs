using System;

namespace DesignPatterns.StructuralPatterns {
	class FacadePattern : Pattern {

		public override void Test() {
			var facade = new Facade();
			facade.LogWithTime("Test");
		}

		class TimeSubsystem {

			public string DateString {
				get {
					return DateTime.Now.ToString();
				}
			}
		}

		class LogSubsystem {

			public void WriteLine(string content) {
				Console.WriteLine(content);
			}
		}

		class Facade {

			TimeSubsystem _time = new TimeSubsystem();
			LogSubsystem  _log  = new LogSubsystem();

			public void LogWithTime(string content) {
				_log.WriteLine(string.Format($"{_time.DateString}: {content}"));
			}
		}
	}
}
