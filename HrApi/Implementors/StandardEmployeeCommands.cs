using System;
using System.Runtime.InteropServices;
using System.Web.Http.Controllers;
using HrApi.Contracts;
using HrApi.Models;
using HrDomain;
using AutoMapper;

namespace HrApi.Implementors
{
	public class StandardEmployeeCommands : IEmployeeCommands
	{

		private IFormatEmailAddresses emailFormatter;
		private HrContext context;

		public StandardEmployeeCommands(IFormatEmailAddresses emailFormatter, HrContext context)
		{
			this.emailFormatter = emailFormatter;
			this.context = context;
		}

		public NewEmployeeResponse Add(NewEmployee employee)
		{
			var employeeEntity = Mapper.Map<Employee>(employee);
			employeeEntity.Email = emailFormatter.For(employee.FirstName, employee.LastName);;
			context.Employees.Add(employeeEntity);
			context.SaveChanges();

			var response = Mapper.Map<NewEmployeeResponse>(employeeEntity);
			return response;
		}
	}
}
