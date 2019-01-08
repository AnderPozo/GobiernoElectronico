﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoAgendaCultural {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RecursosSQL {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RecursosSQL() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ProyectoAgendaCultural.RecursosSQL", typeof(RecursosSQL).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a USE AgendaCulturalDB;  
        ///GO  
        ///CREATE PROCEDURE [AgendaCulturalDB].[sp_DetalleEvento]
        ///@Id_evento [int] 
        ///AS   
        ///    SET NOCOUNT ON;  
        ///    SELECT ev.Id as Id_evento,ev.Imagen,ev.Nombre as Nombre_evento,
        ///	ev.Descripcion as Descripcion,ev.Informacion_pago,ev.Informacion_adicional,
        ///	ct.Id as Id_categoria, ct.Nombre as Categoria
        ///	,lg.Id as Id_lugar,lg.Nombre as Nombre_lugar,
        ///	dr.Nombre_direccion,CD.Nombre_ciudad,PR.Nombre_provincia,
        ///	cl.Fecha as Fecha_evento, cl.Hora_inicio, cl.Hora_final
        ///    FROM Agenda [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string Detalles_sp_Detalles_Eventos {
            get {
                return ResourceManager.GetString("Detalles_sp_Detalles_Eventos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a USE AgendaCulturalDB;  
        ///GO  
        ///CREATE PROCEDURE [AgendaCulturalDB].[sp_ArtistasEvento]
        ///@Id_evento [int] 
        ///AS 
        ///	SET NOCOUNT ON;
        ///	SELECT ev.Id as Id_evento,art.Id as Id_Artista,art.Nombres,art.Apellidos,art.Imagen,art.Disciplina
        ///	FROM AgendaCulturalDB.Evento ev
        ///	INNER JOIN AgendaCulturalDB.Presentacion pres
        ///	ON pres.EventoId=ev.Id
        ///	INNER JOIN AgendaCulturalDB.Artista art
        ///	ON art.Id=pres.ArtistaId
        ///	WHERE ev.Id=@Id_evento;.
        /// </summary>
        internal static string Listar_sp_Artistas_Evento {
            get {
                return ResourceManager.GetString("Listar_sp_Artistas_Evento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a USE AgendaCulturalDB;  
        ///GO  
        ///CREATE PROCEDURE [AgendaCulturalDB].[sp_ListarArtistas] 
        ///AS   
        ///
        ///    SET NOCOUNT ON; 
        ///	SELECT TOP(12) art.Id as Id_artista,art.Nombres,art.Apellidos, art.Imagen 
        ///	FROM AgendaCulturalDB.Artista art
        ///	ORDER BY Id_Artista DESC;
        ///GO.
        /// </summary>
        internal static string Listar_sp_ArtistasTop {
            get {
                return ResourceManager.GetString("Listar_sp_ArtistasTop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a USE AgendaCulturalDB;  
        ///GO  
        ///CREATE PROCEDURE [AgendaCulturalDB].[sp_EventosCalendario] 
        ///AS   
        ///
        ///    SET NOCOUNT ON;
        ///	SELECT ev.Id as Id_evento,ev.Nombre,ev.Descripcion,cl.Fecha,cl.Hora_inicio,cl.Hora_final 
        ///	FROM AgendaCulturalDB.Evento ev
        ///	INNER JOIN AgendaCulturalDB.Calendario cl
        ///	ON cl.EventoId=ev.Id;
        ///GO.
        /// </summary>
        internal static string Listar_sp_Eventos_Calendario {
            get {
                return ResourceManager.GetString("Listar_sp_Eventos_Calendario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a USE AgendaCulturalDB;  
        ///GO  
        ///CREATE PROCEDURE [AgendaCulturalDB].[sp_EventosCategoria]
        ///@Id_categoria [int] 
        ///AS
        ///	SET NOCOUNT ON;
        ///	SELECT ct.Id as Id_categoria,ev.Id as Id_evento,ev.Imagen,ev.Nombre as Nombre_evento,
        ///	ct.Nombre as Categoria,cl.Fecha as Fecha_evento
        ///    FROM AgendaCulturalDB.Evento ev
        ///	INNER JOIN AgendaCulturalDB.Categoria ct
        ///	ON ct.Id=ev.CategoriaId
        ///	INNER JOIN AgendaCulturalDB.Calendario cl
        ///	ON cl.EventoId=ev.Id
        ///	WHERE ct.Id=@Id_categoria 
        ///	ORDER BY ev.Id DESC;
        ///GO  .
        /// </summary>
        internal static string Listar_sp_Eventos_Categoria {
            get {
                return ResourceManager.GetString("Listar_sp_Eventos_Categoria", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a USE AgendaCulturalDB;  
        ///GO  
        ///CREATE PROCEDURE [AgendaCulturalDB].[sp_EventosArtista]
        ///@Id_artista [int] 
        ///AS 
        ///	SET NOCOUNT ON; 
        ///	SELECT TOP(5) art.Id as Id_artista, ev.Id as Id_evento,ev.Imagen,ev.Nombre as Nombre_evento,ev.Descripcion,
        ///	cl.Fecha as Fecha_evento
        ///	FROM AgendaCulturalDB.Evento ev
        ///	INNER JOIN AgendaCulturalDB.Calendario cl
        ///	ON cl.EventoId=ev.Id
        ///	INNER JOIN AgendaCulturalDB.Presentacion pre
        ///	ON pre.EventoId=ev.Id
        ///	INNER JOIN AgendaCulturalDB.Artista art
        ///	ON art.Id=pre.ArtistaId
        ///	WH [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string Listar_sp_Eventos_de_Artista {
            get {
                return ResourceManager.GetString("Listar_sp_Eventos_de_Artista", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a USE AgendaCulturalDB;  
        ///GO  
        ///CREATE PROCEDURE [AgendaCulturalDB].[sp_ListarEventosIndex] 
        ///AS   
        ///    SET NOCOUNT ON;  
        ///    SELECT TOP(9) ev.Id as Id_evento,ev.Imagen,ev.Nombre as Nombre_evento
        ///	,ev.Descripcion as Descripcion,ct.Id as Id_categoria, ct.Nombre as Categoria
        ///	,lg.Id as Id_lugar,lg.Nombre as Nombre_lugar,cl.Fecha as Fecha_evento
        ///    FROM AgendaCulturalDB.Evento ev
        ///	INNER JOIN AgendaCulturalDB.Categoria ct
        ///	ON ct.Id=ev.CategoriaId
        ///	INNER JOIN AgendaCulturalDB.Lugar lg
        ///	ON ev.LugarId=lg. [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string Listar_sp_Index_Eventos {
            get {
                return ResourceManager.GetString("Listar_sp_Index_Eventos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a USE AgendaCulturalDB;  
        ///GO  
        ///CREATE PROCEDURE [AgendaCulturalDB].[sp_OrganizadoresEvento]
        ///@Id_evento [int] 
        ///AS 
        ///	SET NOCOUNT ON;
        ///	SELECT ev.Id as Id_evento,org.Id as Id_organizador,org.Nombre as Nombre_organizador
        ///	FROM AgendaCulturalDB.Organizador org
        ///	INNER JOIN AgendaCulturalDB.EventoOrganizador evOrg
        ///	ON evOrg.OrganizadorId=org.Id
        ///	INNER JOIN AgendaCulturalDB.Evento ev
        ///	ON ev.Id=evOrg.EventoId
        ///	WHERE ev.Id=@Id_evento;
        ///GO.
        /// </summary>
        internal static string Listar_sp_Organizadores_Evento {
            get {
                return ResourceManager.GetString("Listar_sp_Organizadores_Evento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a USE AgendaCulturalDB;  
        ///GO  
        ///CREATE PROCEDURE [AgendaCulturalDB].[sp_ListarEventos] 
        ///AS   
        ///
        ///    SET NOCOUNT ON;  
        ///    SELECT ev.Id as Id_evento,ev.Imagen,ev.Nombre as Nombre_evento
        ///	,ev.Descripcion as Descripcion,ct.Id as Id_categoria, ct.Nombre as Categoria
        ///	,lg.Id as Id_lugar,lg.Nombre as Nombre_lugar,cl.Fecha as Fecha_evento
        ///    FROM AgendaCulturalDB.Evento ev
        ///	INNER JOIN AgendaCulturalDB.Categoria ct
        ///	ON ct.Id=ev.CategoriaId
        ///	INNER JOIN AgendaCulturalDB.Lugar lg
        ///	ON ev.LugarId=lg.Id
        ///	INNER [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string Listar_sp_Todos_Eventos {
            get {
                return ResourceManager.GetString("Listar_sp_Todos_Eventos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [AgendaCulturalDB].[sp_ArtistasEvento].
        /// </summary>
        internal static string sp_ArtistasEvento {
            get {
                return ResourceManager.GetString("sp_ArtistasEvento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [AgendaCulturalDB].[sp_DetalleEvento].
        /// </summary>
        internal static string sp_DetalleEvento {
            get {
                return ResourceManager.GetString("sp_DetalleEvento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [AgendaCulturalDB].[sp_EventosArtista].
        /// </summary>
        internal static string sp_EventosArtista {
            get {
                return ResourceManager.GetString("sp_EventosArtista", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [AgendaCulturalDB].[sp_EventosCalendario].
        /// </summary>
        internal static string sp_EventosCalendario {
            get {
                return ResourceManager.GetString("sp_EventosCalendario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [AgendaCulturalDB].[sp_EventosCategoria].
        /// </summary>
        internal static string sp_EventosCategoria {
            get {
                return ResourceManager.GetString("sp_EventosCategoria", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [AgendaCulturalDB].[sp_ListarArtistas].
        /// </summary>
        internal static string sp_ListarArtistas {
            get {
                return ResourceManager.GetString("sp_ListarArtistas", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [AgendaCulturalDB].[sp_ListarEventos].
        /// </summary>
        internal static string sp_ListarEventos {
            get {
                return ResourceManager.GetString("sp_ListarEventos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [AgendaCulturalDB].[sp_ListarEventosIndex].
        /// </summary>
        internal static string sp_ListarEventosIndex {
            get {
                return ResourceManager.GetString("sp_ListarEventosIndex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [AgendaCulturalDB].[sp_OrganizadoresEvento].
        /// </summary>
        internal static string sp_OrganizadoresEvento {
            get {
                return ResourceManager.GetString("sp_OrganizadoresEvento", resourceCulture);
            }
        }
    }
}
