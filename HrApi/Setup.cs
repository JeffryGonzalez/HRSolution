using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace HrApi
{
	public static class Setup
	{
		public static void Configure(HttpConfiguration config)
		{
			//  C#        ->  javaScript
			//"FirstName" -> "firstName" 
			var formatter = config.Formatters.JsonFormatter;
			var settings = formatter.SerializerSettings;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();


			config.MapHttpAttributeRoutes();
		}
	}
}
