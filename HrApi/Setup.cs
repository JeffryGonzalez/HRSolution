using AutoMapper;
using HrApi.Contracts;
using HrApi.Implementors;
using HrApi.Infrastructure;
using HrApi.Models;
using HrDomain;
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

			SetupContainer(config);

			SetupMappings();
			
		}

		public static void SetupMappings()
		{
			Mapper.CreateMap<NewEmployee, Employee>()
				.ForMember(dest => dest.Email, opt => opt.Ignore())
				.ForMember(dest => dest.Id, opt => opt.Ignore());

			Mapper.CreateMap<Employee, NewEmployeeResponse>();
		}

		public static void SetupContainer(HttpConfiguration config)
		{
			var container = new UnityContainer();
			container.RegisterType<IEmployeeCommands, StandardEmployeeCommands>();
			container.RegisterType<IFormatEmailAddresses, CorporateEmailFormatter>();

			var resolver = new UnityResolver(container);

			config.DependencyResolver = resolver;
		}
	}
}
