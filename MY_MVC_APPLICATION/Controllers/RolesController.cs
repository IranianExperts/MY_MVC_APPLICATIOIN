using System.Linq;
using System.Data.Entity;

namespace MY_MVC_APPLICATION.Controllers
{
	public partial class RolesController : Infrastructure.BaseController
	{
		public RolesController() : base()
		{
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Index()
		{
			var varRoles =
				MyDatabaseContext.Roles
				.OrderBy(current => current.Name)
				.ToList()
				;

			return (View(model: varRoles));
		}

		[System.Web.Mvc.HttpGet]
		//public virtual System.Web.Mvc.ActionResult Details(System.Guid id)
		public virtual System.Web.Mvc.ActionResult Details(System.Guid? id)
		{
			//if (id == null)
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			//Models.Role oRole =
			//	MyDatabaseContext.Roles
			//	.Find(id);

			//Models.Role oRole =
			//	MyDatabaseContext.Roles
			//	.Where(current => current.Id == id.Value)
			//	.First();

			Models.Role oRole =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oRole == null)
			{
				return (HttpNotFound());
			}

			return (View(model: oRole));
		}

		[System.Web.Mvc.HttpGet]
		//public virtual System.Web.Mvc.ActionResult Create()
		public virtual System.Web.Mvc.ViewResult Create()
		{
			//return (View());

			// **************************************************
			Models.Role oDefaultRole = new Models.Role();

			oDefaultRole.IsActive = true;
			// **************************************************

			return (View(model: oDefaultRole));
		}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Create(System.Web.Mvc.FormCollection formCollection)
		//{
		//	Models.Role oRole = new Models.Role();

		//	string strIsActive = formCollection["IsActive"];
		//	bool blnIsActive = false;
		//	if(string.Compare(strIsActive, "True", ignoreCase: true) == 0)
		//	{
		//		blnIsActive = true;
		//	}

		//	oRole.IsActive = blnIsActive;
		//}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Create(Models.Role role)
		//{
		//}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Create
		//	([System.Web.Mvc.Bind(Include = "IsActive,Name")] Models.Role role)
		//{
		//}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Create
		//	([System.Web.Mvc.Bind(Exclude = "Id")] Models.Role role)
		//{
		//}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Create
			([System.Web.Mvc.Bind(Exclude = "Id")] Models.Role role)
		{
			if (ModelState.IsValid)
			{
				//role.Id = Guid.NewGuid();

				MyDatabaseContext.Roles.Add(role);

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction(MVC.Roles.Index()));
			}

			//return (View());
			return (View(model: role));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Edit(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			Models.Role oRole =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oRole == null)
			{
				return (HttpNotFound());
			}

			return (View(model: oRole));
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Edit
			([System.Web.Mvc.Bind(Include = "Id,IsActive,Name")] Models.Role role)
		{
			Models.Role oOriginalRole =
				MyDatabaseContext.Roles
				.Where(current => current.Id == role.Id)
				.FirstOrDefault();

			if (oOriginalRole == null)
			{
				return (HttpNotFound());
			}

			if (ModelState.IsValid)
			{
				oOriginalRole.Name = role.Name;
				oOriginalRole.IsActive = role.IsActive;

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction(MVC.Roles.Index()));
			}

			return (View(model: role));
		}

		public virtual System.Web.Mvc.ActionResult Delete(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			Models.Role oRole =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oRole == null)
			{
				return (HttpNotFound());
			}

			return (View(model: oRole));
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ActionName("Delete")]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult DeleteConfirmed(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			Models.Role oRole =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oRole == null)
			{
				return (HttpNotFound());
			}

			MyDatabaseContext.Roles.Remove(oRole);

			MyDatabaseContext.SaveChanges();

			return (RedirectToAction(MVC.Roles.Index()));
		}
	}
}
