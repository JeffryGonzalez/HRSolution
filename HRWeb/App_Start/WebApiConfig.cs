
using System.Web.Http;

namespace HRWeb
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			HrApi.Setup.Configure(config);

		}
	}
}