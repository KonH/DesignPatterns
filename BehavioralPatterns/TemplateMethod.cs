using System;

namespace DesignPatterns.BehavioralPatterns {

	class TemplateMethodPattern : Pattern {

		public override void Test() {
			TestItem(new IntWritter());
			TestItem(new FloatWritter());
		}

		void TestItem(ConditionalWritter writer) {
			writer.Write(int.MaxValue.ToString());
			writer.Write(float.MaxValue.ToString());
		}

		abstract class ConditionalWritter {

			protected abstract bool CanWrite(string value);

			protected virtual void WriteInternal(string value) {
				Console.WriteLine($"{Utils.ShortName(this)}: {value}");
			}

			public void Write(string value) {
				if ( CanWrite(value) ) {
					WriteInternal(value);
				} else {
					WriteInternal($"\"{value}\" is not supported.");
				}
			}
		}

		class IntWritter : ConditionalWritter {

			protected override bool CanWrite(string value) {
				int intValue = 0;
				return int.TryParse(value, out intValue);
			}
		}

		class FloatWritter : ConditionalWritter {

			protected override bool CanWrite(string value) {
				float floatValue = 0;
				return float.TryParse(value, out floatValue);
			}
		}
	}
}
