using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using HrApi.Contracts;
using HrApi.Controllers;
using HrApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace HrApiUnitTests
{
	[TestClass]
	public class FindingAnEmployee
	{
		private IEmployeeQueries _employeeQueries;
		private NewEmployeeResponse _employeeToReturn;
		private EmployeesController _controller;

		[TestInitialize]
		public void SetterUp()
		{
			_employeeQueries = MockRepository.GenerateStub<IEmployeeQueries>();
			_employeeToReturn = new NewEmployeeResponse();
			_employeeQueries.Stub(f => f.Find(42)).Return(_employeeToReturn);
			_controller = new EmployeesController(null, _employeeQueries);

			Helpers.SetupController(_controller);
		}

		[TestMethod]
		public void ReturnsFoundEmployee()
		{
			var result = _controller.Get(42);
			Assert.AreSame(result, _employeeToReturn);
		}

		[TestMethod]
		public void GivesFourOhFour()
		{
			bool caught = false;
			try
			{
				var result = _controller.Get(99);
			}
			catch (HttpResponseException ex)
			{
				caught = ex.Response.StatusCode == HttpStatusCode.NotFound;
			}
			Assert.IsTrue(caught);
		}
	}
}
