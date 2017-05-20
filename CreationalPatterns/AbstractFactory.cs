using System;

namespace DesignPatterns.CreationalPatterns {

	class AbstractFactoryPattern : Pattern {

		public override void Test() {
			TestFactory(new SimpleLoggerFactory());
			TestFactory(new ExtendedLoggerFactory());
			TestFactory(new TemplateLoggerFactory<CustomLogger>());
		}

		void TestFactory(LoggerFactory loggerFactory) {
			var logger = loggerFactory.Create();
			logger.WriteLine($"{Utils.ShortName(loggerFactory)} create {Utils.ShortName(logger)}");
		}

		abstract class LoggerFactory {

			public abstract Logger Create();
		}

		class SimpleLoggerFactory : LoggerFactory {

			public override Logger Create() {
				return new SimpleLogger();
			}
		}

		class ExtendedLoggerFactory : LoggerFactory {

			public override Logger Create() {
				return new ExtendedLogger();
			}
		}

		class TemplateLoggerFactory<T> : LoggerFactory where T: Logger {

			public override Logger Create() {
				return Activator.CreateInstance<T>();
			}
		}

		abstract class Logger {

			public abstract void WriteLine(string content);
		}

		class SimpleLogger : Logger {

			public override void WriteLine(string content) {
				Console.WriteLine(content);
			}
		}

		class ExtendedLogger : Logger {

			public override void WriteLine(string content) {
				var dt = DateTime.Now;
				Console.WriteLine($"{dt.ToLocalTime()}: {content}");
			}
		}

		class CustomLogger : Logger {

			int _index = 0;

			public override void WriteLine(string content) {
				Console.WriteLine($"{_index}: {content}");
				_index++;
			}
		}
	}
}
