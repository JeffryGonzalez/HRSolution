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
		private readonly IEmployeeQueries employeeQueries;

		public EmployeesController(IEmployeeCommands employeeCommands, IEmployeeQueries employeeQueries)
		{
			this.employeeCommands = employeeCommands;
			this.employeeQueries = employeeQueries;
		}


		[Route("")]
		[ValidateModel] // <-- moved model validation to a reusable filter. See this class in infrastructure
		public HttpResponseMessage Post(NewEmployee employee)
		{
				var response = employeeCommands.Add(employee);

				return Request.CreateResponse(HttpStatusCode.Accepted, response);
		}

		[Route("{id:int}")]
		public NewEmployeeResponse Get(int id)
		{
			var response = employeeQueries.Find(id);
			GuardNotFound(response);
			return response;
		}

		private static void GuardNotFound(object response)
		{
			if (response == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
		}
	}
}
