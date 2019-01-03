USE AgendaCulturalDB;  
GO  
CREATE PROCEDURE [AgendaCulturalDB].[sp_EventosArtista]
@Id_artista [int] 
AS 
	SET NOCOUNT ON; 
	SELECT TOP(5) art.Id as Id_artista, ev.Id as Id_evento,ev.Imagen,ev.Nombre as Nombre_evento,ev.Descripcion,
	cl.Fecha as Fecha_evento
	FROM AgendaCulturalDB.Evento ev
	INNER JOIN AgendaCulturalDB.Calendario cl
	ON cl.EventoId=ev.Id
	INNER JOIN AgendaCulturalDB.Presentacion pre
	ON pre.EventoId=ev.Id
	INNER JOIN AgendaCulturalDB.Artista art
	ON art.Id=pre.ArtistaId
	WHERE art.Id=@Id_artista
	ORDER BY Fecha_evento DESC;
GO  