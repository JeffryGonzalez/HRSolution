using HrApi.Contracts;

namespace HrApi.Implementors
{
	public class CorporateEmailFormatter : IFormatEmailAddresses
	{
		public string For(string firstName, string lastName)
		{
			return string.Format("{0}-{1}@company.com",
				firstName.ToLower(), lastName.ToLower());
		}
	}
}
