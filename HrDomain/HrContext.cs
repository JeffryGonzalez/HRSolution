using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrDomain
{
	public class HrContext : DbContext
	{
		public virtual DbSet<Employee> Employees { get; set; } 
	}
}
