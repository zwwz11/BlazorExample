using ExampleManagement.Shared;

namespace BlazorExample.Services
{
	public class EmployeeService : ServiceBase<Employee>
	{
		public EmployeeService(ApplicationDbContext context) : base(context)
		{

		}
	}
}
