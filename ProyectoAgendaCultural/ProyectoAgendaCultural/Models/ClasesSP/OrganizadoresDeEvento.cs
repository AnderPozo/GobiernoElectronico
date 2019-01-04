using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAgendaCultural.Models.ClasesSP
{
    public class OrganizadoresDeEvento
    {
        [Key]
        public int Id_evento { get; set; }
        public int Id_organizador { get; set; }
        public string Nombre_organizador { get; set; }
    }
}