using HrApi;
using System;
using System.Net.Http;
using System.Web.Http.SelfHost;

namespace EmployeesApiIntegrationTests
{
	public static class Helpers
	{
		public static HttpClient CreateHttpClient()
		{

			var baseAddress = new Uri("http://localhost:8080");

			var config = new HttpSelfHostConfiguration(baseAddress);

			// ?
			Setup.Configure(config);

			var server = new HttpSelfHostServer(config);

			var client = new HttpClient(server); // <--- MAGIC!

			try
			{
				client.BaseAddress = baseAddress;
				return client;

			}
			catch
			{
				client.Dispose();
				throw;
			}

		}
	}
}
