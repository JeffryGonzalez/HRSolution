using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HrApi
{
	public interface IFormatEmailAddresses
	{
		string For(string firstName, string lastName);
	}
}
