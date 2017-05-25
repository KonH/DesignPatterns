using System;

namespace DesignPatterns.StructuralPatterns {

	class ProxyPattern : Pattern {

		public override void Test() {
			var summer = new RealSummer();
			summer.Sum(5, 10);

			var logSummer = new LoggerSummer();
			logSummer.Sum(10, 5);
		}

		interface ISummer {

			int Sum(int x, int y);
		}

		class RealSummer : ISummer {

			public int Sum(int x, int y) {
				return x + y;
			}
		}

		class LoggerSummer : ISummer {

			RealSummer _summer = new RealSummer();

			public int Sum(int x, int y) {
				var sum = _summer.Sum(x, y);
				Console.WriteLine($"Sum({x},{y}) = {sum}");
				return sum;
			}
		}
	}
}
