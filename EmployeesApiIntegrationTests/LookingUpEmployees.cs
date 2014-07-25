using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace EmployeesApiIntegrationTests
{
	[TestClass]
	public class LookingUpEmployees
	{
	
		[TestMethod]
		public void FindingAnEmployeeById()
		{
			using (var client = Helpers.CreateHttpClient())
			{
				var result = client.GetStringAsync("/api/employees/1").Result;
				dynamic employee = JObject.Parse(result);
				Assert.IsTrue(Matches(employee));
			}
		}

		private bool Matches(dynamic employee)
		{
			return employee.firstName.Value == "Bob"
			       && employee.lastName.Value == "Smith"
			       && decimal.Parse(employee.salary.Value.ToString()) == 32000
			       && int.Parse(employee.id.Value.ToString()) == 1;
		}

		[TestMethod]
		public void NotFoundGivesFourOhFour()
		{
			using (var client = Helpers.CreateHttpClient())
			{
				var result = client.GetAsync("/api/employees/99").Result;
				Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound);
			}
		}
	}
}
