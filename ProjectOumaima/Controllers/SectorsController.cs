using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOumaima.Models.University;

namespace ProjectOumaima.Controllers
{
    public class SectorsController : Controller
    {
        UniversityContext ctx;
        public SectorsController(UniversityContext context)
        {
            ctx = context;
        }
        // GET: SectorsController
        public ActionResult Index()
        {
            return View(ctx.Sectors.ToList());
        }

        // GET: SectorsController/Details/5
        public ActionResult Details(int id)
        {
            return View(ctx.Sectors.Find(id));
        }

        // GET: SectorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SectorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Sector s)
        {
            try { 
                ctx.Sectors.Add(s);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SectorsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ctx.Sectors.Find(id));
        }

        // POST: SectorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sector s)
        {
            try
            {
                ctx.Sectors.Update(s);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SectorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ctx.Sectors.Find(id));
        }

        // POST: SectorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, Sector s )
        {
            try
            {
                ctx.Sectors.Remove(s);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
