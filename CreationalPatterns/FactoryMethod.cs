using System;

namespace DesignPatterns.CreationalPatterns {
	class FactoryMethodPattern : Pattern {

		public override void Test() {
			TestCreator(new TestItemACreator());
			TestCreator(new TestItemBCreator());
		}

		void TestCreator(TestItemCreator creator) {
			var item = creator.Create();
			Console.WriteLine($"{item.Name}: {item.Checksum}");
		}

		abstract class TestItemCreator {

			protected abstract TestItem CreateInstance();

			public TestItem Create() {
				var item = CreateInstance();
				item.Checksum = item.Name.GetHashCode();
				return item;
			}
		}

		class TestItemACreator:TestItemCreator {

			protected override TestItem CreateInstance() {
				return new TestItemA();
			}
		}

		class TestItemBCreator : TestItemCreator {

			protected override TestItem CreateInstance() {
				return new TestItemB();
			}
		}

		abstract class TestItem {

			public abstract string Name { get; }
			public int Checksum { get; set; } 
		}

		class TestItemA : TestItem {

			public override string Name { get { return "Item_A"; } }
		}

		class TestItemB : TestItem {

			public override string Name { get { return "Item_B"; } }
		}
	}
}
