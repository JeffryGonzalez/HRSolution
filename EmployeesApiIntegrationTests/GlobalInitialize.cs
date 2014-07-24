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
			Database.SetInitializer(new DropCreateDatabaseAlways<HrContext>());
		}
	}
}
