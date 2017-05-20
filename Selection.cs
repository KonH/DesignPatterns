using System;
using System.Collections.Generic;

namespace DesignPatterns {

	class Selection {
		public List<Pattern> Items { get; private set; }

		public Selection(List<Pattern> items) {
			Items = items;
		}

		public void Process() {
			NextLine();
			WriteLine("0: Exit");
			for ( int i = 0; i < Items.Count; i++ ) {
				var item = Items[i];
				WriteLine($"{i + 1}: {item.Name}");
			}
			WriteLine("Select:");
			var selection = Console.ReadLine();
			var selectionIndex = 0;
			if ( int.TryParse(selection, out selectionIndex) ) {
				if ( selectionIndex > 0 ) {
					var itemIndex = selectionIndex - 1;
					if ( itemIndex < Items.Count ) {
						var item = Items[itemIndex];
						NextLine();
						WriteLine($"{item.Name}:");
						NextLine();
						item.Test();
					}
				} else {
					return;
				}
			}
			Process();
		}

		void NextLine() {
			Console.WriteLine();
		}

		void WriteLine(string content) {
			Console.WriteLine(content);
		}
	}
}
