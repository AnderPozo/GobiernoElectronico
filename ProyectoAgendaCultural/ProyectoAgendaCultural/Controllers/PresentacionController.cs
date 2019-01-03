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
    public class PresentacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Presentacion
        public ActionResult Index()
        {
            var presentacionDb = db.PresentacionDb.Include(p => p.Artista).Include(p => p.Evento);
            return View(presentacionDb.ToList());
        }

        // GET: Presentacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presentacion presentacion = db.PresentacionDb.Find(id);
            if (presentacion == null)
            {
                return HttpNotFound();
            }
            return View(presentacion);
        }

        // GET: Presentacion/Create
        public ActionResult Create()
        {
            ViewBag.ArtistaId = new SelectList(db.ArtistaDb, "Id", "Cedula");
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre");
            return View();
        }

        // POST: Presentacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ArtistaId,EventoId")] Presentacion presentacion)
        {
            if (ModelState.IsValid)
            {
                db.PresentacionDb.Add(presentacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistaId = new SelectList(db.ArtistaDb, "Id", "Cedula", presentacion.ArtistaId);
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", presentacion.EventoId);
            return View(presentacion);
        }

        // GET: Presentacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presentacion presentacion = db.PresentacionDb.Find(id);
            if (presentacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistaId = new SelectList(db.ArtistaDb, "Id", "Cedula", presentacion.ArtistaId);
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", presentacion.EventoId);
            return View(presentacion);
        }

        // POST: Presentacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ArtistaId,EventoId")] Presentacion presentacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presentacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistaId = new SelectList(db.ArtistaDb, "Id", "Cedula", presentacion.ArtistaId);
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", presentacion.EventoId);
            return View(presentacion);
        }

        // GET: Presentacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presentacion presentacion = db.PresentacionDb.Find(id);
            if (presentacion == null)
            {
                return HttpNotFound();
            }
            return View(presentacion);
        }

        // POST: Presentacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Presentacion presentacion = db.PresentacionDb.Find(id);
            db.PresentacionDb.Remove(presentacion);
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
