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
    public class AsistenciaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Asistencia
        public ActionResult Index()
        {
            var asistenciaDb = db.AsistenciaDb.Include(a => a.Evento).Include(a => a.Participante);
            return View(asistenciaDb.ToList());
        }

        // GET: Asistencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.AsistenciaDb.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: Asistencia/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre");
            ViewBag.ParticipanteId = new SelectList(db.ParticipanteDb, "Id", "Cedula");
            return View();
        }

        // POST: Asistencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventoId,ParticipanteId")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.AsistenciaDb.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", asistencia.EventoId);
            ViewBag.ParticipanteId = new SelectList(db.ParticipanteDb, "Id", "Cedula", asistencia.ParticipanteId);
            return View(asistencia);
        }

        // GET: Asistencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.AsistenciaDb.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", asistencia.EventoId);
            ViewBag.ParticipanteId = new SelectList(db.ParticipanteDb, "Id", "Cedula", asistencia.ParticipanteId);
            return View(asistencia);
        }

        // POST: Asistencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventoId,ParticipanteId")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", asistencia.EventoId);
            ViewBag.ParticipanteId = new SelectList(db.ParticipanteDb, "Id", "Cedula", asistencia.ParticipanteId);
            return View(asistencia);
        }

        // GET: Asistencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.AsistenciaDb.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: Asistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistencia asistencia = db.AsistenciaDb.Find(id);
            db.AsistenciaDb.Remove(asistencia);
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
