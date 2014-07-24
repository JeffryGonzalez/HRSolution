using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HrApi
{
	public interface IEmployeeCommands
	{
		NewEmployeeResponse Add(NewEmployee employee);
	}
}
