using System;
using System.Threading.Tasks;

using MailKit.Security;

namespace GmailNewMessageListener
{
	class Program
	{
		// Connection-related properties
		public const SecureSocketOptions SslOptions = SecureSocketOptions.Auto;
		public const string Host = "imap.gmail.com";
		public const int Port = 993;

		// Authentication-related properties
		public static string Username = string.Empty;
		public static string Password = string.Empty;
		static Program()
        {
			dotenv.net.DotEnv.Load();
			Password = Environment.GetEnvironmentVariable("GmailPassword");
			Username = Environment.GetEnvironmentVariable("GmailUsername");
		}
		public static void Main(string[] args)
		{
			using (var client = new IdleClient())
			{
				Console.WriteLine("Hit any key to end the demo.");

				var idleTask = client.RunAsync();

				Task.Run(() => {
					Console.ReadKey(true);
				}).Wait();

				client.Exit();

				idleTask.GetAwaiter().GetResult();
			}
		}
	}
}
