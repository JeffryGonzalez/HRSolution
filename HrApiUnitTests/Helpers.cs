using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace HrApiUnitTests
{
	public static class Helpers
	{
		public static void SetupController(ApiController controller)
		{
			SetupController(controller, HttpMethod.Post,

"http://localhost/api/Employees", "employees");
		}

		private static void SetupController(ApiController controller, HttpMethod

method, string uri, string controllerName)
		{
			var config = new HttpConfiguration();
			var request = new HttpRequestMessage(method, uri);
			var route = config.Routes.MapHttpRoute("EmployeesController",

"api/{controller}/{id}", new { id = RouteParameter.Optional });
			var routeData = new HttpRouteData(route, new

HttpRouteValueDictionary() { { "controller", controllerName } });

			controller.ControllerContext = new HttpControllerContext(config,

routeData, request);

			controller.Request = request;
			controller.Request.Properties["MS_HttpConfiguration"] = config;
			controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] =

routeData;
		}
	}


}
