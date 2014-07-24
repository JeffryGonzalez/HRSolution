using System;
using System.Data.Entity;
using AutoMapper;
using HrApi.Contracts;
using HrApi.Controllers;
using HrApi.Implementors;
using HrApi.Models;
using HrDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HrApi;
using Rhino.Mocks;

namespace HrApiUnitTests
{
	[TestClass]
	public class StandardEmployeeCommandsTests
	{
		private IFormatEmailAddresses dummyEmailProvider;
		[TestInitialize]
		public void GetReady()
		{
			Setup.SetupAutoMapperMappings();
			dummyEmailProvider = MockRepository.GenerateStub<IFormatEmailAddresses>();
			dummyEmailProvider.Stub(f => f.For("Bob", "Smith")).Return("studboy@aol.com");

		}
		[TestMethod]
		public void GetsAnEmailAddress()
		{
			var fakeContext = MockRepository.GenerateStub<HrContext>();
			var fakeSet = MockRepository.GenerateStub<DbSet<Employee>>();
			fakeContext.Employees = fakeSet;

			var ec = new StandardEmployeeCommands(dummyEmailProvider, fakeContext);

			var result = ec.Add(new NewEmployee { FirstName = "Bob", LastName = "Smith" });

			Assert.AreEqual("studboy@aol.com", result.Email);
		}

		[TestMethod]
		public void AddsEmployeeToSet()
		{
			
			var fakeContext = MockRepository.GenerateStub<HrContext>();
			var fakeSet = MockRepository.GenerateMock<DbSet<Employee>>();
			fakeSet.Expect(f => f.Add(Arg<Employee>.Matches(
				a => a.FirstName == "Bob"
				&& a.LastName == "Smith"
				&& a.Email == "studboy@aol.com"
				&& a.Salary == 30000)));
			fakeContext.Employees = fakeSet;
			
			var ec = new StandardEmployeeCommands(dummyEmailProvider, fakeContext);

			var result = ec.Add(new NewEmployee { FirstName = "Bob", LastName = "Smith", Salary = 30000});

			fakeSet.VerifyAllExpectations();
		
		}

		[TestMethod]
		public void CallsSaveChanges()
		{
			var fakeContext = MockRepository.GenerateMock<HrContext>();
			fakeContext.Stub(e=>e.Employees).Return( MockRepository.GenerateStub<DbSet<Employee>>()); 

			var ec = new StandardEmployeeCommands(dummyEmailProvider, fakeContext);

			ec.Add(new NewEmployee { FirstName = "Bob", LastName = "Smith", Salary = 30000 });

			fakeContext.AssertWasCalled(f=>f.SaveChanges());
		}
	}
}
