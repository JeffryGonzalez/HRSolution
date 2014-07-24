using System;
using HrApi.Contracts;
using HrApi.Models;

namespace HrApi.Implementors
{
	public class StandardEmployeeCommands : IEmployeeCommands
	{

		private IFormatEmailAddresses emailFormatter;

		public StandardEmployeeCommands(IFormatEmailAddresses emailFormatter)
		{
			this.emailFormatter = emailFormatter;
		}

		public NewEmployeeResponse Add(NewEmployee employee)
		{
			var emailAddress = emailFormatter.For(employee.FirstName, employee.LastName);
			// code to actually save this to the database goes here. that'd be kind of important.
			var response = new NewEmployeeResponse
			{
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				Salary = employee.Salary,
				Id = new Random().Next(1, int.MaxValue),
				Email = emailAddress
			};
			return response;
		}
	}
}
