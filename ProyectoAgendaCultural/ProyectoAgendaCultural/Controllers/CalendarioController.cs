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
    public class CalendarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Calendario
        public ActionResult Index()
        {
            var calendarioDb = db.CalendarioDb.Include(c => c.Evento);
            return View(calendarioDb.ToList());
        }

        // GET: Calendario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendario calendario = db.CalendarioDb.Find(id);
            if (calendario == null)
            {
                return HttpNotFound();
            }
            return View(calendario);
        }

        // GET: Calendario/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre");
            return View();
        }

        // POST: Calendario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventoId,Fecha,Hora_inicio,Hora_final")] Calendario calendario)
        {
            if (ModelState.IsValid)
            {
                db.CalendarioDb.Add(calendario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", calendario.EventoId);
            return View(calendario);
        }

        // GET: Calendario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendario calendario = db.CalendarioDb.Find(id);
            if (calendario == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", calendario.EventoId);
            return View(calendario);
        }

        // POST: Calendario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventoId,Fecha,Hora_inicio,Hora_final")] Calendario calendario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", calendario.EventoId);
            return View(calendario);
        }

        // GET: Calendario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendario calendario = db.CalendarioDb.Find(id);
            if (calendario == null)
            {
                return HttpNotFound();
            }
            return View(calendario);
        }

        // POST: Calendario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calendario calendario = db.CalendarioDb.Find(id);
            db.CalendarioDb.Remove(calendario);
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
