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
        [StringLength(20)]
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
        [StringLength(30)]
        [Display(Name = "Ciudad")]
        public string Nombre_ciudad { get; set; }

        //Foreign Key Provincia
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
        [StringLength(100)]
        [Display(Name = "Dirección")]
        public string Nombre_direccion { get; set; }
        [StringLength(50)]
        public string Distrito { get; set; }

        //Foreign key Ciudad
        public int CiudadId { get; set; }
        [ForeignKey("CiudadId")]
        public Ciudad Ciudad { get; set; }

        
        public virtual ICollection<Organizador> Organizadores { get; set; }
        public virtual ICollection<Lugar> Lugares { get; set; }
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
        //Lista de eventos
        public virtual ICollection<Evento> Eventos { get; set; }
    }

    //-----------------------LUGAR-------------------------------
    [Table("Lugar", Schema = "AgendaCulturalDB")]
    public class Lugar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(75)]
        [Display(Name = "Lugar")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(1500)]
        public string Descripcion { get; set; }

        //Foreign key Direccion
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
        [StringLength(200)]
        [Display(Name = "Información parqueo")]
        public string Informacion_parqueo { get; set; }
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
        [StringLength(1500)]
        public string Descripcion { get; set; }
        [Display(Name = "Admision(Gratuito)")]
        public bool Informacion_pago { get; set; }
        [StringLength(300)]
        [Display(Name = "Información adicional")]
        public string Informacion_adicional { get; set; }
        public string Imagen { get; set; }

        //Foreign Key Categoria      
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        //Foreign Key Lugar   
        public int LugarId { get; set; }
        [ForeignKey("LugarId")]
        public Lugar Lugar { get; set; }
        
        //Relacion varios a varios entidad Organizador
        
        public Evento()
        {
            this.Organizadores = new HashSet<Organizador>();
        }

        public virtual ICollection<Organizador> Organizadores { get; set; }

        //public virtual ICollection<EventoOrganizador> EventoOrganizadores { get; set; }

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
        [StringLength(1500)]
        public string Descripcion { get; set; }

        //Foreign key Direccion
        
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
        public Organizador()
        {
            this.Eventos = new HashSet<Evento>();
        } 
        
        public virtual ICollection<Evento> Eventos { get; set; }

        //public virtual ICollection<EventoOrganizador> EventoOrganizadores { get; set; }
    }

    //-----------------------ORGANIZADOREVENTO-------------------------------
    /*
    [Table("EventoOrganizador", Schema = "AgendaCulturalDB")]
    public class EventoOrganizador
    {
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public int OrganizadorId { get; set; }
        public Organizador Organizador { get; set; }
    } */
}