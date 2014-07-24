using HrApi.Models;

namespace HrApi.Contracts
{
	public interface IEmployeeCommands
	{
		NewEmployeeResponse Add(NewEmployee employee);
	}
}
