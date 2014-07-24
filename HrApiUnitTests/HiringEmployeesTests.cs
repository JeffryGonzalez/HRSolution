using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HrApi;
using Rhino.Mocks;
using System.Net.Http;

namespace HrApiUnitTests
{
	[TestClass]
	public class HiringEmployeesTests
	{
		[TestMethod]
		public void GivesTheNewEmployeeToTheEmployeeCommandService()
		{

			// arrange - GIVEN
			var employeeToAdd = new NewEmployee() { FirstName = "Boba", LastName = "Fett", Salary = 180000 };
			var employeeToReturn = new NewEmployeeResponse();

			var fakeEmployeeCommands = MockRepository.GenerateStub<IEmployeeCommands>();
			fakeEmployeeCommands.Stub(f => f.Add(employeeToAdd)).Return(employeeToReturn);

			
			var controller = new EmployeesController(fakeEmployeeCommands);
			Helpers.SetupController(controller);
			// act - WHEN
			var response = controller.Post(employeeToAdd);

			// assert - THEN
			var result = response.Content.ReadAsAsync<NewEmployeeResponse>().Result;

			Assert.AreSame(result, employeeToReturn);

		}
	}
}
