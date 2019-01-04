using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAgendaCultural.Models.ClasesSP
{
    public class ArtistasDeEvento
    {
        [Key]
        public int Id_evento { get; set; }
        public int Id_artista { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Imagen { get; set; }
        public string Disciplina { get; set; }
    }
}