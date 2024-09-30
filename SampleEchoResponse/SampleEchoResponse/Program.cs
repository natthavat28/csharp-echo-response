using Newtonsoft.Json.Linq;
using SampleEchoResponse.Caller;
using System;
using System.Threading.Tasks;

namespace SampleEchoResponse
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var callerA = new ServiceACaller();
			var callerB = new ServiceBCaller();
			var resA = await callerA.DoAsync();
			var newData = new
			{
				a = 1,
				b = "2",
				c = 3.33,
				d = true,
			};
			resA["newData"] = JObject.FromObject(newData);
			(resA.GetValue("data") as JObject).Add("newField", 11111);
			await callerB.DoAsync(resA);

			Console.WriteLine("Hello, World!");
		}
	}
}
