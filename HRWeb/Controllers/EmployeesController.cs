using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRWeb.Controllers
{
	public class EmployeesController : Controller
	{
		// GET /Employees/Hr
		public ActionResult Hr()
		{
			return View();
		}
	}
}