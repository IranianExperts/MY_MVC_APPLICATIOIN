using System.Linq;
using System.Data.Entity;

namespace MY_MVC_APPLICATION.Controllers
{
	public class HomeController : Infrastructure.BaseController
	{
		public HomeController() : base()
		{
		}

		public System.Web.Mvc.ViewResult Index()
		{
			return (View());
		}
	}
}
