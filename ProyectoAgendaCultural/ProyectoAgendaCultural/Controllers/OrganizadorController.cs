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
    public class OrganizadorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Organizador
        public ActionResult Index()
        {
            var organizadores = db.Organizadores.Include(o => o.Direccion);
            return View(organizadores.ToList());
        }

        // GET: Organizador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            return View(organizador);
        }

        // GET: Organizador/Create
        public ActionResult Create()
        {
            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion");
            return View();
        }

        // POST: Organizador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,DireccionId,Telefono,Email,Fax,SitioWeb")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                db.Organizadores.Add(organizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion", organizador.DireccionId);
            return View(organizador);
        }

        // GET: Organizador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion", organizador.DireccionId);
            return View(organizador);
        }

        // POST: Organizador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,DireccionId,Telefono,Email,Fax,SitioWeb")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion", organizador.DireccionId);
            return View(organizador);
        }

        // GET: Organizador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            return View(organizador);
        }

        // POST: Organizador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizador organizador = db.Organizadores.Find(id);
            db.Organizadores.Remove(organizador);
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
