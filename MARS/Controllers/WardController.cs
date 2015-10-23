using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MARS.Models;

namespace MARS.Controllers
{
    public class WardController : Controller
    {
        private MARSContext db = new MARSContext();

        // GET: /Ward/
        public async Task<ActionResult> Index()
        {
            var wards = db.Wards.Include(w => w.CurrentSchool);
            return View(await wards.ToListAsync());
        }

        // GET: /Ward/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = await db.Wards.FindAsync(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            return View(ward);
        }

        // GET: /Ward/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Schools, "Id", "Name");
            return View();
        }

        // POST: /Ward/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="id,FirstName,Surname,Email,Sex,Level")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                db.Wards.Add(ward);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Schools, "Id", "Name", ward.id);
            return View(ward);
        }

        // GET: /Ward/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = await db.Wards.FindAsync(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Schools, "Id", "Name", ward.id);
            return View(ward);
        }

        // POST: /Ward/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="id,FirstName,Surname,Email,Sex,Level")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ward).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Schools, "Id", "Name", ward.id);
            return View(ward);
        }

        // GET: /Ward/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = await db.Wards.FindAsync(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            return View(ward);
        }

        // POST: /Ward/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Ward ward = await db.Wards.FindAsync(id);
            db.Wards.Remove(ward);
            await db.SaveChangesAsync();
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
