using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAgendaCultural.Models;

namespace ProyectoAgendaCultural.Controllers
{
    public class CiudadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ciudad
        public ActionResult Index()
        {
            var ciudadDb = db.CiudadDb.Include(c => c.Provincia);
            return View(ciudadDb.ToList());
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.CiudadDb.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            ViewBag.ProvinciaId = new SelectList(db.ProvinciaDb, "Id", "Nombre_provincia");
            return View();
        }

        // POST: Ciudad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre_ciudad,ProvinciaId")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.CiudadDb.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinciaId = new SelectList(db.ProvinciaDb, "Id", "Nombre_provincia", ciudad.ProvinciaId);
            return View(ciudad);
        }

        // GET: Ciudad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.CiudadDb.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciaId = new SelectList(db.ProvinciaDb, "Id", "Nombre_provincia", ciudad.ProvinciaId);
            return View(ciudad);
        }

        // POST: Ciudad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre_ciudad,ProvinciaId")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciaId = new SelectList(db.ProvinciaDb, "Id", "Nombre_provincia", ciudad.ProvinciaId);
            return View(ciudad);
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.CiudadDb.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudad ciudad = db.CiudadDb.Find(id);
            db.CiudadDb.Remove(ciudad);
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
