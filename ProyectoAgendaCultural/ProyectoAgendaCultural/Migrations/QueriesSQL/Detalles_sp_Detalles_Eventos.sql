USE AgendaCulturalDB;  
GO  
CREATE PROCEDURE [AgendaCulturalDB].[sp_DetalleEvento]
@Id_evento [int] 
AS   
    SET NOCOUNT ON;  
    SELECT ev.Id as Id_evento,ev.Imagen,ev.Nombre as Nombre_evento,
	ev.Descripcion as Descripcion,ev.Informacion_pago,ev.Informacion_adicional,
	ct.Id as Id_categoria, ct.Nombre as Categoria
	,lg.Id as Id_lugar,lg.Nombre as Nombre_lugar,
	dr.Nombre_direccion,CD.Nombre_ciudad,PR.Nombre_provincia,
	cl.Fecha as Fecha_evento, cl.Hora_inicio, cl.Hora_final
    FROM AgendaCulturalDB.Evento ev
	INNER JOIN AgendaCulturalDB.Categoria ct
	ON ct.Id=ev.CategoriaId
	INNER JOIN AgendaCulturalDB.Lugar lg
	ON ev.LugarId=lg.Id
	INNER JOIN AgendaCulturalDB.Direccion dr
	ON lg.DireccionId=dr.Id
	INNER JOIN AgendaCulturalDB.Ciudad cd
	ON dr.CiudadId=cd.Id
	INNER JOIN AgendaCulturalDB.Provincia pr
	ON cd.ProvinciaId=pr.Id
	INNER JOIN AgendaCulturalDB.Calendario cl
	ON cl.EventoId=ev.Id
	WHERE ev.Id=@Id_evento;
GO  