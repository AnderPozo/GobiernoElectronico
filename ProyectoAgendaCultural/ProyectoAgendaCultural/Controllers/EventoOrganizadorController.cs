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
    public class EventoOrganizadorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventoOrganizador
        public ActionResult Index()
        {
            var eventoOrganizadorDb = db.EventoOrganizadorDb.Include(e => e.Evento).Include(e => e.Organizador);
            return View(eventoOrganizadorDb.ToList());
        }

        // GET: EventoOrganizador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoOrganizador eventoOrganizador = db.EventoOrganizadorDb.Find(id);
            if (eventoOrganizador == null)
            {
                return HttpNotFound();
            }
            return View(eventoOrganizador);
        }

        // GET: EventoOrganizador/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre");
            ViewBag.OrganizadorId = new SelectList(db.OrganizadorDb, "Id", "Nombre");
            return View();
        }

        // POST: EventoOrganizador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventoId,OrganizadorId")] EventoOrganizador eventoOrganizador)
        {
            if (ModelState.IsValid)
            {
                db.EventoOrganizadorDb.Add(eventoOrganizador);
                db.SaveChanges();
                return RedirectToAction("Create","Presentacion");
            }

            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", eventoOrganizador.EventoId);
            ViewBag.OrganizadorId = new SelectList(db.OrganizadorDb, "Id", "Nombre", eventoOrganizador.OrganizadorId);
            return View(eventoOrganizador);
        }

        //CREAR NUEVO REGISTRO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearNuevo([Bind(Include = "Id,EventoId,OrganizadorId")] EventoOrganizador eventoOrganizador)
        {
            if (ModelState.IsValid)
            {
                db.EventoOrganizadorDb.Add(eventoOrganizador);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", eventoOrganizador.EventoId);
            ViewBag.OrganizadorId = new SelectList(db.OrganizadorDb, "Id", "Nombre", eventoOrganizador.OrganizadorId);
            return View("Create");
        }

        // GET: EventoOrganizador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoOrganizador eventoOrganizador = db.EventoOrganizadorDb.Find(id);
            if (eventoOrganizador == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", eventoOrganizador.EventoId);
            ViewBag.OrganizadorId = new SelectList(db.OrganizadorDb, "Id", "Nombre", eventoOrganizador.OrganizadorId);
            return View(eventoOrganizador);
        }

        // POST: EventoOrganizador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventoId,OrganizadorId")] EventoOrganizador eventoOrganizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventoOrganizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.EventoDb, "Id", "Nombre", eventoOrganizador.EventoId);
            ViewBag.OrganizadorId = new SelectList(db.OrganizadorDb, "Id", "Nombre", eventoOrganizador.OrganizadorId);
            return View(eventoOrganizador);
        }

        // GET: EventoOrganizador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoOrganizador eventoOrganizador = db.EventoOrganizadorDb.Find(id);
            if (eventoOrganizador == null)
            {
                return HttpNotFound();
            }
            return View(eventoOrganizador);
        }

        // POST: EventoOrganizador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventoOrganizador eventoOrganizador = db.EventoOrganizadorDb.Find(id);
            db.EventoOrganizadorDb.Remove(eventoOrganizador);
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
