using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InfinityProject.Models;

namespace InfinityProject.Controllers
{
    public class StatusModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StatusModels
        public ActionResult Index()
        {
            return View(db.StatusModels.ToList());
        }

        // GET: StatusModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusModel statusModel = db.StatusModels.Find(id);
            if (statusModel == null)
            {
                return HttpNotFound();
            }
            return View(statusModel);
        }

        // GET: StatusModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "status,statusName")] StatusModel statusModel)
        {
            if (ModelState.IsValid)
            {
                db.StatusModels.Add(statusModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusModel);
        }

        // GET: StatusModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusModel statusModel = db.StatusModels.Find(id);
            if (statusModel == null)
            {
                return HttpNotFound();
            }
            return View(statusModel);
        }

        // POST: StatusModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "status,statusName")] StatusModel statusModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusModel);
        }

        // GET: StatusModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusModel statusModel = db.StatusModels.Find(id);
            if (statusModel == null)
            {
                return HttpNotFound();
            }
            return View(statusModel);
        }

        // POST: StatusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusModel statusModel = db.StatusModels.Find(id);
            db.StatusModels.Remove(statusModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
