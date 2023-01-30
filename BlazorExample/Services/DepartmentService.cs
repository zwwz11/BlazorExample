using ExampleManagement.Shared;

namespace BlazorExample.Services
{
	public class DepartmentService : ServiceBase<Department>
	{
		public DepartmentService(ApplicationDbContext context) : base(context)
		{

		}
	}
}
