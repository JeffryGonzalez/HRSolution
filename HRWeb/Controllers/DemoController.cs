using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HRWeb.Controllers
{
	[RoutePrefix("api/icecream")]
	public class DemoController : ApiController
	{
		// GET /api/Demo
		[HttpGet]
		[Route("flavors/my/favorite")]
		public IEnumerable<string> FavoriteFlavors()
		{
			return new List<string> { "Chocolate", "Strawberry", "Vanilla" };
		}
	}

	[RoutePrefix("jobs/{jobId:int}")]
	public class Demo2Controller : ApiController
	{
		// GET customers/15/orders
		// GET jobs/13/errors
		[HttpGet]
		[Route("errors")]
		public IEnumerable<string> Errors(int jobId)
		{
			return new List<string> { jobId + " Late ", jobId + " Ugly " };
		}
	}

	[RoutePrefix("users")]
	public class Demo3Controller : ApiController
	{
		// GET users/3
		[Route("{id:int}")]
		public string GetById(int id)
		{
			return "You said " + id + " as an integer";
		}
		// GET users/bob
		[Route("{name:alpha}")]
		public string GetByString(string name)
		{
			return "You said " + name + " as a string ";
		} 

		[Route(@"{ssn:regex(^\d{3}-\d{2}-\d{4}$)}")]
		public string GetBySSN(string ssn)
		{
			return "You said " + ssn + " is your SSN";
		}

	}
}