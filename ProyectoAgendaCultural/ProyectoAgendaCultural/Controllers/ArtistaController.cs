﻿using System;
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
    public class ArtistaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SubirArchivo arc = new SubirArchivo();

        // GET: Artista
        public ActionResult Index()
        {
            var artistaDb = db.ArtistaDb.Include(a => a.Direccion);
            return View(artistaDb.ToList());
        }

        // GET: Artista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artista artista = db.ArtistaDb.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        // GET: Artista/Create
        public ActionResult Create()
        {
            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion");
            return View();
        }

        // POST: Artista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cedula,Nombres,Apellidos,Edad,DireccionId,Telefono,Email,Imagen,Disciplina")] Artista artista, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file!=null)
            {
                //Ruta donde se guardarán las imagenes
                string ruta = Server.MapPath("~/Resources/ImagenesArtistas/");

                ruta += file.FileName;
                arc.SubirImagen(ruta, file);

                //Guarda nombre de la imagen en la base de datos
                artista.Imagen = file.FileName;

                db.ArtistaDb.Add(artista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion", artista.DireccionId);
            return View(artista);
        }

        // GET: Artista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artista artista = db.ArtistaDb.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion", artista.DireccionId);
            return View(artista);
        }

        // POST: Artista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cedula,Nombres,Apellidos,Edad,DireccionId,Telefono,Email,Imagen,Disciplina")] Artista artista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion", artista.DireccionId);
            return View(artista);
        }

        // GET: Artista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artista artista = db.ArtistaDb.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        // POST: Artista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artista artista = db.ArtistaDb.Find(id);
            db.ArtistaDb.Remove(artista);
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
