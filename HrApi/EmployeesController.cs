using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HrApi
{
	public class EmployeesController : ApiController
	{

		private IEmployeeCommands employeeCommands;

		public EmployeesController(IEmployeeCommands commands)
		{
			employeeCommands = commands;
		}

		public EmployeesController() //TODO: Use IOC instead. This is lame.
		{
			employeeCommands = new StandardEmployeeCommands(new CorporateEmailFormatter());
		}

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

	public class NewEmployee
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Range(1D, 1000000D)]
		public decimal Salary { get; set; }
	}

	public class NewEmployeeResponse : NewEmployee 
	{
		public int Id {get; set;}
		public string Email {get; set;}
	}
}
