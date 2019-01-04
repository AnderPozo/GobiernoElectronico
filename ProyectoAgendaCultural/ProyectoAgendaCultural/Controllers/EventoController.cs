using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAgendaCultural.Models;
using ProyectoAgendaCultural.Models.ClasesSP;
using ProyectoAgendaCultural.ViewModels;


namespace ProyectoAgendaCultural.Controllers
{
    public class EventoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SubirArchivo arc = new SubirArchivo();
        private SPEventos even = new SPEventos();
        private DetallarEvento de = new DetallarEvento();
        private ArtistasDeEvento artEven = new ArtistasDeEvento();
        private OrganizadoresDeEvento orgEven = new OrganizadoresDeEvento();
        


        // GET: Evento
        public ActionResult Index()
        {
            var eventoDb = db.EventoDb.Include(e => e.Categoria).Include(e => e.Lugar);
            return View(eventoDb.ToList());
        }

        //Vista Principal Index Eventos
        public ActionResult IndexEventos()
        {
            var even = db.Database.SqlQuery<SPEventos>("AgendaCulturalDB.sp_ListarEventosIndex").ToList();
            return View(even);
        }

        //Lista todos los eventos
        public ActionResult ListaEventos(int pagina=1)
        {
            var cantRegistrosPagina = 2;

            var ev = db.Database.SqlQuery<SPEventos>("AgendaCulturalDB.sp_ListarEventos")
                .Skip((pagina - 1) * cantRegistrosPagina)
                .Take(cantRegistrosPagina).ToList();
            var totalDeRegistros = db.Database
                .SqlQuery<SPEventos>("AgendaCulturalDB.sp_ListarEventos").Count();

            var modelo = new IndexEventoViewModel();
            modelo.SPEventoes = ev;
            modelo.PaginaActual = pagina;
            modelo.TotalRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantRegistrosPagina;


            return View(modelo);
        }

        //Detallar evento
        public ActionResult Detalles(int? id)
        {

            var de = db.Database.SqlQuery<DetallarEvento>("AgendaCulturalDB.sp_DetalleEvento @Id_evento",
             new SqlParameter("@Id_evento", id)).SingleOrDefault(e => e.Id_evento == id);

            var artEven = db.Database.SqlQuery<ArtistasDeEvento>("AgendaCulturalDB.sp_ArtistasEvento @Id_evento",
                new SqlParameter("@Id_evento", id)).ToList();

            var orgEven = db.Database.SqlQuery<OrganizadoresDeEvento>("AgendaCulturalDB.sp_OrganizadoresEvento @Id_evento",
                new SqlParameter("@Id_evento", id)).ToList();

            var mod = new EventoPorArtistasViewModel();

            mod.DetallarEventos = de;
            mod.ArtistasDeEventos = artEven;
            mod.OrganizadoresDeEventos = orgEven;

            return View(mod);
        }

        // GET: Evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Evento evento = db.EventoDb.Find(id);

            if (evento == null)
            {
                return HttpNotFound();
            }

            return View(evento);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.CategoriaDb, "Id", "Nombre");
            ViewBag.LugarId = new SelectList(db.LugarDb, "Id", "Nombre");
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Informacion_pago,Informacion_adicional,Imagen,CategoriaId,LugarId")] Evento evento, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file!=null)
            {
                //Ruta donde se guardarán las imagenes
                string ruta = Server.MapPath("~/Resources/ImagenesEventos/");

                ruta += file.FileName;
                arc.SubirImagen(ruta, file);

                //Guarda nombre de la imagen en la base de datos
                evento.Imagen = file.FileName;

                db.EventoDb.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.CategoriaDb, "Id", "Nombre", evento.CategoriaId);
            ViewBag.LugarId = new SelectList(db.LugarDb, "Id", "Nombre", evento.LugarId);
            return View(evento);
        }

        // GET: Evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.EventoDb.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.CategoriaDb, "Id", "Nombre", evento.CategoriaId);
            ViewBag.LugarId = new SelectList(db.LugarDb, "Id", "Nombre", evento.LugarId);
            return View(evento);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Informacion_pago,Informacion_adicional,Imagen,CategoriaId,LugarId")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.CategoriaDb, "Id", "Nombre", evento.CategoriaId);
            ViewBag.LugarId = new SelectList(db.LugarDb, "Id", "Nombre", evento.LugarId);
            return View(evento);
        }

        // GET: Evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.EventoDb.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.EventoDb.Find(id);
            db.EventoDb.Remove(evento);
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
