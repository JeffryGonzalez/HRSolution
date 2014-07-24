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

		private IEmployeeCommands employeeCommands;

		public EmployeesController(IEmployeeCommands commands)
		{
			employeeCommands = commands;
		}

		

		[Route("")]
		[ValidateModel]
		public HttpResponseMessage Post(NewEmployee employee)
		{
			if (ModelState.IsValid)
			{
				var response = employeeCommands.Add(employee);

				return Request.CreateResponse(HttpStatusCode.Accepted, response);
			}
			else
			{
				throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ModelState));
			}
		}
	}
}
