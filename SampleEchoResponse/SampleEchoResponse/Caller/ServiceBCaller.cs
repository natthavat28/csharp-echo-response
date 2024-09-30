using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleEchoResponse.Caller
{
	public class ServiceBCaller
	{
		public async Task DoAsync(dynamic data)
		{
			var reqMsg = new HttpRequestMessage();
			reqMsg.Method = HttpMethod.Post;
			reqMsg.RequestUri = new Uri("https://webhook.site/d8b57d47-fd23-4454-9789-3d694051dec5");
			reqMsg.Content = new StringContent(JsonConvert.SerializeObject(data));

			var resMsg = (HttpResponseMessage)null;
			using (var client = new HttpClient())
			{
				resMsg = await client.SendAsync(reqMsg);
			}
			resMsg.EnsureSuccessStatusCode();
		}
    }
}
