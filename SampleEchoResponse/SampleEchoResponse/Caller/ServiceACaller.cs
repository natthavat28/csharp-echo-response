using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleEchoResponse.Caller
{
	public class ServiceACaller
	{
		public async Task<JObject> DoAsync()
		{
			var reqMsg = new HttpRequestMessage();
			reqMsg.Method = HttpMethod.Get;
			reqMsg.RequestUri = new Uri("https://reqres.in/api/users/2");

			var resMsg = (HttpResponseMessage)null;
			using (var client = new HttpClient())
			{
				resMsg = await client.SendAsync(reqMsg);
			}
			resMsg.EnsureSuccessStatusCode();
			var resTxt = await resMsg.Content.ReadAsStringAsync();
			return JObject.Parse(resTxt);
		}
    }
}
