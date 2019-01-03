USE AgendaCulturalDB;  
GO  
CREATE PROCEDURE [AgendaCulturalDB].[sp_ListarArtistas] 
AS   

    SET NOCOUNT ON; 
	SELECT TOP(12) art.Id as Id_artista,art.Nombres,art.Apellidos, art.Imagen 
	FROM AgendaCulturalDB.Artista art
	ORDER BY Id_Artista DESC;
GO