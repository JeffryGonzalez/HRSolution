using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HrApi
{
	public class CorporateEmailFormatter : IFormatEmailAddresses
	{
		public string For(string firstName, string lastName)
		{
			return string.Format("{0}-{1}@company.com",
				firstName.ToLower(), lastName.ToLower());
		}
	}
}
