using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAgendaCultural.Models.ClasesSP
{
    public class DetallarEvento
    {
        [Key]
        public int Id_evento { get; set; }
        public string Imagen { get; set; }
        public string Nombre_evento { get; set; }
        public string Descripcion { get; set; }
        public bool Informacion_pago { get; set; }
        public string Informacion_adicional { get; set; }
        public int Id_categoria { get; set; }
        public string Categoria { get; set; }
        public int Id_lugar { get; set; }
        public string Nombre_lugar { get; set; }
        public string Nombre_direccion { get; set; }
        public string Nombre_ciudad { get; set; }
        public string Nombre_provincia { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_evento { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Hora_inicio { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Hora_final { get; set; }
    }
}