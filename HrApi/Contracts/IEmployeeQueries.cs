using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HrApi.Models;

namespace HrApi.Contracts
{
	public interface IEmployeeQueries
	{
		NewEmployeeResponse Find(int id);
	}
}
