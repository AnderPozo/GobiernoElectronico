using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoAgendaCultural.Models
{
    //-----------------------PROVINCIA-------------------------------
    [Table("Provincia", Schema = "AgendaCulturalDB")]
    public class Provincia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "Provincia")]
        public string Nombre_provincia { get; set; }

        public virtual ICollection<Ciudad> Ciudades { get; set; }

    }

    //-----------------------CIUDAD-------------------------------
    [Table("Ciudad", Schema = "AgendaCulturalDB")]
    public class Ciudad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Ciudad")]
        public string Nombre_ciudad { get; set; }

        //Foreign Key Provincia
        [Display(Name = "Provincia, localidad")]
        public int ProvinciaId { get; set; }
        [ForeignKey("ProvinciaId")]
        public Provincia Provincia { get; set; }

        public virtual ICollection<Direccion> Direcciones { get; set; }
    }

    //-----------------------DIRECCIÓN-------------------------------
    [Table("Direccion", Schema = "AgendaCulturalDB")]
    public class Direccion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Dirección")]
        public string Nombre_direccion { get; set; }
        [StringLength(50)]
        public string Distrito { get; set; }

        //Foreign key Ciudad
        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }
        [ForeignKey("CiudadId")]
        public Ciudad Ciudad { get; set; }

        
        public virtual ICollection<Organizador> Organizadores { get; set; }
        public virtual ICollection<Lugar> Lugares { get; set; }
        public virtual ICollection<Artista> Artistas { get; set; }
        public virtual ICollection<Participante> Participantes { get; set; }
    }

    //-----------------------CATEGORÍA-------------------------------
    [Table("Categoria", Schema = "AgendaCulturalDB")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Categoria")]
        public string Nombre { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }

    //-----------------------LUGAR-------------------------------
    [Table("Lugar", Schema = "AgendaCulturalDB")]
    public class Lugar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Lugar")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(3000)]
        public string Descripcion { get; set; }
        [StringLength(100)]
        public string Imagen { get; set; }

        //Foreign key Direccion
        [Display(Name = "Dirección")]
        public int DireccionId { get; set; }
        [ForeignKey("DireccionId")]
        public Direccion Direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(500)]
        [Display(Name = "Información parqueo")]
        public string Informacion_parqueo { get; set; }
        [Display(Name = "Tipo de lugar")]
        public string Tipo { get; set; }

        //Lista de clase evento
        public virtual ICollection<Evento> Eventos { get; set; }

    }

    //-----------------------EVENTO-------------------------------
    [Table("Evento", Schema = "AgendaCulturalDB")]
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [StringLength(7000)]
        public string Descripcion { get; set; }
        [Display(Name = "Evento gratuito)")]
        public bool Informacion_pago { get; set; }
        [StringLength(600)]
        [Display(Name = "Información adicional")]
        public string Informacion_adicional { get; set; }
        [StringLength(100)]
        public string Imagen { get; set; }

        //Foreign Key Categoria
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        //Foreign Key Lugar
        [Display(Name = "Lugar")]
        public int LugarId { get; set; }
        [ForeignKey("LugarId")]
        public Lugar Lugar { get; set; }
        
        //Relacion varios a varios entidad Organizador
        /*
        public Evento()
        {
            this.Organizadores = new HashSet<Organizador>();
        }*/

        //public virtual ICollection<Organizador> Organizadores { get; set; }

        public virtual ICollection<EventoOrganizador> EventoOrganizadores { get; set; }
        public virtual ICollection<Presentacion> Presentaciones { get; set; }
        public virtual ICollection<Calendario> Calendarios { get; set; }
        public virtual ICollection<Asistencia> Asistencias { get; set; }

    }

    //-----------------------ORGANIZADOR-------------------------------
    [Table("Organizador", Schema = "AgendaCulturalDB")]
    public class Organizador
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [StringLength(2000)]
        public string Descripcion { get; set; }

        //Foreign key Direccion
        [Display(Name = "Dirección")]
        public int DireccionId { get; set; }
        [ForeignKey("DireccionId")]
        public Direccion Direccion { get; set; }
       
        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(70)]
        public string SitioWeb { get; set; }
        
        //Relacion varios a varios entidad Evento
        /*
        public Organizador()
        {
            this.Eventos = new HashSet<Evento>();
        } */
        
        //public virtual ICollection<Evento> Eventos { get; set; }

        public virtual ICollection<EventoOrganizador> EventoOrganizadores { get; set; }
    }

    //-----------------------ORGANIZADOREVENTO-------------------------------
    
    [Table("EventoOrganizador", Schema = "AgendaCulturalDB")]
    public class EventoOrganizador
    {
        [Key]
        public int Id { get; set; }

        //Foreign key evento
        [Display(Name = "Evento")]
        public int EventoId { get; set; }
        [ForeignKey("EventoId")]
        public Evento Evento { get; set; }

        //Foreign Key organizador
        [Display(Name = "Organizador")]
        public int OrganizadorId { get; set; }
        [ForeignKey("OrganizadorId")]
        public Organizador Organizador { get; set; }
    } 


    //--------------------------ARTISTA--------------------------------------
    [Table("Artista", Schema="AgendaCulturalDB")]
    public class Artista
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Cedula { get; set; }
        [Required]
        [StringLength(60)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(60)]
        public string Apellidos { get; set; }
        public int Edad { get; set; }

        //Foreign Key Edad
        [Display(Name = "Dirección")]
        public int DireccionId { get; set; }
        [ForeignKey("DireccionId")]
        public Direccion Direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Imagen { get; set; }
        [Required]
        [StringLength(75)]
        public string Disciplina { get; set; }

        [StringLength(200)]
        public string Facebook { get; set; }
        [StringLength(200)]
        public string Twitter { get; set; }
        [StringLength(200)]
        public string Instagram { get; set; }

        public virtual ICollection<Presentacion> Presentaciones { get; set; }

    }

    //--------------------------PRESENTACION--------------------------------------
    [Table("Presentacion", Schema = "AgendaCulturalDB")]
    public class Presentacion
    {
        [Key]
        public int Id { get; set; }

        //Foreign Key Artista
        [Display(Name = "Artista")]
        public int ArtistaId { get; set; }
        [ForeignKey("ArtistaId")]
        public Artista Artista { get; set; }

        //Foreign key evento
        [Display(Name = "Evento")]
        public int EventoId { get; set; }
        [ForeignKey("EventoId")]
        public Evento Evento { get; set; }
    }

    //--------------------------PARTICIPANTE--------------------------------------
    [Table("Participante", Schema = "AgendaCulturalDB")]
    public class Participante
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Cedula { get; set; }
        [Required]
        [StringLength(60)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(60)]
        public string Apellidos { get; set; }

        //Foreign Key direccion
        [Display(Name = "Dirección")]
        public int DireccionId { get; set; }
        [ForeignKey("DireccionId")]
        public Direccion Direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public virtual ICollection<Asistencia> Asistencias { get; set; }
    }

    //--------------------------CALENDARIO----------------------------------------
    [Table("Calendario", Schema = "AgendaCulturalDB")]
    public class Calendario
    {
        [Key]
        public int Id { get; set; }

        //Foreign key evento
        [Display(Name = "Evento")]
        public int EventoId { get; set; }
        [ForeignKey("EventoId")]
        public Evento Evento { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }


        [Display(Name = "Hora de inicio")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Hora_inicio { get; set; }

        [Display(Name = "Hora final")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Hora_final { get; set; }
    }

    //--------------------------ASISTENCIA----------------------------------------
    [Table("Asitencia", Schema = "AgendaCulturalDB")]
    public class Asistencia
    {
        [Key]
        public int Id { get; set; }

        //Foreign key evento
        [Display(Name = "Evento")]
        public int EventoId { get; set; }
        [ForeignKey("EventoId")]
        public Evento Evento { get; set; }

        //Foreign Key participante
        [Display(Name = "Participante")]
        public int ParticipanteId { get; set; }
        [ForeignKey("ParticipanteId")]
        public Participante Participante { get; set; }

    }

}