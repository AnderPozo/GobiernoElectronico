using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoAgendaCultural.Models.ClasesSP;
using ProyectoAgendaCultural.Models;

namespace ProyectoAgendaCultural.ViewModels
{
    public class ArtistaEventoViewModel
    {
        public List<EventosDeArtista> EventosDeArtistas { get; set; }     
        public Artista Artistas { get; set; }
        public List<ListaArtistasTOP> ListaArtistasTOPs { get; set; }
 
    }
}