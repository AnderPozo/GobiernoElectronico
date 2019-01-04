using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoAgendaCultural.Models.ClasesSP;

namespace ProyectoAgendaCultural.ViewModels
{
    public class EventoPorArtistasViewModel
    {
        public DetallarEvento DetallarEventos { get; set; }
        public List<ArtistasDeEvento> ArtistasDeEventos { get; set; }
        public List<OrganizadoresDeEvento> OrganizadoresDeEventos { get; set; }
    }
}