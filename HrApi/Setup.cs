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
			UseJsonCamelCaseFormatter(config);

			// No longer using standard routing, all attribute-based
			config.MapHttpAttributeRoutes();

			SetupUnityContainer(config);

			SetupAutoMapperMappings();
			
		}

		/// <summary>
		/// JSON results are now camelCased to make them more idiomatic JavaScript	
		/// </summary>
		/// <param name="config"></param>
		private static void UseJsonCamelCaseFormatter(HttpConfiguration config)
		{
			var formatter = config.Formatters.JsonFormatter;
			var settings = formatter.SerializerSettings;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}

		/// <summary>
		/// Allows for mapping (copying) properties from one object to another.
		/// See http://automapper.org/
		/// </summary>
		public static void SetupAutoMapperMappings()
		{
			Mapper.CreateMap<NewEmployee, Employee>()
				.ForMember(dest => dest.Email, opt => opt.Ignore())
				.ForMember(dest => dest.Id, opt => opt.Ignore());

			Mapper.CreateMap<Employee, NewEmployeeResponse>();
		}

		/// <summary>
		/// Uses Unity for IOC. The UnityResolver class is in the Infrastructure namespace
		/// </summary>
		/// <param name="config"></param>
		public static void SetupUnityContainer(HttpConfiguration config)
		{
			var container = new UnityContainer();
			container.RegisterType<IEmployeeCommands, StandardEmployeeCommands>();
			container.RegisterType<IFormatEmailAddresses, CorporateEmailFormatter>();

			var resolver = new UnityResolver(container);

			config.DependencyResolver = resolver;
		}
	}
}
