using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAgendaCultural.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult PanelControl()
        {
            return View();
        }


        public ActionResult Publicar_evento()
        {
            return View();
        }
    }
}