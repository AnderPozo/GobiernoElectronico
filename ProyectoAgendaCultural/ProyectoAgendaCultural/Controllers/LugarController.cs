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
    [Authorize(Roles = "Administrador")]
    public class LugarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SubirArchivo arc = new SubirArchivo();

        // GET: Lugar
        public ActionResult Index()
        {
            var lugarDb = db.LugarDb.Include(l => l.Direccion);
            return View(lugarDb.ToList());
        }

        // GET: Lugar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = db.LugarDb.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // GET: Lugar/Create
        public ActionResult Create()
        {
            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion");
            return View();
        }

        // POST: Lugar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Imagen,DireccionId,Telefono,Email,Fax,Informacion_parqueo,Tipo")] Lugar lugar, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {
                //Ruta donde se guardarán las imagenes
                string ruta = Server.MapPath("~/Resources/ImagenesLugares/");

                ruta += file.FileName;
                arc.SubirImagen(ruta, file);

                //Guarda nombre de la imagen en la base de datos
                lugar.Imagen = file.FileName;


                db.LugarDb.Add(lugar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion", lugar.DireccionId);
            return View(lugar);
        }

        // GET: Lugar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = db.LugarDb.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion", lugar.DireccionId);
            return View(lugar);
        }

        // POST: Lugar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Imagen,DireccionId,Telefono,Email,Fax,Informacion_parqueo,Tipo")] Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lugar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DireccionId = new SelectList(db.DireccionDb, "Id", "Nombre_direccion", lugar.DireccionId);
            return View(lugar);
        }

        // GET: Lugar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = db.LugarDb.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: Lugar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lugar lugar = db.LugarDb.Find(id);
            db.LugarDb.Remove(lugar);
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
