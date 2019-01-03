USE AgendaCulturalDB;  
GO  
CREATE PROCEDURE [AgendaCulturalDB].[sp_ArtistasEvento]
@Id_evento [int] 
AS 
	SET NOCOUNT ON;
	SELECT ev.Id as Id_evento,art.Nombres,art.Apellidos,art.Imagen,art.Disciplina
	FROM AgendaCulturalDB.Evento ev
	INNER JOIN AgendaCulturalDB.Presentacion pres
	ON pres.EventoId=ev.Id
	INNER JOIN AgendaCulturalDB.Artista art
	ON art.Id=pres.ArtistaId
	WHERE ev.Id=@Id_evento;