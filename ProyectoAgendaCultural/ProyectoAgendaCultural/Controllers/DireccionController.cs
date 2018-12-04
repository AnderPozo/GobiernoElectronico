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
    public class DireccionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Direccion
        public ActionResult Index()
        {
            var direccionDb = db.DireccionDb.Include(d => d.Ciudad);
            return View(direccionDb.ToList());
        }

        // GET: Direccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.DireccionDb.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccion/Create
        public ActionResult Create()
        {
            ViewBag.CiudadId = new SelectList(db.CiudadDb, "Id", "Nombre_ciudad");
            return View();
        }

        // POST: Direccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre_direccion,Distrito,CiudadId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.DireccionDb.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CiudadId = new SelectList(db.CiudadDb, "Id", "Nombre_ciudad", direccion.CiudadId);
            return View(direccion);
        }

        // GET: Direccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.DireccionDb.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CiudadId = new SelectList(db.CiudadDb, "Id", "Nombre_ciudad", direccion.CiudadId);
            return View(direccion);
        }

        // POST: Direccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre_direccion,Distrito,CiudadId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CiudadId = new SelectList(db.CiudadDb, "Id", "Nombre_ciudad", direccion.CiudadId);
            return View(direccion);
        }

        // GET: Direccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.DireccionDb.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = db.DireccionDb.Find(id);
            db.DireccionDb.Remove(direccion);
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
