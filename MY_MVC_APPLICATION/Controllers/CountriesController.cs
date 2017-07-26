using System.Linq;
using System.Data.Entity;

namespace MY_MVC_APPLICATION.Controllers
{
	public partial class CountriesController : Infrastructure.BaseController
	{
		public CountriesController() : base()
		{
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Index()
		{
			var varCountries =
				MyDatabaseContext.Countries
				.OrderBy(current => current.Name)
				.ToList()
				;

			return (View(model: varCountries));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Details(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			Models.Country oCountry =
				MyDatabaseContext.Countries
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oCountry == null)
			{
				return (HttpNotFound());
			}

			return (View(model: oCountry));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Create()
		{
			// **************************************************
			Models.Country oDefaultCountry = new Models.Country();

			oDefaultCountry.IsActive = true;
			// **************************************************

			return (View(model: oDefaultCountry));
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Create
			([System.Web.Mvc.Bind(Exclude = "Id")] Models.Country country)
		{
			if (ModelState.IsValid)
			{
				MyDatabaseContext.Countries.Add(country);

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction(MVC.Countries.Index()));
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

			Models.Country oCountry =
				MyDatabaseContext.Countries
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oCountry == null)
			{
				return (HttpNotFound());
			}

			return (View(model: oCountry));
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Edit
			([System.Web.Mvc.Bind(Include = "Id,IsActive,Name")] Models.Country country)
		{
			Models.Country oOriginalCountry =
				MyDatabaseContext.Countries
				.Where(current => current.Id == country.Id)
				.FirstOrDefault();

			if (oOriginalCountry == null)
			{
				return (HttpNotFound());
			}

			if (ModelState.IsValid)
			{
				oOriginalCountry.Name = country.Name;
				oOriginalCountry.IsActive = country.IsActive;

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction(MVC.Countries.Index()));
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

			Models.Country oCountry =
				MyDatabaseContext.Countries
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oCountry == null)
			{
				return (HttpNotFound());
			}

			return (View(model: oCountry));
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

			Models.Country oCountry =
				MyDatabaseContext.Countries
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (oCountry == null)
			{
				return (HttpNotFound());
			}

			MyDatabaseContext.Countries.Remove(oCountry);

			MyDatabaseContext.SaveChanges();

			return (RedirectToAction(MVC.Countries.Index()));
		}
	}
}
