using AutoMapper;
using HrApi.Contracts;
using HrApi.Models;
using HrDomain;

namespace HrApi.Implementors
{
	public class StandardEmployeePersistance : IEmployeeCommands, IEmployeeQueries
	{

		private readonly IFormatEmailAddresses emailFormatter;
		private readonly HrContext context;

		public StandardEmployeePersistance(IFormatEmailAddresses emailFormatter, HrContext context)
		{
			this.emailFormatter = emailFormatter;
			this.context = context;
		}

		
		public NewEmployeeResponse Add(NewEmployee employee)
		{
			// copies properties from employe (NewEmployee) into an Employee entity from the domain.
			var employeeEntity = Mapper.Map<Employee>(employee);
			employeeEntity.Email = emailFormatter.For(employee.FirstName, employee.LastName);;

			context.Employees.Add(employeeEntity);
			context.SaveChanges();

			var response = Mapper.Map<NewEmployeeResponse>(employeeEntity);
			return response;
		}

		public NewEmployeeResponse Find(int id)
		{
			var result = context.Employees.Find(id);
			if (result == null) return null;
			return Mapper.Map<NewEmployeeResponse>(result);
		}
	}
}
