using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HrApi;
using Rhino.Mocks;

namespace HrApiUnitTests
{
	[TestClass]
	public class StandardEmployeeCommandsTests
	{
		[TestMethod]
		public void GetsAnEmailAddress()
		{
			var fakeEmailProvider = MockRepository.GenerateStub<IFormatEmailAddresses>();
			fakeEmailProvider.Stub(f => f.For("Bob", "Smith")).Return("studboy@aol.com");
			var ec = new StandardEmployeeCommands(fakeEmailProvider);

			var result = ec.Add(new NewEmployee { FirstName = "Bob", LastName = "Smith" });

			Assert.AreEqual("studboy@aol.com", result.Email);
		}
	}
}
