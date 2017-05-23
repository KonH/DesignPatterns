using System;
using System.Collections.Generic;

namespace DesignPatterns.BehavioralPatterns
{
    class Iterator:Pattern
    {
		public override void Test() {
			var aggregate = new ListAggregate();
			aggregate[0] = 10;
			aggregate[1] = 20;
			aggregate[2] = 30;

			var iter = aggregate.CreateIterator();
			while ( !iter.IsDone() ) {
				Console.WriteLine(iter.Current());
				iter.Next();
			}
		}

		interface IAggregate {
			IIteratorExample CreateIterator();
			int Count { get; }
			object this[int index] { get; set; }
		}

		class ListAggregate : IAggregate {

			List<int> _items = new List<int>();

			public IIteratorExample CreateIterator() {
				return new ConcreteIterator(this);
			}

			public int Count {
				get { return _items.Count; }
				protected set { }
			}

			public object this[int index] {
				get { return _items[index]; }
				set { _items.Insert(index, (int)value); }
			}
		}

		interface IIteratorExample {
			object First();
			object Next();
			bool IsDone();
			object Current();
		}

		class ConcreteIterator : IIteratorExample {

			IAggregate _aggregate;
			int _current;

			public ConcreteIterator(IAggregate aggregate) {
				_aggregate = aggregate;
			}

			public object First() {
				return _aggregate[0];
			}

			public object Next() {
				object result = null;
				_current++;
				if ( _current < _aggregate.Count ) {
					result = _aggregate[_current];
				}
				return result;
			}

			public object Current() {
				return _aggregate[_current];
			}

			public bool IsDone() {
				return _current >= _aggregate.Count;
			}
		}
	}
}
