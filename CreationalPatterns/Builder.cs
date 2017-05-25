using System;
using System.Collections.Generic;

namespace DesignPatterns.CreationalPatterns {
	class BuilderPattern : Pattern {

		public override void Test() {
			var director = new Director();
			TestBuilder(director, new IntStorageBuilder());
			TestBuilder(director, new StringStorageBuilder());
		}

		void TestBuilder(Director director, Builder builder) {
			director.Construct(builder);
			Console.WriteLine(builder.GetStorage().Aggregation);
		}

		class Director {

			public void Construct(Builder builder) {
				builder.CreateStorage();
				builder.FillStorage();
				builder.CalculateStorage();
			}
		}

		abstract class Builder {

			public abstract void CreateStorage();
			public abstract void FillStorage();
			public abstract void CalculateStorage();
			public abstract Storage GetStorage();
		}

		class IntStorageBuilder : Builder {

			IntStorage _storage = null;

			public override void CreateStorage() {
				_storage = new IntStorage();
			}

			public override void FillStorage() {
				_storage.AddRandom();
			}

			public override void CalculateStorage() {
				_storage.Aggregation = _storage.Aggregate() + ":i";
			}

			public override Storage GetStorage() {
				return _storage;
			}
		}

		class StringStorageBuilder : Builder {

			StringStorage _storage = null;

			public override void CreateStorage() {
				_storage = new StringStorage();
			}

			public override void FillStorage() {
				_storage.AddRandom();
				_storage.AddRandom();
				_storage.AddRandom();
			}

			public override void CalculateStorage() {
				_storage.Aggregation = _storage.Aggregate() + ":s";
			}

			public override Storage GetStorage() {
				return _storage;
			}
		}

		abstract class Storage {

			public string Aggregation { get; set; }

			protected Random _random = new Random();

			public abstract void AddRandom();
			public abstract string Aggregate();
		}

		class IntStorage : Storage {

			List<int> _items = new List<int>();

			public override void AddRandom() {
				_items.Add(_random.Next(100));
			}

			public override string Aggregate() {
				var sum = 0;
				foreach( var item in _items ) {
					sum += item;
				}
				return sum.ToString();
			}
		}

		class StringStorage : Storage {

			List<string> _items = new List<string>();

			public override void AddRandom() {
				var s = "";
				for ( int i = 0; i < 3; i++ ) {
					var c = (char)_random.Next(char.MaxValue);
					s += c;
				}
				_items.Add(s);
			}

			public override string Aggregate() {
				var sum = "";
				foreach ( var item in _items ) {
					sum += item + ";";
				}
				return sum;
			}
		}
	}
}
