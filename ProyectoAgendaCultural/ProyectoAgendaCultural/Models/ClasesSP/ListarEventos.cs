using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAgendaCultural.Models.ClasesSP
{
    public class SPEventos
    {
        [Key]
        public int Id_evento { get; set; }
        public string Imagen { get; set; }
        public string Nombre_evento { get; set; }
        public string Descripcion { get; set; }
        public int Id_categoria { get; set; }
        public string Categoria { get; set; }
        public int Id_lugar { get; set; }
        public string Nombre_lugar { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_evento { get; set; }
    }
}