using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralPatterns {
	class Flyweight : Pattern {

		public override void Test() {
			var factory = new FlyweightFactory();
			for(int i = 0; i < 4; i++ ) {
				TestObject(factory, "abc");
			}
			for ( int i = 0; i < 3; i++ ) {
				for ( int j = 0; j < 3; j++ ) {
					TestObject(factory, i.ToString());
				}
			}
		}

		void TestObject(FlyweightFactory factory, string param) {
			Console.WriteLine(factory.GetObject(param).GetValue());
		}

		class FlyweightFactory {

			Dictionary<string, IFlyweightObject> _pool = new Dictionary<string, IFlyweightObject>();

			public IFlyweightObject GetObject(string param) {
				IFlyweightObject obj = null;
				if( !_pool.TryGetValue(param, out obj) ) {
					obj = CreateObject(param);
					_pool[param] = obj;
				}
				return obj;
			}

			IFlyweightObject CreateObject(string param) {
				int value = 0;
				if ( int.TryParse(param, out value) ) {
					return new ConcreteIntFlyweight(value);
				}
				return new ConcreteStringFlyweight(param);
			}
		}

		interface IFlyweightObject {

			string GetValue();
		}

		class ConcreteIntFlyweight : IFlyweightObject {

			int _value = 0;
			string _strValue = null;

			public ConcreteIntFlyweight(int value) {
				_value = value;
				Console.WriteLine($"ConcreteIntFlyweight({value}) created.");
			}

			public string GetValue() {
				if ( _strValue == null ) {
					_strValue = _value.ToString();
				}
				return _strValue;
			}
		}

		class ConcreteStringFlyweight : IFlyweightObject {

			string _value = null;

			public ConcreteStringFlyweight(string value) {
				_value = value;
				Console.WriteLine($"ConcreteStringFlyweight({value}) created.");
			}

			public string GetValue() {
				return _value;
			}
		}
	}
}
