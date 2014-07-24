using HrApi.Contracts;
using HrApi.Implementors;
using HrApi.Infrastructure;
using Microsoft.Practices.Unity;
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

			var container = new UnityContainer();
			container.RegisterType<IEmployeeCommands, StandardEmployeeCommands>();
			container.RegisterType<IFormatEmailAddresses, CorporateEmailFormatter>();

			var resolver = new UnityResolver(container);

			config.DependencyResolver = resolver;
		}
	}
}
