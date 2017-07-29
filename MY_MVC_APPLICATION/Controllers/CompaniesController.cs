using System.Linq;
using System.Data.Entity;

namespace MY_MVC_APPLICATION.Controllers
{
	public partial class CompaniesController : Infrastructure.BaseController
	{
		public CompaniesController() : base()
		{
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Index()
		{
			var varCompanies =
				MyDatabaseContext.Companies
				.OrderBy(current => current.Name)
				.ToList()
				;

			return (View(model: varCompanies));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Details(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			Models.Company oCompany =
				MyDatabaseContext.Companies
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oCompany == null)
			{
				return (HttpNotFound());
			}

			return (View(model: oCompany));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Create()
		{
			// **************************************************
			Models.Company oDefaultCompany = new Models.Company();

			oDefaultCompany.IsActive = true;
			// **************************************************

			return (View(model: oDefaultCompany));
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Create
			([System.Web.Mvc.Bind(Exclude = "Id")] Models.Company country)
		{
			if (ModelState.IsValid)
			{
				MyDatabaseContext.Companies.Add(country);

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction(MVC.Companies.Index()));
			}

			return (View(model: country));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Edit(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			Models.Company oCompany =
				MyDatabaseContext.Companies
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oCompany == null)
			{
				return (HttpNotFound());
			}

			return (View(model: oCompany));
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Edit
			([System.Web.Mvc.Bind(Include = "Id,IsActive,Name")] Models.Company country)
		{
			Models.Company oOriginalCompany =
				MyDatabaseContext.Companies
				.Where(current => current.Id == country.Id)
				.FirstOrDefault();

			if (oOriginalCompany == null)
			{
				return (HttpNotFound());
			}

			if (ModelState.IsValid)
			{
				oOriginalCompany.Name = country.Name;
				oOriginalCompany.IsActive = country.IsActive;

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction(MVC.Companies.Index()));
			}

			return (View(model: country));
		}

		public virtual System.Web.Mvc.ActionResult Delete(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			Models.Company oCompany =
				MyDatabaseContext.Companies
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oCompany == null)
			{
				return (HttpNotFound());
			}

			return (View(model: oCompany));
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

			Models.Company oCompany =
				MyDatabaseContext.Companies
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oCompany == null)
			{
				return (HttpNotFound());
			}

			MyDatabaseContext.Companies.Remove(oCompany);

			MyDatabaseContext.SaveChanges();

			return (RedirectToAction(MVC.Companies.Index()));
		}
	}
}
