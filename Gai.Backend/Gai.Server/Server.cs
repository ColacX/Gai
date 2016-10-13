using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;
using System.Net;
using NLog;
using Newtonsoft.Json;
using System.IO;
using Gai.Protocol;

namespace Gai.Server
{
	public class Server
	{
		bool running;
		ILogger Logger = LogManager.GetCurrentClassLogger();
		TcpListener listener;
		List<TcpClient> clients = new List<TcpClient>();
		List<Task> tasks = new List<Task>();

		private void SendEntity(StreamWriter writer, int entityId)
		{
			var jsonData = JsonConvert.SerializeObject(new { messageType = EMessageType.Entity });
			writer.WriteLine(jsonData);
		}

		public async Task AcceptClient(TcpClient client)
		{
			Logger.Trace("accepting client");
			clients.Add(client);

			while(running)
			{
				using(var stream = client.GetStream())
				using(var reader = new StreamReader(stream))
				using(var writer = new StreamWriter(stream))
				{
					var jsonData = await reader.ReadLineAsync();
					Logger.Debug(jsonData);
					dynamic data = JsonConvert.DeserializeObject(jsonData);

					switch((EMessageType)data.messageType)
					{
						case EMessageType.Entity:
							SendEntity(writer, (int)data.entityId);
							break;
					}
				}
			}
		}

		public async Task AwaitClients()
		{
			Logger.Trace("awaiting incoming clients");
			var serverPort = Convert.ToInt16(ConfigurationManager.AppSettings["serverPort"]);
			listener = new TcpListener(IPAddress.Any, serverPort);
			listener.Start();
			running = true;

			while(running)
			{
				try
				{
					var client = await listener.AcceptTcpClientAsync();
					tasks.Add(AcceptClient(client));
				}
				catch(Exception ex)
				{
					Logger.Error(ex);
				}
			}
		}

		public void Start()
		{
			Logger.Trace("start");
			tasks.Add(AwaitClients());
		}

		public void Stop()
		{
			Logger.Trace("stop");
			running = false;
			listener.Stop();

			foreach(var client in clients)
			{
				if(client.Connected)
					client.Close();
			}

			Task.WaitAll(tasks.ToArray());
		}

		static void Main(string[] args)
		{
			var server = new Server();
			server.Start();
			Console.ReadLine();
			server.Stop();
		}
	}
}
