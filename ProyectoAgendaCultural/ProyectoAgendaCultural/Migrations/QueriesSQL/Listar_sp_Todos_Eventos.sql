USE AgendaCulturalDB;  
GO  
CREATE PROCEDURE [AgendaCulturalDB].[sp_ListarEventos] 
AS   

    SET NOCOUNT ON;  
    SELECT ev.Id as Id_evento,ev.Imagen,ev.Nombre as Nombre_evento
	,ev.Descripcion as Descripcion,ct.Id as Id_categoria, ct.Nombre as Categoria
	,lg.Id as Id_lugar,lg.Nombre as Nombre_lugar,cl.Fecha as Fecha_evento
    FROM AgendaCulturalDB.Evento ev
	INNER JOIN AgendaCulturalDB.Categoria ct
	ON ct.Id=ev.CategoriaId
	INNER JOIN AgendaCulturalDB.Lugar lg
	ON ev.LugarId=lg.Id
	INNER JOIN AgendaCulturalDB.Calendario cl
	ON cl.EventoId=ev.Id 
	ORDER BY ev.Id DESC;
GO  