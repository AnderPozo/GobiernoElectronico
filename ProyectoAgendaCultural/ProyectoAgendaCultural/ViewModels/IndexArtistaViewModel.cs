using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoAgendaCultural.Models;
using ProyectoAgendaCultural.Models.ClasesSP;

namespace ProyectoAgendaCultural.ViewModels
{
    public class IndexArtistaViewModel:ModeloPaginacion
    {
        public List<Artista> Artistas { get; set; }
    }
}