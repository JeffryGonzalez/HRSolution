using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace EmployeesApiIntegrationTests
{
	[TestClass]
	public class HiringEmployeesHappyPathTests
	{
		private object employeeToAdd;
		[TestInitialize]
		public void Setup()
		{
			employeeToAdd = new { firstName= "Joe", lastName= "Schmidt", salary= 30000 };
		}

		[TestMethod]
		public void GivesACreatedResponseCode()
		{
			using (var client = Helpers.CreateHttpClient())
			{
				var response = client.PostAsJsonAsync("/api/employees", employeeToAdd).Result;

				Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
			}
		}

		[TestMethod]
		public void GeneratesAnEmailAddress()
		{
			using (var client = Helpers.CreateHttpClient())
			{
				var response = client.PostAsJsonAsync("/api/employees", employeeToAdd).Result;
				string email = null;

				dynamic addedEmployee = JObject.Parse(response.Content.ReadAsStringAsync().Result);
				email = addedEmployee.email.Value;

				Assert.AreEqual("joe-schmidt@company.com", email);
			}
		}
	}
}
