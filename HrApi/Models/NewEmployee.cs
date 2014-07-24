using System.ComponentModel.DataAnnotations;

namespace HrApi.Models
{
	public class NewEmployee
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Range(1D, 1000000D)]
		public decimal Salary { get; set; }
	}
}