using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HrApi;

namespace HrApiUnitTests
{
	[TestClass]
	public class FormattingEmailsTests
	{
		[TestMethod]
		public void FormattinganEasyEmail()
		{
			var formatter = new CorporateEmailFormatter();

			var email = formatter.For("Jeff", "Gonzalez");

			Assert.AreEqual("jeff-gonzalez@company.com", email);
		}
	}
}
