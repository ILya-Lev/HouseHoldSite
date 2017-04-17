using HouseHoldSite.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace HouseHoldSite.Controllers
{
	public class MeasurementController : Controller
	{
		private readonly ApplicationDbContext _context;

		public MeasurementController()
		{
			_context = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
		}

		public MeasurementController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Measurement
		public ActionResult Index()
		{
			return View(_context.Measurements);
		}

		// GET: Measurement/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Measurement/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Measurement/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Measurement/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Measurement/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Measurement/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Measurement/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
