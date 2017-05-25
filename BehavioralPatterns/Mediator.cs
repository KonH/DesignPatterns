using System;
using System.Collections.Generic;

namespace DesignPatterns.BehavioralPatterns {
	class MediatorPattern : Pattern {

		public override void Test() {
			var mediator = new CollectionMediator();
			var simpleClient = new SimpleClient();
			mediator.AddClient(simpleClient);
			var revClient = new ReverseClient();
			mediator.AddClient(revClient);
			mediator.AddClient(new SimpleClient());

			simpleClient.Send("test");
			revClient.Send("message");
		}

		abstract class Mediator {
			public abstract void Send(string message, Client sender);
		}

		class CollectionMediator : Mediator {

			List<Client> _clients = new List<Client>();

			public void AddClient(Client client) {
				client.Mediator = this;
				_clients.Add(client);
			}

			public override void Send(string message, Client sender) {
				foreach ( var client in _clients ) {
					if ( client != sender ) {
						client.Notify(message);
					}
				}
			}
		}

		abstract class Client {

			public Mediator Mediator = null;

			public void Send(string message) {
				Console.WriteLine($"{GetHashCode()} send message: {message}.");
				Mediator.Send(message, this);
			}

			public abstract void Notify(string message);
		}

		class SimpleClient : Client {

			public override void Notify(string message) {
				Console.WriteLine($"{GetHashCode()} gets message: {message}.");
			}
		}

		class ReverseClient : Client {

			public override void Notify(string message) {
				var list = new List<char>(message);
				list.Reverse();
				string newMessage = "";
				foreach ( var c in list ) {
					newMessage += c;
				}
				Console.WriteLine($"{GetHashCode()} gets message: {newMessage}.");
			}
		}
	}
}
