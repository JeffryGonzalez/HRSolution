namespace HrApi.Models
{
	public class NewEmployeeResponse : NewEmployee 
	{
		public int Id {get; set;}
		public string Email {get; set;}
	}
}