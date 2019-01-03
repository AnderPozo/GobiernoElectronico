using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoAgendaCultural.Models.ClasesSP;

namespace ProyectoAgendaCultural.ViewModels
{
    public class IndexEventoViewModel:ModeloPaginacion
    {
        public List<SPEventos> SPEventoes { get; set; }
    }
}