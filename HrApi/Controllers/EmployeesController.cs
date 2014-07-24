using System.Net;
using System.Net.Http;
using System.Web.Http;
using HrApi.Contracts;
using HrApi.Implementors;
using HrApi.Infrastructure;
using HrApi.Models;

namespace HrApi.Controllers
{
	[RoutePrefix("api/employees")]
	public class EmployeesController : ApiController
	{

		private readonly IEmployeeCommands employeeCommands;

		public EmployeesController(IEmployeeCommands commands)
		{
			employeeCommands = commands;
		}
		

		[Route("")]
		[ValidateModel] // <-- moved model validation to a reusable filter. See this class in infrastructure
		public HttpResponseMessage Post(NewEmployee employee)
		{
				var response = employeeCommands.Add(employee);

				return Request.CreateResponse(HttpStatusCode.Accepted, response);
		}
	}
}
