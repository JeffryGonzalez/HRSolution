using HrDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace EmployeesApiIntegrationTests
{
	[TestClass]
	public class GlobalInitialize
	{
		[AssemblyInitialize()]
		public static void Initialize(TestContext testContext)
		{
			Database.SetInitializer(new InitializeDatabase());
		}
	}

	public class InitializeDatabase : DropCreateDatabaseAlways<HrContext>
	{
		protected override void Seed(HrContext context)
		{
			context.Employees.Add(new Employee()
			{
				FirstName = "Bob",
				LastName = "Smith",
				Email = "bob-smith@company.com",
				Salary = 32000M
			});
			context.Employees.Add(new Employee()
			{
				FirstName = "Sue",
				LastName = "Jones",
				Email = "sue-jones@company.com",
				Salary = 82000M
			});
		}
	}
}
