using System.Linq;
using System.Data.Entity;

namespace MY_MVC_APPLICATION.Controllers
{
	public partial class HomeController : Infrastructure.BaseController
	{
		public HomeController() : base()
		{
		}

		public virtual System.Web.Mvc.ViewResult Index()
		{
			//Models.DatabaseContext oDatabaseContext = null;

			//try
			//{
			//	oDatabaseContext =
			//		new Models.DatabaseContext();

			//	var varRoles =
			//		oDatabaseContext.Roles
			//		.OrderBy(current => current.Name)
			//		.ToList()
			//		;

			//	int intRoleCount = varRoles.Count;
			//}
			//catch (System.Exception ex)
			//{
			//	// خطا را لاگ کرده 
			//	// و پیام مناسبی به کاربر می‌دهیم
			//}
			//finally
			//{
			//	if (oDatabaseContext != null)
			//	{
			//		oDatabaseContext.Dispose();
			//		oDatabaseContext = null;
			//	}
			//}

			return (View());
		}

		public virtual System.Web.Mvc.ViewResult About()
		{
			return (View());
		}
	}
}
